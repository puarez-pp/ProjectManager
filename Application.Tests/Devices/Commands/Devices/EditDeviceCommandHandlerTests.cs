using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Commands.EditDevice;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Tests.Devices.Commands.EditDevice
{
    public class EditDeviceCommandHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _contextMock;
        private readonly EditDeviceCommandHandler _handler;

        public EditDeviceCommandHandlerTests()
        {
            _contextMock = new Mock<IApplicationDbContext>();

            _contextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            _handler = new EditDeviceCommandHandler(_contextMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Update_Device_Without_Changing_Headers_When_DeviceType_Is_Same()
        {
            // Arrange
            var device = new Device
            {
                Id = 5,
                Name = "Old",
                Description = "Old desc",
                DeviceType = DeviceType.Engine,
                DeviceHeaders = new List<DeviceHeader>
                {
                    new DeviceHeader { Name = "H1", Order = 1 }
                }
            };

            _contextMock.Setup(x => x.Devices
                .FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Device, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(device);

            var command = new EditDeviceCommand
            {
                Id = 5,
                Name = "New",
                Description = "New desc",
                DeviceType = DeviceType.Engine // ten sam typ
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            device.Name.Should().Be("New");
            device.Description.Should().Be("New desc");
            device.DeviceType.Should().Be(DeviceType.Engine);

            // nagłówki nie zmienione
            device.DeviceHeaders.Should().HaveCount(1);
            device.DeviceHeaders.First().Name.Should().Be("H1");

            _contextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Rebuild_Headers_When_DeviceType_Changes()
        {
            // Arrange
            var device = new Device
            {
                Id = 5,
                Name = "Old",
                Description = "Old desc",
                DeviceType = DeviceType.Engine,
                DeviceHeaders = new List<DeviceHeader>
                {
                    new DeviceHeader { Name = "OldHeader", Order = 1 }
                }
            };

            var template = new DeviceTemplate
            {
                DeviceType = DeviceType.GasCounter,
                TemplatePositions = new List<DeviceTemplatePosition>
                {
                    new DeviceTemplatePosition { Name = "P0", Description = "D0", Order = 1 },
                    new DeviceTemplatePosition { Name = "P1", Description = "D1", Order = 2 }
                }
            };

            // mock pobrania urządzenia
            _contextMock.Setup(x => x.Devices
                .FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Device, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(device);

            // mock pobrania szablonu
            _contextMock.Setup(x => x.DeviceTemplates
                .FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<DeviceTemplate, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(template);

            var removedHeaders = new List<DeviceHeader>();
            _contextMock.Setup(x => x.DeviceHeaders.RemoveRange(It.IsAny<IEnumerable<DeviceHeader>>()))
                .Callback<IEnumerable<DeviceHeader>>(h => removedHeaders.AddRange(h));

            var command = new EditDeviceCommand
            {
                Id = 5,
                Name = "New",
                Description = "New desc",
                DeviceType = DeviceType.GasCounter // zmiana typu
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            device.DeviceType.Should().Be(DeviceType.GasCounter);

            // stare nagłówki usunięte
            removedHeaders.Should().ContainSingle(h => h.Name == "OldHeader");

            // nowe nagłówki dodane
            device.DeviceHeaders.Should().HaveCount(2);

            device.DeviceHeaders.Should().ContainSingle(h =>
                h.Name == "P0" &&
                h.Description == "D0" &&
                h.Order == 1);

            device.DeviceHeaders.Should().ContainSingle(h =>
                h.Name == "P1" &&
                h.Description == "D1" &&
                h.Order == 2);

            _contextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
