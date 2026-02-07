using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class Device
{
    public int Id { get; set; }
    public DeviceType DeviceType { get; set; }
    public int PlantId { get; set; }
    public Plant Plant { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsConfigured { get; set; }
    public ICollection<Engine> LogEngines { get; set; } = new HashSet<Engine>();
    public ICollection<GasCounter> LogGasCounters { get; set; } = new HashSet<GasCounter>();
    public ICollection<HeatCounter> LogHeatCounters { get; set; } = new HashSet<HeatCounter>();
    public ICollection<ElectricCounter> LogElectricCounters { get; set; } = new HashSet<ElectricCounter>();
    public ICollection<OtherCounter> LogOtherCounters { get; set; } = new HashSet<OtherCounter>();
    public ICollection<DeviceHeader> DeviceHeaders { get; set; } = new HashSet<DeviceHeader>();
    public ICollection<Alarm> LogAlarms { get; set; } = new HashSet<Alarm>();
}
