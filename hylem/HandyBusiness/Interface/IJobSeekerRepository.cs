using HandyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.Interface
{
    public interface IJobSeekerRepository
    {
        List<JobSeeker> GetAllJobSeekers();
    }
}
