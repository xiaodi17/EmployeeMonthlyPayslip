using EmployeeMonthlyPayslip.Models.Interface;
using EmployeeMonthlyPayslip.Service;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeMonthlyPayslip.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITaxCalculator, MonthlyTaxCalculator>();
        }
    }
}