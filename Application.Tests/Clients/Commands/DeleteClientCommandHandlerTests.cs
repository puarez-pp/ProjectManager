using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectManager.Application.Clients.Commands.DeleteClient;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Tests.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _contextMock;
        private readonly DeleteClientCommandHandler _handler;

        public DeleteClientCommandHandlerTests()
        {
            _contextMock = new Mock<IApplicationDbContext>();

            _contextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            _handler = new DeleteClientCommandHandler(_contextMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Delete_Client_And_Address()
        {
            // Arrange
            var client = new Client
            {
                Id = 5,
                Name = "ACME",
                Address = new Address { Id = 100, City = "Warszawa" }
            };

            // ZWRACAMY GOTOWEGO KLIENTA — NIE mockujemy FirstOrDefaultAsync
            _contextMock.Setup(x => x.Clients
                .FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Client, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(client);

            Address removedAddress = null;
            Client removedClient = null;

            _contextMock.Setup(x => x.Addresses.Remove(It.IsAny<Address>()))
                .Callback<Address>(a => removedAddress = a);

            _contextMock.Setup(x => x.Clients.Remove(It.IsAny<Client>()))
                .Callback<Client>(c => removedClient = c);

            var command = new DeleteClientCommand { Id = 5 };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            removedAddress.Should().Be(client.Address);
            removedClient.Should().Be(client);

            _contextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Do_Nothing_When_Client_Not_Found()
        {
            // Arrange
            _contextMock.Setup(x => x.Clients
                .FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Client, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Client)null);

            var command = new DeleteClientCommand { Id = 99 };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            _contextMock.Verify(x => x.Addresses.Remove(It.IsAny<Address>()), Times.Never);
            _contextMock.Verify(x => x.Clients.Remove(It.IsAny<Client>()), Times.Never);
            _contextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
