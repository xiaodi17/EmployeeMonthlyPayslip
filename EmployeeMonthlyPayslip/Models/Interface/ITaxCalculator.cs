namespace EmployeeMonthlyPayslip.Models.Interface
{
    public interface ITaxCalculator
    {
        public decimal MonthlyGrossIncome { get; set; }
        public decimal MonthlyIncomeTax { get; set; }
        public decimal MonthlyNetIncome { get; set; }
        decimal CalculateMonthlyIncomeTax(decimal annualSalary);
        void Calculate(Employee employee);
    }
}