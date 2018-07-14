using EmployeePaySlip_Durgesh.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaySlip.DAL.CustomModels;
using PaySlip.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace EmployeePaySlip_Durgesh.Tests.Controllers
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void Test_GetPayslip_1()
        {
            var payslipController = new PaySlipController(new PaySlipService());

            var employee = new PaySlipInputModel()
            {
                FirstName = "Durgesh",
                LastName = "Pandey",
                AnualSalary = 60050,
                PaymentStartDate = (new DateTime(2018, 03, 01)).ToShortDateString(),
                SuperRate = 9
            };



            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();

            var response = payslipController.GetPaySlip(employee);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            PaySlipModel paySlip;
            Assert.IsTrue(response.TryGetContentValue<PaySlipModel>(out paySlip));
                   
            Assert.IsNotNull(paySlip);
            Assert.AreEqual(5004, paySlip.GrossIncome);
            Assert.AreEqual(922, paySlip.IncomeTax);
            Assert.AreEqual(4082, paySlip.NetIncome);
            Assert.AreEqual(450, paySlip.SuperAmount);
        }


        [TestMethod]
        public void Test_GetPayslip_2()
        {
            var payslipController = new PaySlipController(new PaySlipService());
            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();
            var employee = new PaySlipInputModel()
            {
                FirstName = "Durgesh",
                LastName = "Pandey",
                AnualSalary = 120000,
                PaymentStartDate = (new DateTime(2018, 03, 01)).ToShortDateString(),
                SuperRate = 10
            };

            var response = payslipController.GetPaySlip(employee);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            PaySlipModel paySlip;
            Assert.IsTrue(response.TryGetContentValue<PaySlipModel>(out paySlip));
            Assert.IsNotNull(paySlip);
            Assert.AreEqual(10000, paySlip.GrossIncome);
            Assert.AreEqual(2669, paySlip.IncomeTax);
            Assert.AreEqual(7331, paySlip.NetIncome);
            Assert.AreEqual(1000, paySlip.SuperAmount);

        }

        [TestMethod]
        public void Test_GetPayslip_3()
        {
            var payslipController = new PaySlipController(new PaySlipService());
            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();


            var employee = new PaySlipInputModel()
            {
                FirstName = "Durgesh",
                LastName = "Pandey",
                AnualSalary = 10000,
                PaymentStartDate = (new DateTime(2018, 06, 30)).ToShortDateString(),
                SuperRate = 0
            };

            PaySlipModel paySlip;
            var response = (HttpResponseMessage)payslipController.GetPaySlip(employee);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(response.TryGetContentValue<PaySlipModel>(out paySlip));
            Assert.IsNotNull(paySlip);
            Assert.AreEqual(833, paySlip.GrossIncome);
            Assert.AreEqual(0, paySlip.IncomeTax);
            Assert.AreEqual(833, paySlip.NetIncome);
            Assert.AreEqual(0, paySlip.SuperAmount);

        }

        [TestMethod]
        public void Test_GetPayslip_4()
        {
            var payslipController = new PaySlipController(new PaySlipService());
            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();
            var employee = new PaySlipInputModel()
            {
                FirstName = "Durgesh",
                LastName = "Pandey",
                AnualSalary = 20000,
                PaymentStartDate = (new DateTime(2018, 06, 30)).ToShortDateString(),
                SuperRate = 3
            };
            var response = payslipController.GetPaySlip(employee);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            PaySlipModel paySlip;
            Assert.IsTrue(response.TryGetContentValue<PaySlipModel>(out paySlip));
            Assert.IsNotNull(paySlip);
            Assert.AreEqual(1667, paySlip.GrossIncome);
            Assert.AreEqual(28, paySlip.IncomeTax);
            Assert.AreEqual(1639, paySlip.NetIncome);
            Assert.AreEqual(50, paySlip.SuperAmount);           
        }

        [TestMethod]
        public void Test_GetPayslip_5()
        {
            var payslipController = new PaySlipController(new PaySlipService());
            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();
            var employee = new PaySlipInputModel()
            {
                FirstName = "Durgesh",
                LastName = "Pandey",
                AnualSalary = 200000,
                PaymentStartDate =(new DateTime(2018, 06, 30)).ToShortDateString(),
                SuperRate = 3
            };

            PaySlipModel paySlip;
            var response = payslipController.GetPaySlip(employee);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(response.TryGetContentValue<PaySlipModel>(out paySlip));
            Assert.IsNotNull(paySlip);
            Assert.AreEqual(16667, paySlip.GrossIncome);
            Assert.AreEqual(5269, paySlip.IncomeTax);
            Assert.AreEqual(11398, paySlip.NetIncome);
            Assert.AreEqual(500, paySlip.SuperAmount);
        }

        [TestMethod]
        public void NegativeTest_GetPayslip1()
        {
            var payslipController = new PaySlipController(new PaySlipService());
            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();
            var response = (payslipController.GetPaySlip(null));

            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }
        [TestMethod]
        public void NegativeTest_GetPayslip2()
        {
            var payslipController = new PaySlipController(new PaySlipService());
            payslipController.Request = new HttpRequestMessage();
            payslipController.Configuration = new HttpConfiguration();
            var employee = new PaySlipInputModel()
            {
                FirstName = "Durgesh",
                LastName = "Pandey",
                AnualSalary = -200,
                PaymentStartDate = (new DateTime(2018, 06, 30)).ToShortDateString(),
                SuperRate = -3
            };

            var response = (payslipController.GetPaySlip(employee));

            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.InternalServerError);
        }
    }
}
