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
    public DateTime CreatedDate { get; set; }
    public bool IsConfigured { get; set; }
    public ICollection<Engine> Engines { get; set; } = new HashSet<Engine>();
    public ICollection<GasCounter> GasCounters { get; set; } = new HashSet<GasCounter>();
    public ICollection<HeatCounter> HeatCounters { get; set; } = new HashSet<HeatCounter>();
    public ICollection<ElectricCounter> ElectricCounters { get; set; } = new HashSet<ElectricCounter>();
    public ICollection<OtherCounter> OtherCounters { get; set; } = new HashSet<OtherCounter>();
    public ICollection<DeviceHeader> DeviceHeaders { get; set; } = new HashSet<DeviceHeader>();
    public ICollection<Alarm> Alarms { get; set; } = new HashSet<Alarm>();
}
