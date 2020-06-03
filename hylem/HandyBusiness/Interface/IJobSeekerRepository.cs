using HandyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.Interface
{
    public interface IJobSeekerRepository
    {
        //get specific business
        JobSeeker GetJobSeekerById(int id);

        //Get all businesses
        //IEnumerable<Business> GetAllBusinesses();
        List<JobSeeker> GetAllJobSeekers();

        //Add a new Business
        JobSeeker AddJobSeeker(JobSeeker jobSeeker);

        //Update existing
        JobSeeker UpdateJobSeeker(JobSeeker jobSeekerChanges);

        //This should almost never be used
        JobSeeker DeleteJobSeeker(int id);
    }
}
