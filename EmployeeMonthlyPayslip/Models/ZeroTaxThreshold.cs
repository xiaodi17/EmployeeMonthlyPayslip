using EmployeeMonthlyPayslip.Models.Interface;

namespace EmployeeMonthlyPayslip.Models
{
    public class ZeroTaxThreshold: ITaxThreshold
    {
        public decimal MinThreshold { get; set; } = 0;
        public decimal MaxThreshold { get; set; } = 2000;
        public decimal ThresholdRate { get; set; } = 0;
    }
}