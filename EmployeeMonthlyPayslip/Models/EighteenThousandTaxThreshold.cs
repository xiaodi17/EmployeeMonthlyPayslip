using EmployeeMonthlyPayslip.Models.Interface;

namespace EmployeeMonthlyPayslip.Models
{
    public class EighteenThousandTaxThreshold: ITaxThreshold
    {
        public decimal MinThreshold { get; set; } = 180000;
        public decimal MaxThreshold { get; set; } = decimal.MaxValue;
        public decimal ThresholdRate { get; set; } = 0.4m;
    }
}