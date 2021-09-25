using EmployeeMonthlyPayslip.Models.Interface;

namespace EmployeeMonthlyPayslip.Models
{
    public class TwoThousandTaxThreshold: ITaxThreshold
    {
        public decimal MinThreshold { get; set; } = 20000;
        public decimal MaxThreshold { get; set; } = 40000;
        public decimal ThresholdRate { get; set; } = 0.1m;
    }
}