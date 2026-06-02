using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Commands.AddDevice;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Tests.Devices.Commands.AddDevice
{
    public class AddDeviceCommandHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _contextMock;
        private readonly Mock<IDateTimeService> _timeMock;
        private readonly AddDeviceCommandHandler _handler;

        public AddDeviceCommandHandlerTests()
        {
            _contextMock = new Mock<IApplicationDbContext>();
            _timeMock = new Mock<IDateTimeService>();

            _timeMock.Setup(x => x.Now).Returns(new DateTime(2024, 1, 1));

            _contextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            _handler = new AddDeviceCommandHandler(_contextMock.Object, _timeMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Create_Device_With_Headers_From_Template()
        {
            // Arrange
            var template = new DeviceTemplate
            {
                DeviceType = DeviceType.Engine,
                TemplatePositions = new List<DeviceTemplatePosition>
                {
                    new DeviceTemplatePosition { Name = "Param1", Description = "Desc1", Order = 2 },
                    new DeviceTemplatePosition { Name = "Param0", Description = "Desc0", Order = 1 }
                }
            };

            // symulujemy wynik zapytania EF Core
            _contextMock.Setup(x => x.DeviceTemplates
                .FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<DeviceTemplate, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(template);

            Device addedDevice = null;

            _contextMock.Setup(x => x.Devices.Add(It.IsAny<Device>()))
                .Callback((Device d) => addedDevice = d);

            var command = new AddDeviceCommand
            {
                PlantId = 10,
                Name = "Engine X",
                Description = "Test engine",
                DeviceType = DeviceType.Engine
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            addedDevice.Should().NotBeNull();
            addedDevice.PlantId.Should().Be(10);
            addedDevice.Name.Should().Be("Engine X");
            addedDevice.Description.Should().Be("Test engine");
            addedDevice.DeviceType.Should().Be(DeviceType.Engine);
            addedDevice.CreatedAt.Should().Be(new DateTime(2024, 1, 1));

            addedDevice.DeviceHeaders.Should().HaveCount(2);

            addedDevice.DeviceHeaders.Select(h => h.Order).Should().BeInAscendingOrder();

            addedDevice.DeviceHeaders.Should().ContainSingle(h =>
                h.Name == "Param0" &&
                h.Description == "Desc0" &&
                h.Order == 1 &&
                h.Used == true);

            addedDevice.DeviceHeaders.Should().ContainSingle(h =>
                h.Name == "Param1" &&
                h.Description == "Desc1" &&
                h.Order == 2 &&
                h.Used == true);

            _contextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Throw_When_Template_Not_Found()
        {
            // Arrange
            _contextMock.Setup(x => x.DeviceTemplates
                .FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<DeviceTemplate, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((DeviceTemplate)null);

            var command = new AddDeviceCommand
            {
                DeviceType = DeviceType.Engine
            };

            // Act
            var act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Nie znaleionu właściwego szablonu");
        }
    }
}
