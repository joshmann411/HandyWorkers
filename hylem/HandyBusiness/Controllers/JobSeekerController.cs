using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandyBusiness.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HandyBusiness.Controllers
{
    public class JobSeekerController : Controller
    {
        private readonly IJobSeekerRepository _jobSeekerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public JobSeekerController(IJobSeekerRepository jobSeekerRepository,
                                    IWebHostEnvironment webHostEnvironment)
        {
            _jobSeekerRepository = jobSeekerRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult JobSeekersList()
        {
            var model = _jobSeekerRepository.GetAllJobSeekers();

            return View(model);
        }

        public IActionResult AddJobSeeker()
        {
            return View();
        }
    }
}