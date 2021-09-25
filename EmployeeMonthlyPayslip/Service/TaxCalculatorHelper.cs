using EmployeeMonthlyPayslip.Models.Interface;

namespace EmployeeMonthlyPayslip.Service
{
    public static class TaxCalculatorHelper
    {
        public static bool IsGreaterThanMaxThreshold(decimal annualSalary, ITaxThreshold threshold)
        {
            return annualSalary >= threshold.MaxThreshold;
        }

        public static bool WithinThreshold(decimal annualSalary, ITaxThreshold threshold)
        {
            return annualSalary < threshold.MaxThreshold && annualSalary > threshold.MinThreshold;
        }
    }
}