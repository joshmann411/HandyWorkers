using HandyBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.Models
{
    public class SqlJobSeekersRepository : IJobSeekerRepository
    {
        private readonly HylemDbContext context;

        public SqlJobSeekersRepository(HylemDbContext context)
        {
            this.context = context;     
        }

        public JobSeeker AddJobSeeker(JobSeeker jobSeeker)
        {
            context.jobSeekers.Add(jobSeeker);
            context.SaveChanges();
            return jobSeeker;
        }

        public JobSeeker DeleteJobSeeker(int id)
        {
            JobSeeker jobSeeker = context.jobSeekers.Find(id);

            if (jobSeeker != null)
            {
                //do not delete data without keeping backup
                context.jobSeekers.Remove(jobSeeker);
                context.SaveChanges();
            }
            return jobSeeker;
        }

        public List<JobSeeker> GetAllJobSeekers()
        {
            return context.jobSeekers.ToList();
        }

        public JobSeeker GetJobSeekerById(int id)
        {
            return context.jobSeekers.FirstOrDefault(x => x.Id == id);
        }

        public JobSeeker UpdateJobSeeker(JobSeeker jobSeekerChanges)
        {
            throw new NotImplementedException();
        }
    }
}
