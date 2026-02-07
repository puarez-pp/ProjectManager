using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Enums;
using ProjectManager.Application.Common.Extensions;

namespace ProjectManager.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsDeviceTemplatePosition
{
    public static void SeedTemplatePositions(this ModelBuilder modelBuilder)
    {
        string heatCounter = DeviceType.HeatCounter.GetDisplayName();
        string gasCounter = DeviceType.GasCounter.GetDisplayName();
        string electricCounter = DeviceType.ElectricCounter.GetDisplayName();
        string otherCounter = DeviceType.Other.GetDisplayName();

        modelBuilder.Entity<DeviceTemplatePosition>().HasData(
            new DeviceTemplatePosition
            {
                Id = 1,
                Name = "P196",
                Description = "Olej smarowy przed filtrem",
                TemplateId = 1,
                Order = 1
            },

            new DeviceTemplatePosition
            {
                Id = 2,
                Name = "P302",
                Description = "Olej smarowy za filtrem A",
                TemplateId = 1,
                Order = 2
            },

            new DeviceTemplatePosition
            {
                Id = 3,
                Name = "T208",
                Description = "Olej smarowy",
                TemplateId = 1,
                Order = 3
            },

            new DeviceTemplatePosition
            {
                Id = 4,
                Name = "L234",
                Description = "Poziom oleju smarnego w misie olejowej",
                TemplateId = 1,
                Order = 4
            },

            new DeviceTemplatePosition
            {
                Id = 5,
                Name = "P145",
                Description = "Skrzynia korbowa",
                TemplateId = 1,
                Order = 5
            },

            new DeviceTemplatePosition
            {
                Id = 6,
                Name = "P270",
                Description = "Odbiornik B",
                TemplateId = 1,
                Order = 6
            },

            new DeviceTemplatePosition
            {
                Id = 7,
                Name = "UAKUM",
                Description = "Napięcie akumulatora",
                TemplateId = 1,
                Order = 7
            },

            new DeviceTemplatePosition
            {
                Id = 8,
                Name = "P371",
                Description = "Powietrze rozruchowe",
                TemplateId = 1,
                Order = 8
            },

            new DeviceTemplatePosition
            {
                Id = 9,
                Name = "T203",
                Description = "Powietrze zasysane",
                TemplateId = 1,
                Order = 9
            },

            new DeviceTemplatePosition
            {
                Id = 10,
                Name = "T377",
                Description = "Powietrze zasysane B",
                TemplateId = 1,
                Order = 10
            },

            new DeviceTemplatePosition
            {
                Id = 11,
                Name = "T201",
                Description = "Odbiornik",
                TemplateId = 1,
                Order = 11
            },

            new DeviceTemplatePosition
            {
                Id = 12,
                Name = "T378",
                Description = "Odbiornik B",
                TemplateId = 1,
                Order = 12
            },

            new DeviceTemplatePosition
            {
                Id = 13,
                Name = "P232",
                Description = "Odbiornik",
                TemplateId = 1,
                Order = 13
            },

            new DeviceTemplatePosition
            {
                Id = 14,
                Name = "E149",
                Description = "TEM CU napięcie zasilania",
                TemplateId = 1,
                Order = 14
            },

            new DeviceTemplatePosition
            {
                Id = 15,
                Name = "G197",
                Description = "Położenie przepustnicy",
                TemplateId = 1,
                Order = 15
            },

            new DeviceTemplatePosition
            {
                Id = 16,
                Name = "S200",
                Description = "Prędkość obrotowa silnika",
                TemplateId = 1,
                Order = 16
            },

            new DeviceTemplatePosition
            {
                Id = 17,
                Name = "E198.2",
                Description = "Moc rzeczywista",
                TemplateId = 1,
                Order = 17
            },

            new DeviceTemplatePosition
            {
                Id = 18,
                Name = "E198.6",
                Description = "Dopuszczalna moc",
                TemplateId = 1,
                Order = 18
            },

            new DeviceTemplatePosition
            {
                Id = 19,
                Name = "E199.7",
                Description = "żądanie aktywne",
                TemplateId = 1,
                Order = 19
            },

            new DeviceTemplatePosition
            {
                Id = 20,
                Name = "T288",
                Description = "spaliny za AWT",
                TemplateId = 1,
                Order = 20
            },

            new DeviceTemplatePosition
            {
                Id = 21,
                Name = "T206",
                Description = "Woda chłodz.wylot silnika",
                TemplateId = 1,
                Order = 21
            },

            new DeviceTemplatePosition
            {
                Id = 22,
                Name = "T207",
                Description = "Woda chłodząca wlot silnika",
                TemplateId = 1,
                Order = 22
            },

            new DeviceTemplatePosition
            {
                Id = 23,
                Name = "P268",
                Description = "Ciśnienie doładowania",
                TemplateId = 1,
                Order = 23
            },

            new DeviceTemplatePosition
            {
                Id = 24,
                Name = "T202",
                Description = "Woda chłodząca wlot GK",
                TemplateId = 1,
                Order = 24
            },

            new DeviceTemplatePosition
            {
                Id = 25,
                Name = "T405",
                Description = "GK-chłodnica stołowa wylot",
                TemplateId = 1,
                Order = 25
            },

            new DeviceTemplatePosition
            {
                Id = 26,
                Name = "T419",
                Description = "NK-chłodnica stołowa wylot",
                TemplateId = 1,
                Order = 26
            },

            new DeviceTemplatePosition
            {
                Id = 27,
                Name = "T291",
                Description = "Dopływ wody grzewczej",
                TemplateId = 1,
                Order = 27
            },

            new DeviceTemplatePosition
            {
                Id = 28,
                Name = "T289",
                Description = "Powrót wody grzewczej",
                TemplateId = 1,
                Order = 28
            },

            new DeviceTemplatePosition
            {
                Id = 29,
                Name = "T384",
                Description = "Woda chłodząca przed chłod. awar.",
                TemplateId = 1,
                Order = 29
            },

            new DeviceTemplatePosition
            {
                Id = 30,
                Name = "T290",
                Description = "Woda grzewcza przed KWT",
                TemplateId = 1,
                Order = 30
            },

            new DeviceTemplatePosition
            {
                Id = 31,
                Name = "T385",
                Description = "Woda grzewcza przed AWT",
                TemplateId = 1,
                Order = 31
            },

            new DeviceTemplatePosition
            {
                Id = 32,
                Name = "T459",
                Description = "Łożysko generatora A",
                TemplateId = 1,
                Order = 32
            },

            new DeviceTemplatePosition
            {
                Id = 33,
                Name = "T460",
                Description = "Łożysko generatora B",
                TemplateId = 1,
                Order = 33
            },

            new DeviceTemplatePosition
            {
                Id = 34,
                Name = "T209",
                Description = "Uzwojenie generatora U",
                TemplateId = 1,
                Order = 34
            },

            new DeviceTemplatePosition
            {
                Id = 35,
                Name = "T210",
                Description = "Uzwojenie generatora V",
                TemplateId = 1,
                Order = 35
            },

            new DeviceTemplatePosition
            {
                Id = 36,
                Name = "T211",
                Description = "Uzwojenie generatora W",
                TemplateId = 1,
                Order = 36
            },

            new DeviceTemplatePosition
            {
                Id = 37,
                Name = "T461",
                Description = "Komora spalania A1",
                TemplateId = 1,
                Order = 37
            },

            new DeviceTemplatePosition
            {
                Id = 38,
                Name = "T462",
                Description = "Komora spalania A2",
                TemplateId = 1,
                Order = 38
            },

            new DeviceTemplatePosition
            {
                Id = 39,
                Name = "T463",
                Description = "Komora spalania A3",
                TemplateId = 1,
                Order = 39
            },

            new DeviceTemplatePosition
            {
                Id = 40,
                Name = "T464",
                Description = "Komora spalania A4",
                TemplateId = 1,
                Order = 40
            },

            new DeviceTemplatePosition
            {
                Id = 41,
                Name = "T465",
                Description = "Komora spalania A5",
                TemplateId = 1,
                Order = 41
            },

            new DeviceTemplatePosition
            {
                Id = 42,
                Name = "T466",
                Description = "Komora spalania A6",
                TemplateId = 1,
                Order = 42
            },

            new DeviceTemplatePosition
            {
                Id = 43,
                Name = "T467",
                Description = "Komora spalania A7",
                TemplateId = 1,
                Order = 43
            },

            new DeviceTemplatePosition
            {
                Id = 44,
                Name = "T468",
                Description = "Komora spalania A8",
                TemplateId = 1,
                Order = 44
            },

            new DeviceTemplatePosition
            {
                Id = 45,
                Name = "T469",
                Description = "Komora spalania A9",
                TemplateId = 1,
                Order = 45
            },

            new DeviceTemplatePosition
            {
                Id = 46,
                Name = "T470",
                Description = "Komora spalania A10",
                TemplateId = 1,
                Order = 46
            },

            new DeviceTemplatePosition
            {
                Id = 47,
                Name = "T471",
                Description = "Komora spalania B1",
                TemplateId = 1,
                Order = 47
            },

            new DeviceTemplatePosition
            {
                Id = 48,
                Name = "T472",
                Description = "Komora spalania B2",
                TemplateId = 1,
                Order = 48
            },

            new DeviceTemplatePosition
            {
                Id = 49,
                Name = "T473",
                Description = "Komora spalania B3",
                TemplateId = 1,
                Order = 49
            },

            new DeviceTemplatePosition
            {
                Id = 50,
                Name = "T474",
                Description = "Komora spalania B4",
                TemplateId = 1,
                Order = 50
            },

            new DeviceTemplatePosition
            {
                Id = 51,
                Name = "T475",
                Description = "Komora spalania B5",
                TemplateId = 1,
                Order = 51
            },

            new DeviceTemplatePosition
            {
                Id = 52,
                Name = "T476",
                Description = "Komora spalania B6",
                TemplateId = 1,
                Order = 52
            },

            new DeviceTemplatePosition
            {
                Id = 53,
                Name = "T477",
                Description = "Komora spalania B7",
                TemplateId = 1,
                Order = 53
            },

            new DeviceTemplatePosition
            {
                Id = 54,
                Name = "T478",
                Description = "Komora spalania B8",
                TemplateId = 1,
                Order = 54
            },

            new DeviceTemplatePosition
            {
                Id = 55,
                Name = "T479",
                Description = "Komora spalania B9",
                TemplateId = 1,
                Order = 55
            },

            new DeviceTemplatePosition
            {
                Id = 56,
                Name = "T480",
                Description = "Komora spalania B10",
                TemplateId = 1,
                Order = 56
            },

            new DeviceTemplatePosition
            {
                Id = 57,
                Name = "T501",
                Description = "Łożysko podstawowe",
                TemplateId = 1,
                Order = 57
            },

            new DeviceTemplatePosition
            {
                Id = 58,
                Name = "T494",
                Description = "Wylot spalin ETC A",
                TemplateId = 1,
                Order = 58
            },

            new DeviceTemplatePosition
            {
                Id = 59,
                Name = "T495",
                Description = "Wylot spalin ETC B",
                TemplateId = 1,
                Order = 59
            },

            new DeviceTemplatePosition
            {
                Id = 60,
                Name = "S492",
                Description = "Prędkość obrotowa ATL A",
                TemplateId = 1,
                Order = 60
            },

            new DeviceTemplatePosition
            {
                Id = 61,
                Name = "S493",
                Description = "Prędkość obrotowa ATL b",
                TemplateId = 1,
                Order = 61
            },

            new DeviceTemplatePosition
            {
                Id = 62,
                Name = "P497",
                Description = "Woda chłodz.wylot silnika",
                TemplateId = 1,
                Order = 62
            },

            new DeviceTemplatePosition
            {
                Id = 63,
                Name = "P318",
                Description = "Olej smarowy za filtrem B",
                TemplateId = 1,
                Order = 63
            },

            new DeviceTemplatePosition
            {
                Id = 64,
                Name = "G273",
                Description = "Położenie zaworu upustowego",
                TemplateId = 1,
                Order = 64
            },

            new DeviceTemplatePosition
            {
                Id = 65,
                Name = "GKS",
                Description = "wysterowanie",
                TemplateId = 1,
                Order = 65
            },

            new DeviceTemplatePosition
            {
                Id = 66,
                Name = "NKS",
                Description = "Wysterowanie",
                TemplateId = 1,
                Order = 66
            },

            new DeviceTemplatePosition
            {
                Id = 67,
                Name = "FGEN",
                Description = "Częstotliwość generatora",
                TemplateId = 1,
                Order = 67
            },

            new DeviceTemplatePosition
            {
                Id = 68,
                Name = "PGEN",
                Description = "Moc czynna generatora (kW)",
                TemplateId = 1,
                Order = 68
            },

            new DeviceTemplatePosition
            {
                Id = 69,
                Name = "QGEN",
                Description = "Moc bierna generatora (kvar)",
                TemplateId = 1,
                Order = 69
            },

            new DeviceTemplatePosition
            {
                Id = 70,
                Name = "PF",
                Description = "Generator współczynnik mocy",
                TemplateId = 1,
                Order = 70
            },

            new DeviceTemplatePosition
            {
                Id = 71,
                Name = "UL12G",
                Description = "Napięcie generatora L1-2",
                TemplateId = 1,
                Order = 71
            },

            new DeviceTemplatePosition
            {
                Id = 72,
                Name = "UL23G",
                Description = "Napięcie generatora L2-3",
                TemplateId = 1,
                Order = 72
            },

            new DeviceTemplatePosition
            {
                Id = 73,
                Name = "UL31GNapięcie",
                Description = "generatora L3-1",
                TemplateId = 1,
                Order = 73
            },

            new DeviceTemplatePosition
            {
                Id = 74,
                Name = "UL1G",
                Description = "Napięcie generatora L1-N",
                TemplateId = 1,
                Order = 74
            },

            new DeviceTemplatePosition
            {
                Id = 75,
                Name = "UL2G",
                Description = "Napięcie generatora L2-N",
                TemplateId = 1,
                Order = 75
            },

            new DeviceTemplatePosition
            {
                Id = 76,
                Name = "UL2G",
                Description = "Napięcie generatora L3-N",
                TemplateId = 1,
                Order = 76
            },

            new DeviceTemplatePosition
            {
                Id = 77,
                Name = "IL1G",
                Description = "Prąd generatora L1",
                TemplateId = 1,
                Order = 77
            },

            new DeviceTemplatePosition
            {
                Id = 78,
                Name = "IL1G2Prąd",
                Description = "generatora L2",
                TemplateId = 1,
                Order = 78
            },

            new DeviceTemplatePosition
            {
                Id = 79,
                Name = "IL3G",
                Description = "Prąd generatora L3",
                TemplateId = 1,
                Order = 79
            },

            new DeviceTemplatePosition
            {
                Id = 80,
                Name = "FM",
                Description = "Częstotliwość sieci",
                TemplateId = 1,
                Order = 80
            },

            new DeviceTemplatePosition
            {
                Id = 81,
                Name = "UL12M",
                Description = "Napięcie sieci L1-2",
                TemplateId = 1,
                Order = 81
            },

            new DeviceTemplatePosition
            {
                Id = 82,
                Name = "UL23M",
                Description = "Napięcie sieci L2-3",
                TemplateId = 1,
                Order = 82
            },

            new DeviceTemplatePosition
            {
                Id = 83,
                Name = "UL31M",
                Description = "Napięcie sieci L3-1",
                TemplateId = 1,
                Order = 83
            },

            new DeviceTemplatePosition
            {
                Id = 84,
                Name = "UL1M",
                Description = "Napięcie sieci L1-N",
                TemplateId = 1,
                Order = 84
            },

            new DeviceTemplatePosition
            {
                Id = 85,
                Name = "UL2M",
                Description = "Napięcie sieci L2-N",
                TemplateId = 1,
                Order = 85
            },

            new DeviceTemplatePosition
            {
                Id = 86,
                Name = "UL3M",
                Description = "Napięcie sieci L3-N",
                TemplateId = 1,
                Order = 86
            },

            new DeviceTemplatePosition
            {
                Id = 87,
                Name = "PSET",
                Description = "Zadana moc czynna aktualna",
                TemplateId = 1,
                Order = 87
            },

            new DeviceTemplatePosition
            {
                Id = 88,
                Name = "PFSET",
                Description = "Zadany wspólczynnik mocy aktualny",
                TemplateId = 1,
                Order = 88
            },

            new DeviceTemplatePosition
            {
                Id = 89,
                Name = "PSCADA",
                Description = "Zadana moc czynna z SCADA",
                TemplateId = 1,
                Order = 89
            },

            new DeviceTemplatePosition
            {
                Id = 90,
                Name = "PFSCADA",
                Description = "Zadany wspólczynnik mocy z SCADA",
                TemplateId = 1,
                Order = 90
            },

            new DeviceTemplatePosition
            {
                Id = 91,
                Name = "POSD",
                Description = "Zadana wartość mocy czynnej - OSD",
                TemplateId = 1,
                Order = 91
            },

            new DeviceTemplatePosition
            {
                Id = 92,
                Name = "QOSD",
                Description = "Zadana wartość mocy biernej  - OSD",
                TemplateId = 1,
                Order = 92
            },

            new DeviceTemplatePosition
            {
                Id = 93,
                Name = "PFOSD",
                Description = "Zadana wartość współczynnika mocy  - OSD",
                TemplateId = 1,
                Order = 93
            },

            new DeviceTemplatePosition
            {
                Id = 94,
                Name = "UOSD",
                Description = "Zadana wartość napięcia - OSD",
                TemplateId = 1,
                Order = 94
            },

            new DeviceTemplatePosition
            {
                Id = 95,
                Name = "T290",
                Description = "Woda grzewcza przed KWT",
                TemplateId = 1,
                Order = 95
            },

            new DeviceTemplatePosition
            {
                Id = 96,
                Name = "T385",
                Description = "Woda grzewcza przed AWT",
                TemplateId = 1,
                Order = 96
            },
            new DeviceTemplatePosition
            {
                Id = 97,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 97
            },

            new DeviceTemplatePosition
            {
                Id = 98,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 98
            },

            new DeviceTemplatePosition
            {
                Id = 99,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 99
            },

            new DeviceTemplatePosition
            {
                Id = 100,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 100
            },

            new DeviceTemplatePosition
            {
                Id = 101,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 101
            },

            new DeviceTemplatePosition
            {
                Id = 102,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 102
            },

            new DeviceTemplatePosition
            {
                Id = 103,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 103
            },

            new DeviceTemplatePosition
            {
                Id = 104,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 104
            },

            new DeviceTemplatePosition
            {
                Id = 105,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 105
            },

            new DeviceTemplatePosition
            {
                Id = 106,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 106
            },

            new DeviceTemplatePosition
            {
                Id = 107,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 107
            },

            new DeviceTemplatePosition
            {
                Id = 108,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 108
            },

            new DeviceTemplatePosition
            {
                Id = 109,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 109
            },

            new DeviceTemplatePosition
            {
                Id = 110,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 110
            },

            new DeviceTemplatePosition
            {
                Id = 111,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 111
            },

            new DeviceTemplatePosition
            {
                Id = 112,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 112
            },

            new DeviceTemplatePosition
            {
                Id = 113,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 113
            },

            new DeviceTemplatePosition
            {
                Id = 114,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 114
            },

            new DeviceTemplatePosition
            {
                Id = 115,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 115
            },

            new DeviceTemplatePosition
            {
                Id = 116,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 116
            },

            new DeviceTemplatePosition
            {
                Id = 117,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 117
            },

            new DeviceTemplatePosition
            {
                Id = 118,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 118
            },

            new DeviceTemplatePosition
            {
                Id = 119,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 119
            },

            new DeviceTemplatePosition
            {
                Id = 120,
                Name = "Rezerwa",
                Description = "Description",
                TemplateId = 1,
                Order = 120
            },
            new DeviceTemplatePosition
            {
                Id = 121,
                Name = heatCounter,
                Description = "Przepływ chwilowy",
                TemplateId = 2,
                Order = 1
            },

            new DeviceTemplatePosition
            {
                Id = 122,
                Name = heatCounter,
                Description = "Moc",
                TemplateId = 2,
                Order = 2
            },

            new DeviceTemplatePosition
            {
                Id = 123,
                Name = heatCounter,
                Description = "Stan licznika",
                TemplateId = 2,
                Order = 3
            },

            new DeviceTemplatePosition
            {
                Id = 124,
                Name = heatCounter,
                Description = "Energia",
                TemplateId = 2,
                Order = 4
            },

            new DeviceTemplatePosition
            {
                Id = 125,
                Name = heatCounter,
                Description = "Rezerwa",
                TemplateId = 2,
                Order = 5
            },

            new DeviceTemplatePosition
            {
                Id = 126,
                Name = heatCounter,
                Description = "Rezerwa",
                TemplateId = 2,
                Order = 6
            },

            new DeviceTemplatePosition
            {
                Id = 127,
                Name = heatCounter,
                Description = "Rezerwa",
                TemplateId = 2,
                Order = 7
            },

            new DeviceTemplatePosition
            {
                Id = 128,
                Name = heatCounter,
                Description = "Rezerwa",
                TemplateId = 2,
                Order = 8
            },

            new DeviceTemplatePosition
            {
                Id = 129,
                Name = heatCounter,
                Description = "Rezerwa",
                TemplateId = 2,
                Order = 9
            },

            new DeviceTemplatePosition
            {
                Id = 130,
                Name = heatCounter,
                Description = "Powietrze zasysane B",
                TemplateId = 2,
                Order = 10
            },
            new DeviceTemplatePosition
            {
                Id = 131,
                Name = gasCounter,
                Description = "Temperatura",
                TemplateId = 3,
                Order = 1
            },

            new DeviceTemplatePosition
            {
                Id = 132,
                Name = gasCounter,
                Description = "Licznik Gazu Ciśnienie P1",
                TemplateId = 3,
                Order = 2
            },

            new DeviceTemplatePosition
            {
                Id = 133,
                Name = gasCounter,
                Description = "Ciśnienie Pb",
                TemplateId = 3,
                Order = 3
            },

            new DeviceTemplatePosition
            {
                Id = 134,
                Name = gasCounter,
                Description = "Przepływ Qm",
                TemplateId = 3,
                Order = 4
            },

            new DeviceTemplatePosition
            {
                Id = 135,
                Name = gasCounter,
                Description = "Przepływ Qb",
                TemplateId = 3,
                Order = 5
            },

            new DeviceTemplatePosition
            {
                Id = 136,
                Name = gasCounter,
                Description = "Licznik Vm",
                TemplateId = 3,
                Order = 6
            },

            new DeviceTemplatePosition
            {
                Id = 137,
                Name = gasCounter,
                Description = "Licznik Vb",
                TemplateId = 3,
                Order = 7
            },

            new DeviceTemplatePosition
            {
                Id = 138,
                Name = gasCounter,
                Description = "Licznik energii",
                TemplateId = 3,
                Order = 8
            },

            new DeviceTemplatePosition
            {
                Id = 139,
                Name = gasCounter,
                Description = "Rezerwa",
                TemplateId = 3,
                Order = 9
            },

            new DeviceTemplatePosition
            {
                Id = 140,
                Name = gasCounter,              
                Description = "Powietrze zasysane B",
                TemplateId = 3,
                Order = 10
            },
            new DeviceTemplatePosition
            {
                Id = 141,
                Name = electricCounter,
                Description = "Napięcie UL1",
                TemplateId = 4,
                Order = 1
            },
            new DeviceTemplatePosition
            {
                Id = 142,
                Name = electricCounter,
                Description = "Napięcie UL2",
                TemplateId = 4,
                Order = 2
            },
            new DeviceTemplatePosition
            {
                Id = 143,
                Name = electricCounter,
                Description = "Napięcie UL3",
                TemplateId = 4,
                Order = 3
            },
            new DeviceTemplatePosition
            {
                Id = 144,
                Name = electricCounter,
                Description = "Napięcie UL12",
                TemplateId = 1,
                Order = 4
            },
            new DeviceTemplatePosition
            {
                Id = 145,
                Name = electricCounter,
                Description = "Napięcie UL23",
                TemplateId = 4,
                Order = 5
            },
            new DeviceTemplatePosition
            {
                Id = 146,
                Name = electricCounter,
                Description = "Napięcie UL31",
                TemplateId = 4,
                Order = 6
            },
            new DeviceTemplatePosition
            {
                Id = 147,
                Name = electricCounter,
                Description = "Prąd IL1",
                TemplateId = 4,
                Order = 7
            },
            new DeviceTemplatePosition
            {
                Id = 148,
                Name = electricCounter,
                Description = "Prąd IL2",
                TemplateId = 4,
                Order = 8
            },
            new DeviceTemplatePosition
            {
                Id = 149,
                Name = electricCounter,
                Description = "Prąd IL3",
                TemplateId = 4,
                Order = 9
            },
            new DeviceTemplatePosition
            {
                Id = 150,
                Name = electricCounter,
                Description = "Częstotliwość",
                TemplateId = 4,
                Order = 10
            },
            new DeviceTemplatePosition
            {
                Id = 151,
                Name = electricCounter,
                Description = "Moc czynna",
                TemplateId = 4,
                Order = 11
            },
            new DeviceTemplatePosition
            {
                Id = 152,
                Name = electricCounter,
                Description = "Moc bierna",
                TemplateId = 4,
                Order = 12
            },
            new DeviceTemplatePosition
            {
                Id = 153,
                Name = electricCounter,
                Description = "Moc pozorna",
                TemplateId = 4,
                Order = 13
            },
            new DeviceTemplatePosition
            {
                Id = 154,
                Name = electricCounter,
                Description = "Współczynnik mocy",
                TemplateId = 4,
                Order = 14
            },
            new DeviceTemplatePosition
            {
                Id = 155,
                Name = electricCounter,
                Description = "Energia czynna",
                TemplateId = 4,
                Order = 15
            },
            new DeviceTemplatePosition
            {
                Id = 156,
                Name = electricCounter,
                Description = "Energia bierna",
                TemplateId = 4,
                Order = 15
            },
            new DeviceTemplatePosition
            {
                Id = 157,
                Name = electricCounter,
                Description = "Energia pozorna",
                TemplateId = 4,
                Order = 17
            },
            new DeviceTemplatePosition
            {
                Id = 158,
                Name = electricCounter,
                Description = "Rezerwa",
                TemplateId = 4,
                Order = 18
            },
            new DeviceTemplatePosition
            {
                Id = 159,
                Name = electricCounter,
                Description = "Rezerwa",
                TemplateId = 4,
                Order = 19
            },
            new DeviceTemplatePosition
            {
                Id = 160,
                Name = electricCounter,
                Description = "Rezerwa",
                TemplateId = 4,
                Order = 20
            },
            new DeviceTemplatePosition
            {
                Id = 161,
                Name = otherCounter,
                Description = "Rezerwa",
                TemplateId = 5,
                Order = 1
            },

            new DeviceTemplatePosition
            {
                Id = 162,
                Name = otherCounter,
                Description = "Rezerwa",
                TemplateId = 5,
                Order = 2
            },

            new DeviceTemplatePosition
            {
                Id = 163,
                Name = otherCounter,
                Description = "Rezerwa",
                TemplateId = 5,
                Order = 3
            },

            new DeviceTemplatePosition
            {
                Id = 164,
                Name = otherCounter,
                Description = "Rezerwa",
                TemplateId = 5,
                Order = 4
            },

            new DeviceTemplatePosition
            {
                Id = 165,
                Name = otherCounter,
                Description = "Rezerwa",
                TemplateId = 5,
                Order = 5
            },

            new DeviceTemplatePosition
            {
                Id = 166,
                Name = otherCounter,
                Description = "Rezerwa",
                TemplateId = 5,
                Order = 6
            },

            new DeviceTemplatePosition
            {
                Id = 167,
                Name = otherCounter,
                Description = "Rezerwa",
                TemplateId = 5,
                Order = 7
            },

            new DeviceTemplatePosition
            {
                Id = 168,
                Name = otherCounter,
                Description = "Rezerwa",
                TemplateId = 5,
                Order = 8
            },

            new DeviceTemplatePosition
            {
                Id = 169,
                Name = otherCounter,
                Description = "Rezerwa",
                TemplateId = 5,
                Order = 9
            },

            new DeviceTemplatePosition
            {
                Id = 170,
                Name = otherCounter,
                Description = "Powietrze zasysane B",
                TemplateId = 5,
                Order = 10
            });
    }
}