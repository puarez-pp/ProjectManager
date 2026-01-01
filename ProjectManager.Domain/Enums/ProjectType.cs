

using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;
public enum ProjectType
{
    [Display(Name = "Silnik gazowy")]
    Gas,

    [Display(Name = "Diesel")]
    Diesel,

    [Display(Name = "Turbina gazowa")]
    Turbine,

    [Display(Name = "Energia odnawialna")]
    Renewable,
}
