using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using ProjectManager.Application.Clients.Commands.AddClient;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace Application.Tests.Clients.Commands
{
    public class AddClientCommandHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _contextMock;
        private readonly AddClientCommandHandler _handler;

        public AddClientCommandHandlerTests()
        {
            _contextMock = new Mock<IApplicationDbContext>();

            Client addedClient = null;
            Address addedAddress = null;

            _contextMock.Setup(x => x.Clients.AddAsync(It.IsAny<Client>(), It.IsAny<CancellationToken>()))
                .Callback((Client c, CancellationToken _) =>
                {
                    addedClient = c;
                })
                .Returns(new ValueTask<EntityEntry<Client>>());

            _contextMock.Setup(x => x.Addresses.AddAsync(It.IsAny<Address>(), It.IsAny<CancellationToken>()))
                .Callback((Address a, CancellationToken _) =>
                {
                    addedAddress = a;
                })
                .Returns(new ValueTask<EntityEntry<Address>>());

            _contextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            _handler = new AddClientCommandHandler(_contextMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Create_Client_And_Address()
        {
            // Arrange
            var command = new AddClientCommand
            {
                Name = "ACME Corp",
                ContactPerson = "Jan Kowalski",
                Email = "kontakt@acme.pl",
                PhoneNumber = "123456789",
                City = "Warszawa",
                Street = "Prosta",
                StreetNumber = "51",
                ZipCode = "00-000"
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);

            // Weryfikacja dodania klienta
            _contextMock.Verify(x => x.Clients.AddAsync(It.Is<Client>(c =>
                c.Name == command.Name &&
                c.ContactPerson == command.ContactPerson &&
                c.Email == command.Email &&
                c.PhoneNumber == command.PhoneNumber
            ), It.IsAny<CancellationToken>()), Times.Once);

            // Weryfikacja dodania adresu
            _contextMock.Verify(x => x.Addresses.AddAsync(It.Is<Address>(a =>
                a.City == command.City &&
                a.Street == command.Street &&
                a.StreetNumber == command.StreetNumber &&
                a.ZipCode == command.ZipCode
            ), It.IsAny<CancellationToken>()), Times.Once);

            // Tylko jeden zapis
            _contextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
