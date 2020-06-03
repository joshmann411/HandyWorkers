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
                //build and update business image(s)
                List<BusinessPhotos> uniqueFilename = ProcessUploadedFile_s(model);

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
                    //Sectors = businessSector,
                    //businessEmployees = employeesPerBusiness,
                    Likes = model.Likes,
                    Dislikes = model.Dislikes,
                    businessPhotos = uniqueFilename
                };

                _businessRepository.AddBusiness(newBusiness);

                //return RedirectToAction("details", new { id = newBusiness.Id });
                return RedirectToAction("businesslisting");
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateBusiness")]
        public IActionResult UpdateBusiness(int id)
        {
            Business business = _businessRepository.GetBusiness(id);

            BusinessEditViewModel businessEditViewModel = new BusinessEditViewModel()
            {
                Id = business.Id,
                Name = business.Name,
                Email = business.Email,
                Phone = business.Phone,
                City = business.City,
                Country = business.Country,
                Province = business.Province,
                NoOfStaffs = business.NoOfStaffs,
                AddressLine = business.AddressLine,
                PostalCode = business.PostalCode,
                Likes = business.Likes,
                Dislikes = business.Dislikes,
                //BusinessProfilePhotoPath = business.businessPhotos.FirstOrDefault(x => x.Photo != string.Empty)
                BusinessProfilePhotoPath = business.businessPhotos[0].Photo
            };

            return View(businessEditViewModel);
        }

        [HttpGet]
        [Route("UpdateBusiness")]
        public IActionResult UpdateBusiness(BusinessEditViewModel model)
        {

            return View();
        }

        private List<BusinessPhotos> ProcessUploadedFile_s(BusinessCreateViewModel model)
        {
            string uniqueFilename = null;

            List<BusinessPhotos> allUploadedFiles = new List<BusinessPhotos>();

            if (model.Photos.Count > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", model.Name);

                var cd = Directory.CreateDirectory(uploadsFolder);

                foreach (IFormFile photo in model.Photos)
                {
                    uniqueFilename = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    allUploadedFiles.Add(new BusinessPhotos() { Photo = uniqueFilename }); ;
                    string filePath = Path.Combine(uploadsFolder, uniqueFilename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return allUploadedFiles;
        }

        private List<Models.Sector> ProcessUploadedSector_s(BusinessCreateViewModel model)
        {
            #warning Write logic to implement selected/added sector(s)

            return null;
        }

        
        //private List<Models.Employee> ProcessAddedEmployee_s(Models.Employee employee)
        private List<Models.Employee> ProcessAddedEmployee_s(BusinessCreateViewModel model)
        {
            #warning Add implementation for added employees
            
            return null;
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

            //BusinessDetailsViewModel
            EmployeeCreateViewModel empObj = new EmployeeCreateViewModel();

            BusinessDetailsViewModel businessDetailsViewModel = new BusinessDetailsViewModel()
            {
                business = ViewBusiness,
                employeeCreator = empObj
            };

            return View(businessDetailsViewModel);
        }
    }
}