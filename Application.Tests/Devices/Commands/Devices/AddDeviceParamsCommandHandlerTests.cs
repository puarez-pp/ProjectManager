using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Commands.AddDeviceParams;
using ProjectManager.Application.Devices.Queries.GetDevice;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Tests.Devices.Commands.AddDeviceParams
{
    public class AddDeviceParamsCommandHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _contextMock;
        private readonly Mock<IDateTimeService> _timeMock;
        private readonly AddDeviceParamsCommandHandler _handler;

        public AddDeviceParamsCommandHandlerTests()
        {
            _contextMock = new Mock<IApplicationDbContext>();
            _timeMock = new Mock<IDateTimeService>();

            _timeMock.Setup(x => x.Now).Returns(new DateTime(2024, 1, 1));

            _contextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            _handler = new AddDeviceParamsCommandHandler(_contextMock.Object, _timeMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Add_All_DeviceParams_With_Correct_Values()
        {
            // Arrange
            var addedParams = new List<DeviceParam>();

            _contextMock.Setup(x => x.DeviceParams.AddAsync(It.IsAny<DeviceParam>(), It.IsAny<CancellationToken>()))
                .Callback((DeviceParam p, CancellationToken _) => addedParams.Add(p))
                .Returns(new ValueTask<EntityEntry<DeviceParam>>()); 

            var command = new AddDeviceParamsCommand
            {
                DeviceId = 10,
                DeviceParams = new List<DeviceParamDto>
                {
                    new DeviceParamDto { Name = "Temp", Value = 12.5f },
                    new DeviceParamDto { Name = "Pressure", Value = 7.8f }
                }
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            addedParams.Should().HaveCount(2);

            addedParams.Should().ContainSingle(p =>
                p.DeviceId == 10 &&
                p.Name == "Temp" &&
                p.Value == 12.5f &&
                p.TimeStamp == new DateTime(2024, 1, 1));

            addedParams.Should().ContainSingle(p =>
                p.DeviceId == 10 &&
                p.Name == "Pressure" &&
                p.Value == 7.8f &&
                p.TimeStamp == new DateTime(2024, 1, 1));

            addedParams.All(p => p.Id != Guid.Empty).Should().BeTrue();

            _contextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
