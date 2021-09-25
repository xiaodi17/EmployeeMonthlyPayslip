using System;
using EmployeeMonthlyPayslip.Models.Interface;
using EmployeeMonthlyPayslip.Service;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeMonthlyPayslip
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<EmployeeMonthlyPayslip>().Execute();
            DisposeServices();
        }
        
        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ITaxCalculator, MonthlyTaxCalculator>();
            services.AddSingleton<EmployeeMonthlyPayslip>();
            _serviceProvider = services.BuildServiceProvider(true);
        }
        
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}