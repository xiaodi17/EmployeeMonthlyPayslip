using System;
using System.Collections.Generic;
using Xunit;

namespace EmployeeMonthlyPayslip.Test
{
    public class EmployeeMonthlyPayslipInputTest
    {
        private readonly EmployeeMonthlyPayslip _payslip;

        public EmployeeMonthlyPayslipInputTest(EmployeeMonthlyPayslip payslip)
        {
            _payslip = payslip;
        }

        [Theory]
        [MemberData(nameof(ValidTestData))]
        public void Input_Test_Valid(string input)
        {
            var result = _payslip.IsValidCommand(input, out var employee);
            Assert.True(result);
        }
        
        public static IEnumerable<Object[]> ValidTestData()
        {
            yield return new object[] { "GenerateMonthlyPayslip \"David Lu\" 100000" };
            yield return new object[] { "GenerateMonthlyPayslip \"David Ding Lu\" 123456" };
            yield return new object[] { "GenerateMonthlyPayslip \"\" 1" };
            yield return new object[] { "GenerateMonthlyPayslip \"David Lu\" 100000.00" };
            yield return new object[] { "GenerateMonthlyPayslip \"David Lu\"    100000.00" };
        }

        [Theory]
        [MemberData(nameof(InValidTestData))]
        public void Input_Test_Invalid(string input)
        {
            var result = _payslip.IsValidCommand(input, out var employee);
            Assert.False(result);
        }
        
        public static IEnumerable<Object[]> InValidTestData()
        {
            yield return new object[] { "GenerateMonthlyPayslip \"David Ding Lu\" asdf" };
            yield return new object[] { "GenerateMonthlyPayslip \"\" asd123" };
            yield return new object[] { "GenerateMonthlyPayslip \"David Lu\" 100000.00 10000" };
            yield return new object[] { "GenerateMonthlyPayslip \"David Lu\" 100000.00 asdf" };
        }
    }
}