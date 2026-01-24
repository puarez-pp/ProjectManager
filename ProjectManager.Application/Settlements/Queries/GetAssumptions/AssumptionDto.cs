namespace ProjectManager.Application.Settlements.Queries.GetAssumptions;

public class AssumptionDto
{
    public int Id { get; set; }
    public decimal MarginGen { get; set; }
    public decimal MarginInstall { get; set; }
    public decimal Discount { get; set; }
    public int Maturity { get; set; }
    public decimal CompanyCost { get; set; }
    public decimal CompanyGuarantee { get; set; }
    public decimal Insurance { get; set; }
}