// Plan (pseudokod, szczegó³owo):
// 1. Przygotowaæ pomocniczn¹ funkcjê CreateDbSetMock<T> do tworzenia mocka DbSet<T> z IEnumerable<T>.
// 2. Utworzyæ przyk³adowe dane:
//    - Jeden Device z okreœlonym Id, Name, Description, DeviceType.
//    - Kilka DeviceParam z tym DeviceId, ró¿nymi Name, TimeStamp i Value, tak aby powsta³y ró¿ne kolumny i wiersze.
// 3. Ustawiæ mock IApplicationDbContext:
//    - Devices zwraca mockowany DbSet<Device>
//    - DeviceParams zwraca mockowany DbSet<DeviceParam>
// 4. Utworzyæ handler GetDeviceParamsQueryHandler z zamockowanym kontekstem.
// 5. Wywo³aæ handler.Handle z requestem zawieraj¹cym Id urz¹dzenia (bez filtrów czasu i nazw -> wszystkie parametry).
// 6. Assert:
//    - Sprawdziæ, ¿e DeviceSelectedParamsDto zawiera oczekiwane Id, Name, Description, DeviceType.
//    - Sprawdziæ, ¿e kolumny (Columns) s¹ unikalne i posortowane.
//    - Sprawdziæ, ¿e liczba wierszy (Rows) odpowiada liczbie unikalnych timestampów.
//    - Sprawdziæ kilka konkretnych wartoœci pivot (dla danego timestampu i nazwy parametru).
//
// Test zrealizowany przy u¿yciu xUnit i Moq. Test koncentruje siê na logice pivotowania i filtrowania request.Id.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Queries.GetDeviceParams;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Tests.Devices.Queries.GetDeviceParams
{
    public class GetDeviceParamsQueryHandlerTests
    {
        private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var queryable = elements.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            return mockSet;
        }

        [Fact]
        public async Task Handle_ReturnsPivotedDeviceParams()
        {
            // Arrange
            var deviceId = Guid.NewGuid();

            var devices = new List<Device>
            {
                new Device
                {
                    Id = deviceId,
                    Name = "TestDevice",
                    Description = "Desc",
                    DeviceType = 1 // zak³adamy typ liczbowy; dostosuj jeœli enum
                }
            };

            var now = DateTime.UtcNow;
            var deviceParams = new List<DeviceParam>
            {
                new DeviceParam { Id = Guid.NewGuid(), DeviceId = deviceId, Name = "Temp", TimeStamp = now, Value = "20" },
                new DeviceParam { Id = Guid.NewGuid(), DeviceId = deviceId, Name = "Hum",  TimeStamp = now, Value = "50" },
                new DeviceParam { Id = Guid.NewGuid(), DeviceId = deviceId, Name = "Temp", TimeStamp = now.AddMinutes(-5), Value = "19.5" },
                new DeviceParam { Id = Guid.NewGuid(), DeviceId = deviceId, Name = "Pressure", TimeStamp = now, Value = "1013" }
            };

            var mockDevicesSet = CreateDbSetMock(devices);
            var mockParamsSet = CreateDbSetMock(deviceParams);

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.Setup(c => c.Devices).Returns(mockDevicesSet.Object);
            mockContext.Setup(c => c.DeviceParams).Returns(mockParamsSet.Object);

            var handler = new GetDeviceParamsQueryHandler(mockContext.Object);

            var request = new GetDeviceParamsQuery
            {
                Id = deviceId,
                Start = default, // brak filtra
                End = null,
                ParamNames = null
            };

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert - device meta
            Assert.NotNull(result);
            Assert.Equal(deviceId, result.Id);
            Assert.Equal("TestDevice", result.Name);
            Assert.Equal("Desc", result.Description);
            Assert.Equal(1, result.DeviceType);

            // Assert - pivot structure
            var expectedColumns = new[] { "Hum", "Pressure", "Temp" }.OrderBy(x => x).ToList();
            Assert.Equal(expectedColumns, result.DeviceParamsPivot.Columns);

            // Unikalne timestampy: now and now.AddMinutes(-5)
            Assert.Equal(2, result.DeviceParamsPivot.Rows.Count);

            // ZnajdŸ wiersz dla 'now'
            var rowNow = result.DeviceParamsPivot.Rows.First(r => r.TimeStamp == now);
            Assert.Equal("20", rowNow.Values["Temp"]);
            Assert.Equal("50", rowNow.Values["Hum"]);
            Assert.Equal("1013", rowNow.Values["Pressure"]);

            // Wiersz dla now.AddMinutes(-5)
            var rowOld = result.DeviceParamsPivot.Rows.First(r => r.TimeStamp == now.AddMinutes(-5));
            Assert.Equal("19.5", rowOld.Values["Temp"]);
            Assert.Null(rowOld.Values["Hum"]);
            Assert.Null(rowOld.Values["Pressure"]);
        }
    }
}