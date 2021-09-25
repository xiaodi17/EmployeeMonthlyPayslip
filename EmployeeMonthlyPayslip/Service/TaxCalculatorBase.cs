using System;
using EmployeeMonthlyPayslip.Models;
using EmployeeMonthlyPayslip.Models.Interface;
using EmployeeMonthlyPayslip.Service.Interface;

namespace EmployeeMonthlyPayslip.Service
{
    public abstract class TaxCalculatorBase: ITaxCalculator
    {
        public decimal MonthlyGrossIncome { get; set; }
        public decimal MonthlyIncomeTax { get; set; }
        public decimal MonthlyNetIncome { get; set; }

        public void Calculate(Employee employee)
        {
            MonthlyGrossIncome = CalculateGrossMonthlyIncome(employee.AnnualSalary);
            MonthlyIncomeTax = CalculateMonthlyIncomeTax(employee.AnnualSalary);
            MonthlyNetIncome = Math.Round(MonthlyGrossIncome - MonthlyIncomeTax, 2);
        }

        public decimal CalculateGrossMonthlyIncome(decimal annualSalary)
        {
            return Math.Round(annualSalary / 12, 2);
        }

        public abstract decimal CalculateMonthlyIncomeTax(decimal annualSalary);
    }
}