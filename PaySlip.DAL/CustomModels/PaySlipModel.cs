using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlip.DAL.CustomModels
{
    public class PaySlipModel
    {
        public string Name { get; set; }
        public string PayPeriod { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetIncome { get; set; }
        public decimal SuperAmount { get; set; }
    }
    public class PaySlipInputModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public decimal AnualSalary { get; set; }
        [Required]
        public decimal SuperRate { get; set; }
        [Required]
        public string PaymentStartDate { get; set; }
   
    }
}
