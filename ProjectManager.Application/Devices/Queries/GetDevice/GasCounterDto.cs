using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Devices.Queries.GetDevice;

public class GasCounterDto : IDeviceParam
{
    public int Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public float Parametr1 { get; set; }
    public float Parametr2 { get; set; }
    public float Parametr3 { get; set; }
    public float Parametr4 { get; set; }
    public float Parametr5 { get; set; }
    public long Parametr6 { get; set; }
    public long Parametr7 { get; set; }
    public long Parametr8 { get; set; }
    public long Parametr9 { get; set; }
    public long Parametr10 { get; set; }
}
