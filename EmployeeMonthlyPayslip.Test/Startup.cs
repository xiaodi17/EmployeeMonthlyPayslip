using EmployeeMonthlyPayslip.Models.Interface;
using EmployeeMonthlyPayslip.Service;
using EmployeeMonthlyPayslip.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeMonthlyPayslip.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITaxCalculator, MonthlyTaxCalculator>();
            services.AddTransient<EmployeeMonthlyPayslip>();
        }
    }
}