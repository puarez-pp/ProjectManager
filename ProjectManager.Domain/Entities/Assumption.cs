namespace ProjectManager.Domain.Entities;

public class Assumption
{
    public int Id { get; set; }
    public int SettlementId { get; set; }
    public Settlement Settlement { get; set; }
    public decimal MarginGen { get; set; }
    public decimal MarginInstall { get; set; }
    public decimal Discount { get; set; }
    public int Maturity { get; set; }
    public decimal CompanyCost { get; set; }
    public decimal CompanyGuarantee { get; set; }
    public decimal Insurance { get; set; }
}