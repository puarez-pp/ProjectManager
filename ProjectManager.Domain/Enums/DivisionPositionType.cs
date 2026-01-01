using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums
{
    public enum DivisionPositionType
    {
        [Display(Name = "Projekt wykonawczy")]
        Executive,

        [Display(Name = "Realizacja")]
        Implementation,

        [Display(Name = "Uruchomienie")]
        Activation,

        [Display(Name = "Dokumentacja powykonawcza")]
        AsBuilt,
    }
}
