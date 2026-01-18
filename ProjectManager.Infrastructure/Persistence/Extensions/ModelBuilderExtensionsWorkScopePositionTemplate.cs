using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsWorkScopePositionTemplate
{
    public static void SeedWorkScopePositionTemplates(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkScopePositionTemplate>().HasData(
            new WorkScopePositionTemplate
            {
                Id = 1,
                WorkScopeTemplateId = 1,
                Description = "Agregat",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 2,
                WorkScopeTemplateId = 1,
                Description = "Agregat - transport",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 3,
                WorkScopeTemplateId = 2,
                Description = "Fundament",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 4,
                WorkScopeTemplateId = 2,
                Description = "Zagospodarowanie terenu",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 5,
                WorkScopeTemplateId = 2,
                Description = "Przepusty przez ścianę kotłowni",
                Order = 3
            },
            new WorkScopePositionTemplate
            {
                Id = 6,
                WorkScopeTemplateId = 2,
                Description = "Kanalizacja deszczowa i technologiczna",
                Order = 4
            },
            new WorkScopePositionTemplate
            {
                Id = 7,
                WorkScopeTemplateId = 2,
                Description = "Zabudowa kontenerowa",
                Order = 5
            },
            new WorkScopePositionTemplate
            {
                Id = 8,
                WorkScopeTemplateId = 2,
                Description = "Rezerwa",
                Order = 6
            },
            new WorkScopePositionTemplate
            {
                Id = 9,
                WorkScopeTemplateId = 2,
                Description = "Rezerwa",
                Order = 7
            },
            new WorkScopePositionTemplate
            {
                Id = 10,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT, chłodnica",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 11,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT, zawór równoważący",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 12,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT, naczynie membranowe 3 bar z zestawem przyłączeniowym",
                Order = 3
            },
            new WorkScopePositionTemplate
            {
                Id = 13,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT, pompa",
                Order = 4
            },
            new WorkScopePositionTemplate
            {
                Id = 14,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT, kompensatory elastyczne",
                Order = 5
            },
            new WorkScopePositionTemplate
            {
                Id = 15,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT, przepustnice odcinające",
                Order = 6
            },
            new WorkScopePositionTemplate
            {
                Id = 16,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT, zawór bezpieczeństwa 1915 3bar",
                Order = 7
            },
            new WorkScopePositionTemplate
            {
                Id = 17,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT, filtr kołnierzowy",
                Order = 8
            },
            new WorkScopePositionTemplate
            {
                Id = 18,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT, odpowietrzniki",
                Order = 9
            },
            new WorkScopePositionTemplate
            {
                Id = 19,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT, czujniki, wskaźniki temperatury itp.",
                Order = 10
            },
            new WorkScopePositionTemplate
            {
                Id = 20,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT, wymiennik separacyjny płytowy",
                Order = 11
            },
            new WorkScopePositionTemplate
            {
                Id = 21,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT - rezerwa",
                Order = 12
            },
            new WorkScopePositionTemplate
            {
                Id = 22,
                WorkScopeTemplateId = 3,
                Description = "Obieg LT - rezerwa",
                Order = 13
            },
            new WorkScopePositionTemplate
            {
                Id = 23,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, chłodnica",
                Order = 14
            },
            new WorkScopePositionTemplate
            {
                Id = 24,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, pompa obiegu",
                Order = 15
            },
            new WorkScopePositionTemplate
            {
                Id = 25,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, wymiennik separacyjny płytowy",
                Order = 16
            },
            new WorkScopePositionTemplate
            {
                Id = 26,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, zawór równoważący",
                Order = 17
            },
            new WorkScopePositionTemplate
            {
                Id = 27,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, naczynie membranowe 10 bar z zestawem przyłączeniowym",
                Order = 18
            },
            new WorkScopePositionTemplate
            {
                Id = 28,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, naczynie schładzające 10bar",
                Order = 19
            },
            new WorkScopePositionTemplate
            {
                Id = 29,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, przepustnice odcinające",
                Order = 20
            },
            new WorkScopePositionTemplate
            {
                Id = 30,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, zawór bezpieczeństwa 1915 10bar",
                Order = 21
            },
            new WorkScopePositionTemplate
            {
                Id = 31,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, filtr kołnierzowy",
                Order = 22
            },
            new WorkScopePositionTemplate
            {
                Id = 32,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, odpowietrzniki",
                Order = 23
            },
            new WorkScopePositionTemplate
            {
                Id = 33,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, czujniki, wskaźniki temperatury itp.",
                Order = 24
            },
            new WorkScopePositionTemplate
            {
                Id = 34,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, kompensatory elastyczne",
                Order = 25
            },
            new WorkScopePositionTemplate
            {
                Id = 35,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, zawór bezpieczeństwa 1915 3 bar",
                Order = 26
            },
            new WorkScopePositionTemplate
            {
                Id = 36,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, zawór bezpieczeństwa 1915 10 bar",
                Order = 27
            },
            new WorkScopePositionTemplate
            {
                Id = 37,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, zabezpieczenia Presostaty i Termostaty",
                Order = 28
            },
            new WorkScopePositionTemplate
            {
                Id = 38,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, odpowietrzniki",
                Order = 29
            },
            new WorkScopePositionTemplate
            {
                Id = 39,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, filtr kołnierzowy",
                Order = 30
            },
            new WorkScopePositionTemplate
            {
                Id = 40,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT, Czujniki, wskaźniki temperatury itp.",
                Order = 31
            },
            new WorkScopePositionTemplate
            {
                Id = 41,
                WorkScopeTemplateId = 3,
                Description = "Rury HT / LT",
                Order = 32
            },
            new WorkScopePositionTemplate
            {
                Id = 42,
                WorkScopeTemplateId = 3,
                Description = "Izolacja, osłony rury, prace dodatkowe",
                Order = 33
            },
            new WorkScopePositionTemplate
            {
                Id = 43,
                WorkScopeTemplateId = 3,
                Description = "Automatyczny układ do oleju",
                Order = 34
            },
            new WorkScopePositionTemplate
            {
                Id = 44,
                WorkScopeTemplateId = 3,
                Description = "Zbiornik oleju",
                Order = 35
            },
            new WorkScopePositionTemplate
            {
                Id = 45,
                WorkScopeTemplateId = 3,
                Description = "Olej silnikowy",
                Order = 36
            },
            new WorkScopePositionTemplate
            {
                Id = 46,
                WorkScopeTemplateId = 3,
                Description = "Mieszanka Glikol/Woda 50/50",
                Order = 37
            },
            new WorkScopePositionTemplate
            {
                Id = 47,
                WorkScopeTemplateId = 3,
                Description = "Kable grzewcze",
                Order = 38
            },
            new WorkScopePositionTemplate
            {
                Id = 48,
                WorkScopeTemplateId = 3,
                Description = "Instalacje technologiczne: gaz, ciepło - kotłownia - kogeneracja",
                Order = 39
            },
            new WorkScopePositionTemplate
            {
                Id = 49,
                WorkScopeTemplateId = 3,
                Description = "Układ pompowy - obieg wymiennik spaliny/woda",
                Order = 40
            },
            new WorkScopePositionTemplate
            {
                Id = 50,
                WorkScopeTemplateId = 3,
                Description = "Instalacja odzysku ciepła z bloku silnika oraz spalin",
                Order = 41
            },
            new WorkScopePositionTemplate
            {
                Id = 51,
                WorkScopeTemplateId = 3,
                Description = "Instalacja odzysku ciepła - wyprowadzenie ciepła",
                Order = 42
            },
            new WorkScopePositionTemplate
            {
                Id = 52,
                WorkScopeTemplateId = 3,
                Description = "Instalacje technologiczne: gaz, ciepło - kotłownia - kogeneracja",
                Order = 43
            },
            new WorkScopePositionTemplate
            {
                Id = 53,
                WorkScopeTemplateId = 3,
                Description = "Licznik ciepła z przepływomierzem ultradźwiękowym",
                Order = 44
            },
            new WorkScopePositionTemplate
            {
                Id = 54,
                WorkScopeTemplateId = 3,
                Description = "Zawory odcinajace na obiegach grzewczych",
                Order = 45
            },
            new WorkScopePositionTemplate
            {
                Id = 55,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT - rezerwa",
                Order = 46
            },
            new WorkScopePositionTemplate
            {
                Id = 56,
                WorkScopeTemplateId = 3,
                Description = "Obieg HT - rezerwa",
                Order = 47
            },
            new WorkScopePositionTemplate
            {
                Id = 57,
                WorkScopeTemplateId = 4,
                Description = "Wentylatory",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 58,
                WorkScopeTemplateId = 4,
                Description = "Klimatizator AKPiA",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 59,
                WorkScopeTemplateId = 4,
                Description = "Wentylator EX",
                Order = 3
            },
            new WorkScopePositionTemplate
            {
                Id = 60,
                WorkScopeTemplateId = 4,
                Description = "Przepustnice",
                Order = 4
            },
            new WorkScopePositionTemplate
            {
                Id = 61,
                WorkScopeTemplateId = 4,
                Description = "Kulisy tłumiące",
                Order = 5
            },
            new WorkScopePositionTemplate
            {
                Id = 62,
                WorkScopeTemplateId = 4,
                Description = "Montaż układu wentylacji",
                Order = 6
            },
            new WorkScopePositionTemplate
            {
                Id = 63,
                WorkScopeTemplateId = 4,
                Description = "Wentylacja - rezerwa",
                Order = 7
            },
            new WorkScopePositionTemplate
            {
                Id = 64,
                WorkScopeTemplateId = 5,
                Description = "Okablowanie potrzeb własnych",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 65,
                WorkScopeTemplateId = 5,
                Description = "Instalacje uziemienia i odgromowa",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 66,
                WorkScopeTemplateId = 5,
                Description = "Instalacje oświetlenia i gniazd wtyczkowych",
                Order = 3
            },
            new WorkScopePositionTemplate
            {
                Id = 67,
                WorkScopeTemplateId = 5,
                Description = "Szafa sterowania AX",
                Order = 4
            },
            new WorkScopePositionTemplate
            {
                Id = 68,
                WorkScopeTemplateId = 5,
                Description = "Rozdzielnica GCB",
                Order = 5
            },
            new WorkScopePositionTemplate
            {
                Id = 69,
                WorkScopeTemplateId = 5,
                Description = "Falowniki",
                Order = 6
            },
            new WorkScopePositionTemplate
            {
                Id = 70,
                WorkScopeTemplateId = 5,
                Description = "Wyprowadzenie mocy",
                Order = 7
            },
            new WorkScopePositionTemplate
            {
                Id = 71,
                WorkScopeTemplateId = 5,
                Description = "Transformator",
                Order = 8
            },
            new WorkScopePositionTemplate
            {
                Id = 72,
                WorkScopeTemplateId = 5,
                Description = "Pomiary transformatora, uruchomienie",
                Order = 9
            },
            new WorkScopePositionTemplate
            {
                Id = 73,
                WorkScopeTemplateId = 5,
                Description = "Okablowanie stacji",
                Order = 10
            },
            new WorkScopePositionTemplate
            {
                Id = 74,
                WorkScopeTemplateId = 5,
                Description = "Wyprowadzenie mocy TR-RGSN",
                Order = 11
            },
            new WorkScopePositionTemplate
            {
                Id = 75,
                WorkScopeTemplateId = 5,
                Description = "Rozbudowa istniejącej rozdzielnicy SN",
                Order = 12
            },
            new WorkScopePositionTemplate
            {
                Id = 76,
                WorkScopeTemplateId = 5,
                Description = "Przeciski sterowane",
                Order = 13
            },
            new WorkScopePositionTemplate
            {
                Id = 77,
                WorkScopeTemplateId = 5,
                Description = "Wyprowadzenie sygnałów - SCADA",
                Order = 14
            },
            new WorkScopePositionTemplate
            {
                Id = 78,
                WorkScopeTemplateId = 5,
                Description = "System sterowania SCADA - kogeneracja",
                Order = 15
            },
            new WorkScopePositionTemplate
            {
                Id = 79,
                WorkScopeTemplateId = 5,
                Description = "Dostawa stacji transformatorowej",
                Order = 16
            },
            new WorkScopePositionTemplate
            {
                Id = 80,
                WorkScopeTemplateId = 5,
                Description = "Obudowa transformatora",
                Order = 17
            },
            new WorkScopePositionTemplate
            {
                Id = 81,
                WorkScopeTemplateId = 5,
                Description = "Posadowienie stacji",
                Order = 18
            },
            new WorkScopePositionTemplate
            {
                Id = 82,
                WorkScopeTemplateId = 5,
                Description = "Układ pomiarowy energii elektrycznej na zaciskach generatora",
                Order = 19
            },
            new WorkScopePositionTemplate
            {
                Id = 83,
                WorkScopeTemplateId = 5,
                Description = "Instalacje dodatkowe komunikacja światłowodowa",
                Order = 20
            },
            new WorkScopePositionTemplate
            {
                Id = 84,
                WorkScopeTemplateId = 5,
                Description = "Dostawa rozdzielnicy SN, montaż",
                Order = 21
            },
            new WorkScopePositionTemplate
            {
                Id = 85,
                WorkScopeTemplateId = 5,
                Description = "Zakup i ułożenie kabla pożarowego wyłącznika prądu",
                Order = 22
            },
            new WorkScopePositionTemplate
            {
                Id = 86,
                WorkScopeTemplateId = 5,
                Description = "Wykonanie mostu kablowego",
                Order = 23
            },
            new WorkScopePositionTemplate
            {
                Id = 87,
                WorkScopeTemplateId = 5,
                Description = "Modyfikacja architektury systemu SCADA",
                Order = 24
            },
            new WorkScopePositionTemplate
            {
                Id = 88,
                WorkScopeTemplateId = 6,
                Description = "Stacja redukcji gazu",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 89,
                WorkScopeTemplateId = 6,
                Description = "Zawór kulowy",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 90,
                WorkScopeTemplateId = 6,
                Description = "Gazex, zawór odcinający, instalacja bezpieczeństwa",
                Order = 3
            },
            new WorkScopePositionTemplate
            {
                Id = 91,
                WorkScopeTemplateId = 6,
                Description = "Wykonanie przyłącza gazowego - od skrzynki gazowej do kontenera",
                Order = 4
            },
            new WorkScopePositionTemplate
            {
                Id = 92,
                WorkScopeTemplateId = 6,
                Description = "Licznik gazu + Korektor obiętościowy ",
                Order = 5
            },
            new WorkScopePositionTemplate
            {
                Id = 93,
                WorkScopeTemplateId = 7,
                Description = "Projekt wykonawczy Elektryka / Automatyka",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 94,
                WorkScopeTemplateId = 7,
                Description = "Projekty wykonawcze kontener",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 95,
                WorkScopeTemplateId = 7,
                Description = "Projekt budowlany",
                Order = 3
            },
            new WorkScopePositionTemplate
            {
                Id = 96,
                WorkScopeTemplateId = 7,
                Description = "Odbiór UDT",
                Order = 4
            },
            new WorkScopePositionTemplate
            {
                Id = 97,
                WorkScopeTemplateId = 7,
                Description = "Uruchomienie i rozruch (Eneria)",
                Order = 5
            },
            new WorkScopePositionTemplate
            {
                Id = 98,
                WorkScopeTemplateId = 7,
                Description = "Szkolenie operatorów",
                Order = 6
            },
            new WorkScopePositionTemplate
            {
                Id = 99,
                WorkScopeTemplateId = 9,
                Description = "Zespół prądotwórczy",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 100,
                WorkScopeTemplateId = 9,
                Description = "Transport zespołu prądotwórczego",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 101,
                WorkScopeTemplateId = 9,
                Description = "Dodatkowe akumulatory",
                Order = 3
            },
            new WorkScopePositionTemplate
            {
                Id = 102,
                WorkScopeTemplateId = 10,
                Description = "Instalacja zasilania potrzeb własnych ( agregat+instacja paliwowa) z zabezpieczeniami",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 103,
                WorkScopeTemplateId = 10,
                Description = "Elastyczne połączenia generatora z szynoprzewodem",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 104,
                WorkScopeTemplateId = 11,
                Description = "Układ chłodzenia - rezerwa",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 105,
                WorkScopeTemplateId = 12,
                Description = "Tłumik spalin o tłumienności 40 db",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 106,
                WorkScopeTemplateId = 12,
                Description = "Instalacja wyrzutu spalin wraz z okuciem tłumika",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 107,
                WorkScopeTemplateId = 13,
                Description = "Zbiornik dzienny ROTH 1000 L",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 108,
                WorkScopeTemplateId = 13,
                Description = "Okablowanie instalacji paliwowej",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 109,
                WorkScopeTemplateId = 13,
                Description = "Zbiornik podziemny dwupłaszczowy, o poj. ..... 34 m3",
                Order = 3
            },
            new WorkScopePositionTemplate
            {
                Id = 110,
                WorkScopeTemplateId = 13,
                Description = "Wykonanie ochrony katodowej zbiorników",
                Order = 4
            },
            new WorkScopePositionTemplate
            {
                Id = 111,
                WorkScopeTemplateId = 13,
                Description = "Automatyka układu paliwowego",
                Order = 5
            },
            new WorkScopePositionTemplate
            {
                Id = 112,
                WorkScopeTemplateId = 13,
                Description = "Rury Brugg",
                Order = 6
            },
            new WorkScopePositionTemplate
            {
                Id = 113,
                WorkScopeTemplateId = 13,
                Description = "Instalacja paliwowa - rezerwa",
                Order = 7
            },
            new WorkScopePositionTemplate
            {
                Id = 114,
                WorkScopeTemplateId = 14,
                Description = "Instalacja olejowa - rezerwa",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 115,
                WorkScopeTemplateId = 15,
                Description = "Wentylatory",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 116,
                WorkScopeTemplateId = 15,
                Description = "Pzrepustnice",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 117,
                WorkScopeTemplateId = 15,
                Description = "Czerpnia",
                Order = 3
            },
            new WorkScopePositionTemplate
            {
                Id = 118,
                WorkScopeTemplateId = 15,
                Description = "Wyrzutnia",
                Order = 4
            },
            new WorkScopePositionTemplate
            {
                Id = 119,
                WorkScopeTemplateId = 15,
                Description = "Tłumniki akustyczne",
                Order = 5
            },
            new WorkScopePositionTemplate
            {
                Id = 120,
                WorkScopeTemplateId = 15,
                Description = "Montaż instalacji wentylacyjnej",
                Order = 6
            },
            new WorkScopePositionTemplate
            {
                Id = 121,
                WorkScopeTemplateId = 16,
                Description = "Prace budowlano-konstrukcyjne - rezerwa",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 122,
                WorkScopeTemplateId = 16,
                Description = "Prace budowlano-konstrukcyjne - rezerwa",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 123,
                WorkScopeTemplateId = 16,
                Description = "Prace budowlano-konstrukcyjne - rezerwa",
                Order = 3
            },
            new WorkScopePositionTemplate
            {
                Id = 124,
                WorkScopeTemplateId = 17,
                Description = "Testy agregatu w fabryce (FAT)",
                Order = 1
            },
            new WorkScopePositionTemplate
            {
                Id = 125,
                WorkScopeTemplateId = 17,
                Description = "Wynajem kontenera socjalnego na czas budowy",
                Order = 2
            },
            new WorkScopePositionTemplate
            {
                Id = 126,
                WorkScopeTemplateId = 17,
                Description = "Dokumentacja",
                Order = 3
            },
            new WorkScopePositionTemplate
            {
                Id = 127,
                WorkScopeTemplateId = 17,
                Description = "Uruchomienie i szkolenie",
                Order = 4
            },
            new WorkScopePositionTemplate
            {
                Id = 128,
                WorkScopeTemplateId = 17,
                Description = "Testy z obciążalnikiem",
                Order = 5
            },
            new WorkScopePositionTemplate
            {
                Id = 129,
                WorkScopeTemplateId = 17,
                Description = "Paliwo",
                Order = 6
            },
            new WorkScopePositionTemplate
            {
                Id = 130,
                WorkScopeTemplateId = 17,
                Description = "Rezerwa",
                Order = 7
            });
    }
}
