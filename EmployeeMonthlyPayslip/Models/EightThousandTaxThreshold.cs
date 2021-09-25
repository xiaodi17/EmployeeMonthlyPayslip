using EmployeeMonthlyPayslip.Models.Interface;

namespace EmployeeMonthlyPayslip.Models
{
    public class EightThousandTaxThreshold: ITaxThreshold
    {
        public decimal MinThreshold { get; set; } = 80000;
        public decimal MaxThreshold { get; set; } = 180000;
        public decimal ThresholdRate { get; set; } = 0.3m;
    }
}