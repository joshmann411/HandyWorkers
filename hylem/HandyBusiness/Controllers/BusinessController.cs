using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandyBusiness.Interface;
using HandyBusiness.Models;
using HandyBusiness.ViewModels;
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

        [HttpGet]
        public IActionResult CreateBusiness()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBusiness(CreateBusinessViewModel model)
        {
            if(ModelState.IsValid)
            {
                Business newBusiness = new Business()
                {
                    Name = model.Name,
                    Emails = model.Emails,
                    Phones = model.Phones,
                    NoOfStaffs = model.NoOfStaffs,
                    Province = model.Province,
                    City = model.City,
                    Country = model.Country,
                    AddressLine = model.AddressLine,
                    PostalCode = model.PostalCode,
                    Sectors = model.Sectors,
                    Likes = model.Likes,
                    Dislikes = model.Dislikes
                };

                _businessRepository.AddBusiness(newBusiness);

                return RedirectToAction("details", new { id = newBusiness.Id });
            }

            return View();
        }
    }
}