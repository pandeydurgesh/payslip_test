using PaySlip.DAL.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlip.Services
{
    public interface IPaySlipService
    {
        PaySlipModel GetPaySlip(PaySlipInputModel paySlipInputModel);
    }

    
    public class PaySlipService: IPaySlipService
    {
        public PaySlipService()
        {
        }
     
        public PaySlipModel GetPaySlip(PaySlipInputModel paySlipInputModel) {
            decimal tax = 0;
            if (paySlipInputModel.AnualSalary < 0) {
                throw new Exception("Salary should be greater than 0");
            }
            paySlipInputModel.AnualSalary = Math.Round(paySlipInputModel.AnualSalary, 1);
            if (paySlipInputModel.AnualSalary > 0 && paySlipInputModel.AnualSalary <= 18200) {
                tax = 0;
            }
            if (paySlipInputModel.AnualSalary > 18200)
            {
                decimal taxableAmount;
                taxableAmount = paySlipInputModel.AnualSalary <= 37000? paySlipInputModel.AnualSalary - 18200:  (37000- 18200);
                tax += taxableAmount * (decimal)(19.0 / 100);
                if (paySlipInputModel.AnualSalary > 37000) {
                    taxableAmount = paySlipInputModel.AnualSalary <= 87000 ? paySlipInputModel.AnualSalary - 37000 :  (87000 - 37000);
                    tax += taxableAmount * (decimal)(32.5 / 100);
                    if (paySlipInputModel.AnualSalary > 87000)
                    {
                        taxableAmount = paySlipInputModel.AnualSalary <= 180000 ? paySlipInputModel.AnualSalary - 87000 : (180000 - 87000);
                        tax += taxableAmount * (decimal)(37.0 / 100);
                        if (paySlipInputModel.AnualSalary > 180000)
                        {
                            taxableAmount = paySlipInputModel.AnualSalary - 180000;
                            tax += taxableAmount * (decimal)(45.0 / 100);
                        }
                    }
                }
                
            }
            return new PaySlipModel {
                GrossIncome = Math.Round(paySlipInputModel.AnualSalary / 12, 0)
                , IncomeTax = Math.Round(tax/12,0)
                , NetIncome= Math.Round(paySlipInputModel.AnualSalary / 12, 0)- Math.Round(tax / 12, 0)
                , SuperAmount = Math.Round((paySlipInputModel.AnualSalary / 12)* (paySlipInputModel.SuperRate/100),0)
                ,Name= paySlipInputModel.FirstName+" "+ paySlipInputModel.LastName
                , PayPeriod= paySlipInputModel.PaymentStartDate
            };


        }
    }
}
