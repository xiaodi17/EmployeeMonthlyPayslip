using EmployeeMonthlyPayslip.Models;
using EmployeeMonthlyPayslip.Service;
using Xunit;

namespace EmployeeMonthlyPayslip.Test
{
    public class TaxCalculatorTests
    {
        private readonly MonthlyTaxCalculator _monthlyTaxCalculator;

        public TaxCalculatorTests()
        {
            _monthlyTaxCalculator = new MonthlyTaxCalculator();
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