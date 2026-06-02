using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Commands.DeleteDevice;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Tests.Devices.Commands.DeleteDevice
{
    public class DeleteDeviceCommandHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _contextMock;
        private readonly DeleteDeviceQueryCommand _handler;

        public DeleteDeviceCommandHandlerTests()
        {
            _contextMock = new Mock<IApplicationDbContext>();

            _contextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            _handler = new DeleteDeviceQueryCommand(_contextMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Delete_Device_And_Related_Data()
        {
            // Arrange
            var device = new Device { Id = 5 };

            var deviceParams = new List<DeviceParam>
            {
                new DeviceParam { DeviceId = 5, Name = "P1" },
                new DeviceParam { DeviceId = 5, Name = "P2" }
            };

            var deviceHeaders = new List<DeviceHeader>
            {
                new DeviceHeader { DeviceId = 5, Name = "H1" },
                new DeviceHeader { DeviceId = 5, Name = "H2" }
            };

            // mock pobrania urządzenia
            _contextMock.Setup(x => x.Devices
                .FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Device, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(device);

            // mock kolekcji do usunięcia
            _contextMock.Setup(x => x.DeviceParams.Where(It.IsAny<Func<DeviceParam, bool>>()))
                .Returns(deviceParams.AsQueryable());

            _contextMock.Setup(x => x.DeviceHeaders.Where(It.IsAny<Func<DeviceHeader, bool>>()))
                .Returns(deviceHeaders.AsQueryable());

            var removedParams = new List<DeviceParam>();
            var removedHeaders = new List<DeviceHeader>();
            Device removedDevice = null;

            _contextMock.Setup(x => x.DeviceParams.RemoveRange(It.IsAny<IEnumerable<DeviceParam>>()))
                .Callback<IEnumerable<DeviceParam>>(p => removedParams.AddRange(p));

            _contextMock.Setup(x => x.DeviceHeaders.RemoveRange(It.IsAny<IEnumerable<DeviceHeader>>()))
                .Callback<IEnumerable<DeviceHeader>>(h => removedHeaders.AddRange(h));

            _contextMock.Setup(x => x.Devices.Remove(It.IsAny<Device>()))
                .Callback<Device>(d => removedDevice = d);

            var command = new DeleteDeviceCommand { Id = 5 };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            removedParams.Should().HaveCount(2);
            removedHeaders.Should().HaveCount(2);
            removedDevice.Should().Be(device);

            _contextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Do_Nothing_When_Device_Not_Found()
        {
            // Arrange
            _contextMock.Setup(x => x.Devices
                .FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Device, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Device)null);

            var command = new DeleteDeviceCommand { Id = 99 };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            _contextMock.Verify(x => x.DeviceParams.RemoveRange(It.IsAny<IEnumerable<DeviceParam>>()), Times.Never);
            _contextMock.Verify(x => x.DeviceHeaders.RemoveRange(It.IsAny<IEnumerable<DeviceHeader>>()), Times.Never);
            _contextMock.Verify(x => x.Devices.Remove(It.IsAny<Device>()), Times.Never);
            _contextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
