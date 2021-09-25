namespace EmployeeMonthlyPayslip.Models.Interface
{
    public interface ITaxThreshold
    {
        public decimal MinThreshold { get; set; }
        public decimal MaxThreshold { get; set; }
        public decimal ThresholdRate { get; set; }
    }
}