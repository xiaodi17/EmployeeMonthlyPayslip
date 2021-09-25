using System;
using System.Globalization;
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
                Console.WriteLine("This is a monthly payslip calculator.");
                Console.WriteLine("A valid command example: GenerateMonthlyPayslip \"Mary Song\" 60000");
                Console.WriteLine("Please enter a command: ");
                var command = Console.ReadLine();
                
                while (!string.Equals(command, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    switch (command.ToLower())
                    {
                        case var payslip when payslip.StartsWith("GenerateMonthlyPayslip", StringComparison.OrdinalIgnoreCase):
                            if (IsValidCommand(command, out var employee))
                            {
                                _monthlyTaxCalculator.Calculate(employee);
                                Console.WriteLine($"Employee: {employee.Name} " +
                                                  $"\ngross income {_monthlyTaxCalculator.MonthlyGrossIncome.ToString("c", CultureInfo.CurrentCulture)}" +
                                                  $"\ntax income {_monthlyTaxCalculator.MonthlyIncomeTax.ToString("c", CultureInfo.CurrentCulture)}" +
                                                  $"\nnet income: {_monthlyTaxCalculator.MonthlyNetIncome.ToString("c", CultureInfo.CurrentCulture)}");
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
            
            //Regex split string by space except space inside quotations
            //https://stackoverflow.com/questions/554013/regular-expression-to-split-on-spaces-unless-in-quotes/14892584
            var regex = new Regex(@"\w+|""[\w\s]*""");
            var inputs = regex.Matches(command).ToList();

            if (inputs.Count != 3)
            {
                Console.WriteLine("Wrong number of arguments.");
                return false;
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