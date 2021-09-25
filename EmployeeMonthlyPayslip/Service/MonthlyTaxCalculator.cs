using System;
using System.Collections.Generic;
using EmployeeMonthlyPayslip.Models;
using EmployeeMonthlyPayslip.Models.Interface;

namespace EmployeeMonthlyPayslip.Service
{
    public class MonthlyTaxCalculator: TaxCalculatorBase
    {
        private readonly List<ITaxThreshold> _thresholds = new List<ITaxThreshold>()
        {
            new ZeroTaxThreshold(),
            new TwoThousandTaxThreshold(),
            new FourThousandTaxThreshold(),
            new EightThousandTaxThreshold(),
            new EighteenThousandTaxThreshold(),
        };
        
        public override decimal CalculateMonthlyIncomeTax(decimal annualSalary)
        {
            var annualTax = 0m;
            
            foreach(var threshold in _thresholds)
            {
                if (TaxCalculatorHelper.IsGreaterThanMaxThreshold(annualSalary, threshold))
                {
                    annualTax += (threshold.MaxThreshold - threshold.MinThreshold) * threshold.ThresholdRate;
                }
                else if (TaxCalculatorHelper.WithinThreshold(annualSalary, threshold))
                {
                    annualTax += (annualSalary - threshold.MinThreshold) * threshold.ThresholdRate;
                }
            }

            return Math.Round(annualTax / 12, 2);
        }
    }
}