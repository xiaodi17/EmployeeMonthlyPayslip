using EmployeeMonthlyPayslip.Models;
using EmployeeMonthlyPayslip.Models.Interface;
using EmployeeMonthlyPayslip.Service;
using Xunit;

namespace EmployeeMonthlyPayslip.Test
{
    public class TaxCalculatorTests
    {
        private readonly ITaxCalculator _monthlyTaxCalculator;
        
        public TaxCalculatorTests(ITaxCalculator monthlyTaxCalculator)
        {
            _monthlyTaxCalculator = monthlyTaxCalculator;
        }

        [Fact]
        public void Monthly_Tax_Threshold_40K()
        {
            var employee = new Employee()
            {
                Name = "David",
                AnnualSalary = 60000m
            };
            
            _monthlyTaxCalculator.Calculate(employee);
            Assert.Equal(5000m, _monthlyTaxCalculator.MonthlyGrossIncome);
            Assert.Equal(500m, _monthlyTaxCalculator.MonthlyIncomeTax);
            Assert.Equal(4500m, _monthlyTaxCalculator.MonthlyNetIncome);
        }
    }
}