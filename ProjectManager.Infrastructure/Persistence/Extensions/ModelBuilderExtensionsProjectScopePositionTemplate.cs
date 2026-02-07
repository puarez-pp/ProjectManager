using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsProjectScopePositionTemplate
{
    public static void SeedProjectScopePositionTemplates(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectScopePositionTemplate>().HasData(
            // Template 1 (wiersz 1) → pozycje: 2
            new ProjectScopePositionTemplate { Id = 1, ProjectScopeTemplateId = 1, Description = "Dostawa", Order = 1 },

            // Template 2 (wiersz 3) → pozycje: 4–18
            new ProjectScopePositionTemplate { Id = 2, ProjectScopeTemplateId = 2, Description = "Projekt wykonawczy elektryczny", Order = 1 },
            new ProjectScopePositionTemplate { Id = 3, ProjectScopeTemplateId = 2, Description = "Projekt wykonawczy automatyki", Order = 2 },
            new ProjectScopePositionTemplate { Id = 4, ProjectScopeTemplateId = 2, Description = "Projekt powykonawczy elektryczny", Order = 3 },
            new ProjectScopePositionTemplate { Id = 5, ProjectScopeTemplateId = 2, Description = "Projekt powykonawczy automatyki", Order = 4 },
            new ProjectScopePositionTemplate { Id = 6, ProjectScopeTemplateId = 2, Description = "Projekt wykonawczy obudowy", Order = 5 },
            new ProjectScopePositionTemplate { Id = 7, ProjectScopeTemplateId = 2, Description = "Projekt powykonawczy obudowy", Order = 6 },
            new ProjectScopePositionTemplate { Id = 8, ProjectScopeTemplateId = 2, Description = "Szkolenie personelu.", Order = 7 },
            new ProjectScopePositionTemplate { Id = 9, ProjectScopeTemplateId = 2, Description = "Dokumentacja dla zespołu w języku polskim - 2 egzemplarze", Order = 8 },
            new ProjectScopePositionTemplate { Id = 10, ProjectScopeTemplateId = 2, Description = "Rozruch i regulacja urządzeń", Order = 9 },
            new ProjectScopePositionTemplate { Id = 11, ProjectScopeTemplateId = 2, Description = "Ośmiogodzinny ruch próbny", Order = 10 },
            new ProjectScopePositionTemplate { Id = 12, ProjectScopeTemplateId = 2, Description = "Dokumentacja dla URE.", Order = 11 },
            new ProjectScopePositionTemplate { Id = 13, ProjectScopeTemplateId = 2, Description = "Wsparcie w przygotowaniu dokumentów o udzielenie koncesji na wytwarzanie energii elektrycznej", Order = 12 },
            new ProjectScopePositionTemplate { Id = 14, ProjectScopeTemplateId = 2, Description = "Wsparcie w złożeniu pierwszego wniosku o wypłatę premii gwarantowanej", Order = 13 },
            new ProjectScopePositionTemplate { Id = 15, ProjectScopeTemplateId = 2, Description = "Wsparcie w przygotowaniu planu przeprowadzenia testów NCRfG", Order = 14 },
            new ProjectScopePositionTemplate { Id = 16, ProjectScopeTemplateId = 2, Description = "Przeprowadzenie testów NCRfG", Order = 15 },
            new ProjectScopePositionTemplate { Id = 17, ProjectScopeTemplateId = 2, Description = "Inne", Order = 16 },

            // Template 3 (wiersz 19) → pozycje: 20–28

            new ProjectScopePositionTemplate { Id = 18, ProjectScopeTemplateId = 3, Description = "Okablowanie potrzeb własnych zestawu kogeneracyjnego", Order = 2 },
            new ProjectScopePositionTemplate { Id = 19, ProjectScopeTemplateId = 3, Description = "Dostawa szaf do sterowania zespołem kogeneracyjnym, urządzeń pomocniczych i synchronizacji z siecią elektroenergetyczną", Order = 3 },
            new ProjectScopePositionTemplate { Id = 20, ProjectScopeTemplateId = 3, Description = "Wykonanie połączeń elektrycznych i AKPiA do szaf sterowania zespołem kogeneracyjnym", Order = 4 },
            new ProjectScopePositionTemplate { Id = 21, ProjectScopeTemplateId = 3, Description = "Dostawa stacji transformatorowej", Order = 5 },
            new ProjectScopePositionTemplate { Id = 22, ProjectScopeTemplateId = 3, Description = "Wyprowadzenie mocy – nN od generatora do transformatora", Order = 6 },
            new ProjectScopePositionTemplate { Id = 23, ProjectScopeTemplateId = 3, Description = "Wyprowadzenie mocy – SN od tranformatora do rozdzielnicy SN", Order = 7 },
            new ProjectScopePositionTemplate { Id = 24, ProjectScopeTemplateId = 3, Description = "Modernizacja rozdzielni SN", Order = 8 },
            new ProjectScopePositionTemplate { Id = 25, ProjectScopeTemplateId = 3, Description = "Przystosowanie szaf AKPiA na potrzeby systemu SCADA - udostępnienie sygnałów", Order = 9 },
            new ProjectScopePositionTemplate { Id = 26, ProjectScopeTemplateId = 3, Description = "Inne", Order = 10 },

            // Template 4 (wiersz 29) → pozycje: 30–33

            new ProjectScopePositionTemplate { Id = 27, ProjectScopeTemplateId = 4, Description = "Układ LT wraz z chłodnicą, orurowaniem, pompą, zaworami, armaturą,", Order = 2 },
            new ProjectScopePositionTemplate { Id = 28, ProjectScopeTemplateId = 4, Description = "Układ HT wraz z chłodnicą, orurowaniem, pompą, zaworami, armaturą,", Order = 3 },
            new ProjectScopePositionTemplate { Id = 29, ProjectScopeTemplateId = 4, Description = "Montaż urządzeń wchodzących w skład układu odzysku ciepła (pompy, wymiennik separacyjny, armatura odcinająca i regulacyjna, czujniki)", Order = 4 },
            new ProjectScopePositionTemplate { Id = 30, ProjectScopeTemplateId = 4, Description = "Wykonanie orurowania", Order = 5 },
            new ProjectScopePositionTemplate { Id = 31, ProjectScopeTemplateId = 4, Description = "Próby pomontażowe szczelności", Order = 6 },
            new ProjectScopePositionTemplate { Id = 32, ProjectScopeTemplateId = 4, Description = "Inne", Order = 7 },

            new ProjectScopePositionTemplate { Id = 33, ProjectScopeTemplateId = 5, Description = "Tłumik hałasu", Order = 2 },
            new ProjectScopePositionTemplate { Id = 34, ProjectScopeTemplateId = 5, Description = "Wymiennik poziomy spaliny/woda-glikol", Order = 3 },
            new ProjectScopePositionTemplate { Id = 35, ProjectScopeTemplateId = 5, Description = "Wykonanie i montaż komina wyrzutu spalin", Order = 4 },
            new ProjectScopePositionTemplate { Id = 36, ProjectScopeTemplateId = 5, Description = "Diverter", Order = 5 },
            new ProjectScopePositionTemplate { Id = 37, ProjectScopeTemplateId = 5, Description = "Inne", Order = 6 },

            // Template 7 (wiersz 43) → pozycje: 44
            new ProjectScopePositionTemplate { Id = 38, ProjectScopeTemplateId = 6, Description = "Przewód elastyczny łączący ścieżkę gazową z silnikiem", Order = 2 },
            new ProjectScopePositionTemplate { Id = 39, ProjectScopeTemplateId = 6, Description = "Ścieżka gazowa wewnątrz maszynowni", Order = 3 },
            new ProjectScopePositionTemplate { Id = 40, ProjectScopeTemplateId = 6, Description = "System wykrywania niebezpiecznego stężenia gazu - MAG3", Order = 4 },
            new ProjectScopePositionTemplate { Id = 41, ProjectScopeTemplateId = 6, Description = "Inne", Order = 5 },

            new ProjectScopePositionTemplate { Id = 42, ProjectScopeTemplateId = 7, Description = "Instalacja olejowa - zbiornik oleju z automatycznym uzupełnieniem.", Order = 2 },
            new ProjectScopePositionTemplate { Id = 43, ProjectScopeTemplateId = 7, Description = "Płyn chłodniczy i olej", Order = 3 },
            new ProjectScopePositionTemplate { Id = 44, ProjectScopeTemplateId = 7, Description = "Dostawa i zalanie układu olejowego olejem silnikowym.", Order = 4 },
            new ProjectScopePositionTemplate { Id = 45, ProjectScopeTemplateId = 7, Description = "Dostawa i zalanie układu płynem chłodzącym", Order = 5 },
            new ProjectScopePositionTemplate { Id = 46, ProjectScopeTemplateId = 7, Description = "Inne", Order = 6 },

            new ProjectScopePositionTemplate { Id = 47, ProjectScopeTemplateId = 8, Description = "Wykonanie obudowy dźwiękochłonnej", Order = 2 },
            new ProjectScopePositionTemplate { Id = 48, ProjectScopeTemplateId = 8, Description = "Wykonanie kompletnego układu wentylacji do obudowy", Order = 3 },
            new ProjectScopePositionTemplate { Id = 49, ProjectScopeTemplateId = 8, Description = "Wykonanie instalacji oświetleniowej i gniazd wtyczkowych", Order = 4 },

            // Template 10 (wiersz 59) → pozycje: 60–64
            new ProjectScopePositionTemplate { Id = 50, ProjectScopeTemplateId = 9, Description = "Układ pomiarowy energii elektrycznej netto", Order = 1 },
            new ProjectScopePositionTemplate { Id = 51, ProjectScopeTemplateId = 9, Description = "Układ pomiarowy energii elektrycznej brutto", Order = 2 },
            new ProjectScopePositionTemplate { Id = 52, ProjectScopeTemplateId = 9, Description = "Układ pomiarowy energii elektrycznej potrzeb własnych", Order = 3 },
            new ProjectScopePositionTemplate { Id = 53, ProjectScopeTemplateId = 9, Description = "Licznik gazu z korektorem objętościowym", Order = 4 },
            new ProjectScopePositionTemplate { Id = 54, ProjectScopeTemplateId = 9, Description = "Licznik produkcji ciepła", Order = 5 },

            // Template 11 (wiersz 65) → pozycje: 66–69
            new ProjectScopePositionTemplate { Id = 55, ProjectScopeTemplateId = 10, Description = "Instalacja gazowa", Order = 1 },
            new ProjectScopePositionTemplate { Id = 56, ProjectScopeTemplateId = 10, Description = "Instalacja odzysku ciepła ze spalin", Order = 2 },
            new ProjectScopePositionTemplate { Id = 57, ProjectScopeTemplateId = 10, Description = "Instalacja odzysku ciepła z bloku z silnika", Order = 3 },
            new ProjectScopePositionTemplate { Id = 58, ProjectScopeTemplateId = 10, Description = "Kable grzewcze dla dostarczanych instalacji", Order = 4 },

            // Template 12 (wiersz 70) → pozycje: 71–76
            new ProjectScopePositionTemplate { Id = 59, ProjectScopeTemplateId = 11, Description = "Sterownik PLC + panel HMI", Order = 1 },
            new ProjectScopePositionTemplate { Id = 60, ProjectScopeTemplateId = 11, Description = "System nadrzędny SCADA - licencje + komputer i monitor", Order = 2 },
            new ProjectScopePositionTemplate { Id = 61, ProjectScopeTemplateId = 11, Description = "Okablowanie i trasy kablowe", Order = 3 },
            new ProjectScopePositionTemplate { Id = 62, ProjectScopeTemplateId = 11, Description = "Prefabrykacja szaf", Order = 4 },
            new ProjectScopePositionTemplate { Id = 63, ProjectScopeTemplateId = 11, Description = "Montaż tras kablowych i kabli", Order = 5 },
            new ProjectScopePositionTemplate { Id = 64, ProjectScopeTemplateId = 11, Description = "Rozruch, uruchomienie, optymalizacja.", Order = 6 }
           );
    }
}