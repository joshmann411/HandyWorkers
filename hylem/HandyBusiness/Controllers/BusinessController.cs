using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandyBusiness.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HandyBusiness.Controllers
{
    public class BusinessController : Controller
    {
        private readonly IBusinessRepository _businessRepository;

        public BusinessController(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
            //inject _IBusinessRepository

            //inject logger
        }

        public IActionResult BusinessListing()
        {
            var model = _businessRepository.GetAllBusinesses();

            return View(model);
        }
    }
}