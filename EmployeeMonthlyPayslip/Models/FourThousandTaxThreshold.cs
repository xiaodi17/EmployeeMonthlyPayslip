using EmployeeMonthlyPayslip.Models.Interface;

namespace EmployeeMonthlyPayslip.Models
{
    public class FourThousandTaxThreshold: ITaxThreshold
    {
        public decimal MinThreshold { get; set; } = 40000;
        public decimal MaxThreshold { get; set; } = 80000;
        public decimal ThresholdRate { get; set; } = 0.2m;
    }
}