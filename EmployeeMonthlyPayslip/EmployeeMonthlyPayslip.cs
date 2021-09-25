using System;
using System.Linq;
using System.Text.RegularExpressions;
using EmployeeMonthlyPayslip.Models;
using EmployeeMonthlyPayslip.Models.Interface;

namespace EmployeeMonthlyPayslip
{
    public class EmployeeMonthlyPayslip
    {
        private readonly ITaxCalculator _monthlyTaxCalculator;

        public EmployeeMonthlyPayslip(ITaxCalculator monthlyTaxCalculator)
        {
            _monthlyTaxCalculator = monthlyTaxCalculator;
        }

        public void Execute()
        {
            try
            {
                //example input EmployeeMonthlyPayslip "Mary Song" 60000
                Console.WriteLine("Please enter a command");
                var command = Console.ReadLine();
                
                while (!string.Equals(command, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    switch (command.ToLower())
                    {
                        case var payslip when payslip.StartsWith("EmployeeMonthlyPayslip", StringComparison.OrdinalIgnoreCase):
                            if (IsValidCommand(command, out var employee))
                            {
                                _monthlyTaxCalculator.Calculate(employee);
                                Console.WriteLine($"employee: {employee.Name} gross income {_monthlyTaxCalculator.MonthlyGrossIncome}, tax income {_monthlyTaxCalculator.MonthlyIncomeTax}" +
                                                  $"net income: {_monthlyTaxCalculator.MonthlyNetIncome}");
                            }
                            break;
                        
                        default:
                            Console.WriteLine("Invalid Command");
                            break;
                    }
                    
                    command = Console.ReadLine();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            Console.WriteLine("Payslip calculator terminated");
        }

        private bool IsValidCommand(string command, out Employee employee)
        {
            employee = new Employee();
            
            //https://stackoverflow.com/questions/554013/regular-expression-to-split-on-spaces-unless-in-quotes/14892584
            var regex = new Regex(@"\w+|""[\w\s]*""");
            var inputs = regex.Matches(command).ToList();

            if (inputs.Count < 3)
            {
                Console.WriteLine("Wrong number of arguments.");
            }

            employee.Name = inputs[1].ToString();

            if (!decimal.TryParse(inputs[2].Value, out var salary))
            {
                Console.WriteLine("Invalid number format");
                return false;
            }

            employee.AnnualSalary = salary;
            return true;
        }
    }
}