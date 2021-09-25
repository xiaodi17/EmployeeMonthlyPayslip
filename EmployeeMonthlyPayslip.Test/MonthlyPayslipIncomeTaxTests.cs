using System;
using EmployeeMonthlyPayslip.Service;
using Xunit;

namespace EmployeeMonthlyPayslip.Test
{
    public class MonthlyPayslipIncomeTaxTests
    {
        private readonly MonthlyTaxCalculator _monthlyTaxCalculator;

        public MonthlyPayslipIncomeTaxTests()
        {
            _monthlyTaxCalculator = new MonthlyTaxCalculator();
        }

        [Fact]
        public void Tax_Threshold_Zero()
        {
            var result = _monthlyTaxCalculator.CalculateMonthlyIncomeTax(12);
            Assert.Equal(0m, result);
        }
        
        [Fact]
        public void Tax_Threshold_20K()
        {
            var result = _monthlyTaxCalculator.CalculateMonthlyIncomeTax(30000);
            Assert.Equal(83.33m, result);
        }
        
        [Fact]
        public void Tax_Threshold_40K()
        {
            var result = _monthlyTaxCalculator.CalculateMonthlyIncomeTax(60000);
            Assert.Equal(500m, result);
        }
        
        [Fact]
        public void Tax_Threshold_80K()
        {
            var result = _monthlyTaxCalculator.CalculateMonthlyIncomeTax(90000);
            Assert.Equal(1083.33m, result);
        }
        
        [Fact]
        public void Tax_Threshold_180K()
        {
            var result = _monthlyTaxCalculator.CalculateMonthlyIncomeTax(200000);
            Assert.Equal(4000m, result);
        }
    }
}