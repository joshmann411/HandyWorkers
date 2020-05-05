using HandyBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.Models
{
    public class SqlBusinessRepository : IBusinessRepository
    {
        private readonly HylemDbContext context;

        //logger outstanding
        public SqlBusinessRepository(HylemDbContext context)
        {
            this.context = context;
        }

        public Business AddBusiness(Business business)
        {
            context.businesses.Add(business);
            context.SaveChanges();
            return business;
        }

        public Business DeleteBusiness(int id)
        {
            Business business = context.businesses.Find(id);

            if(business != null)
            {
                //do not delete data without keeping backup
                context.businesses.Remove(business);
                context.SaveChanges();
            }
            return business;
        }

        public IEnumerable<Business> GetAllBusinesses()
        {
            return context.businesses;
        }

        public Business GetBusiness(int id)
        {
            return context.businesses.Find(id);
        }

        public Business UpdateBusiness(Business businessChanges)
        {
            //attach 'the object containing the changes' to 'business property of the context obj'
            //save the entityentry of business
            var business = context.businesses.Attach(businessChanges);

            //tell EF that the entity we have has been modifed
            // we do that by setting the state to modified
            business.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return businessChanges;
        }
    }
}
