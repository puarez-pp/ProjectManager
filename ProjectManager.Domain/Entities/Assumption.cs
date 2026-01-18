namespace ProjectManager.Domain.Entities;

public class Assumption
{
    public int Id { get; set; }
    public int SettlementId { get; set; }
    public Settlement Settlement { get; set; }
    public float MarginGen { get; set; }
    public float MarginInstall { get; set; }
    public float Discount { get; set; }
    public int Maturity { get; set; }
    public float CompanyCost { get; set; }
    public float CompanyGuarantee { get; set; }
    public float Insurance { get; set; }
}