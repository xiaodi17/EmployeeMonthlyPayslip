namespace EmployeeMonthlyPayslip.Models.Interface
{
    public interface ITaxCalculator
    {
        ITaxThreshold TaxThreshold { get; set; }
    }
}