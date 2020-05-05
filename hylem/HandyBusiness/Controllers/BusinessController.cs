using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HandyBusiness.Interface;
using HandyBusiness.Models;
using HandyBusiness.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandyBusiness.Controllers
{
    [Route("Business")]
    public class BusinessController : Controller
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BusinessController(IBusinessRepository businessRepository,
                                    IWebHostEnvironment webHostEnvironment)
        {
            _businessRepository = businessRepository;
            _webHostEnvironment = webHostEnvironment;
            //inject _IBusinessRepository

            //inject logger
        }

        [Route("BusinessListing")]
        public IActionResult BusinessListing()
        {
            var model = _businessRepository.GetAllBusinesses();

            return View(model);
        }

        [HttpGet]
        [Route("CreateBusiness")]
        public IActionResult CreateBusiness()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateBusiness")]
        public IActionResult CreateBusiness(BusinessCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                List<BusinessPhotos> uniqueFilename = ProcessUploadedFile(model);

                Business newBusiness = new Business()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    NoOfStaffs = model.NoOfStaffs,
                    Province = model.Province,
                    City = model.City,
                    Country = model.Country,
                    AddressLine = model.AddressLine,
                    PostalCode = model.PostalCode,
                    Sectors = model.Sectors,
                    Likes = model.Likes,
                    Dislikes = model.Dislikes,
                    Photos = uniqueFilename
                };

                _businessRepository.AddBusiness(newBusiness);

                return RedirectToAction("details", new { id = newBusiness.Id });
            }

            return View();
        }

        private List<BusinessPhotos> ProcessUploadedFile(BusinessCreateViewModel model)
        {
            string uniqueFilename = null;

            List<BusinessPhotos> allUploadedFiles = new List<BusinessPhotos>();

            if (model.Photos.Count > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", model.Name);

                var cd = Directory.CreateDirectory(uploadsFolder);

                int counter = 1;
                foreach (IFormFile photo in model.Photos)
                {
                    uniqueFilename = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    allUploadedFiles.Add(new BusinessPhotos() { Id = counter, Photo = uniqueFilename }); ;
                    string filePath = Path.Combine(uploadsFolder, uniqueFilename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                    counter++;
                }
            }

            return allUploadedFiles;
        }
        

        [Route("Details/{id?}")]
        public ViewResult Details(int? id)
        {
            Business ViewBusiness = _businessRepository.GetBusiness(id.Value);

            if (ViewBusiness == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            BusinessDetailsViewModel businessDetailsViewModel = new BusinessDetailsViewModel()
            {
                business = ViewBusiness,
                pageTitle = "Business Details"
            };

            return View(businessDetailsViewModel);
        }
    }
}