using ProjectManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Dictionaries;

public static  class DivisionPositionDict
{
    public const string Construction = "Projekt budowlany";
    public const string Executive = "Projekt wykonawczy";
    public const string AsBulit = "Projekt powykonawczy";
    public const string ConnectToGrid = "Podłączenie do sieci OSD";
    public const string GenResMeas = "Pomiar rezystancji generatora";
    public const string WireResMeas = "Pomiar rezystancji przewodów";
    public const string ShockProtection = "Sprawdzenie ochrony przeciwporażeniowej";

    public const string SupervisionTest = "Sprawdzenie telemechaniki";
    public const string ProtectionTest = "Sprawdzenie zabezpieczeń geneneratora";
    public const string EnergyQuality = "Pomiary jakości energii";
    public const string Ncrfg = "Test zgodności z NCRfG i IRiESD";

}
