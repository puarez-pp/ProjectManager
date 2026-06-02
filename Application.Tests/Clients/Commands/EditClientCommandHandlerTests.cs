using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectManager.Application.Clients.Commands.EditClient;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace Application.Tests.Clients.Commands
{
    public class EditClientCommandHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _contextMock;
        private readonly EditClientCommandHandler _handler;

        public EditClientCommandHandlerTests()
        {
            _contextMock = new Mock<IApplicationDbContext>();

            _contextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            _handler = new EditClientCommandHandler(_contextMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Update_Client_And_Address()
        {
            // Arrange
            var client = new Client
            {
                Id = 5,
                Name = "Old Name",
                ContactPerson = "Old Person",
                Email = "old@mail.com",
                PhoneNumber = "111111111",
                Address = new Address
                {
                    Id = 100,
                    ClientId = 5,
                    City = "Old City",
                    Street = "Old Street",
                    StreetNumber = "1",
                    ZipCode = "00-000"
                }
            };

            // symulujemy wynik EF Core
            _contextMock.Setup(x => x.Clients
                .FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Client, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(client);

            var command = new EditClientCommand
            {
                Id = 5,
                Name = "New Name",
                ContactPerson = "New Person",
                Email = "new@mail.com",
                PhoneNumber = "222222222",
                City = "New City",
                Street = "New Street",
                StreetNumber = "99",
                ZipCode = "99-999"
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            client.Name.Should().Be("New Name");
            client.ContactPerson.Should().Be("New Person");
            client.Email.Should().Be("new@mail.com");
            client.PhoneNumber.Should().Be("222222222");

            client.Address.Should().NotBeNull();
            client.Address.ClientId.Should().Be(5);
            client.Address.City.Should().Be("New City");
            client.Address.Street.Should().Be("New Street");
            client.Address.StreetNumber.Should().Be("99");
            client.Address.ZipCode.Should().Be("99-999");

            _contextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Create_Address_When_Null()
        {
            // Arrange
            var client = new Client
            {
                Id = 5,
                Name = "Old Name",
                Address = null
            };

            _contextMock.Setup(x => x.Clients
                .FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Client, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(client);

            var command = new EditClientCommand
            {
                Id = 5,
                Name = "New Name",
                City = "City",
                Street = "Street",
                StreetNumber = "10",
                ZipCode = "00-001"
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            client.Address.Should().NotBeNull();
            client.Address.ClientId.Should().Be(5);
            client.Address.City.Should().Be("City");
            client.Address.Street.Should().Be("Street");
            client.Address.StreetNumber.Should().Be("10");
            client.Address.ZipCode.Should().Be("00-001");

            _contextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
