using EmployeeMonthlyPayslip.Models;
using EmployeeMonthlyPayslip.Models.Interface;

namespace EmployeeMonthlyPayslip.Service
{
    public abstract class TaxCalculatorBase: ITaxCalculator
    {
        public ITaxThreshold TaxThreshold { get; set; }
        public decimal MonthlyGrossIncome { get; set; }
        public decimal MonthlyIncomeTax { get; set; }
        public decimal MonthlyNetIncome { get; set; }

        public void Calculate(Employee employee)
        {
            MonthlyGrossIncome = CalculateGrossMonthlyIncome(employee.AnnualSalary);
            MonthlyIncomeTax = CalculateMonthlyIncomeTax(employee.AnnualSalary);
            MonthlyNetIncome = MonthlyGrossIncome - MonthlyIncomeTax;
        }

        public decimal CalculateGrossMonthlyIncome(decimal annualSalary)
        {
            return annualSalary / 12;
        }

        public abstract decimal CalculateMonthlyIncomeTax(decimal annualSalary);
    }
}