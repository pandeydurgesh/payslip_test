using PaySlip.DAL.CustomModels;
using PaySlip.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeePaySlip_Durgesh.Controllers
{
    public class PaySlipController : ApiController
    {
        IPaySlipService _paySlipService;
        public PaySlipController(IPaySlipService paySlipService)
        {
            _paySlipService = paySlipService;
        }

        [HttpPost]
        public HttpResponseMessage GetPaySlip(PaySlipInputModel paySlipInputModel)
        {

            try
            {
                if (paySlipInputModel == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Data provided in the request is not valid.");
                if (ModelState.IsValid)
                {
                    var result = _paySlipService.GetPaySlip(paySlipInputModel);
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else { return Request.CreateResponse(HttpStatusCode.BadRequest, "Data provided in the request is not valid."); }                

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }

        }
    }
}
