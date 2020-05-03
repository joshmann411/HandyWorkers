using HandyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.Interface
{
    public interface IBusinessRepository
    {
        //get specific business
        Business GetBusiness(int id);
        
        //Get all businesses
        IEnumerable<Business> GetAllBusinesses();
        
        //Add a new Business
        Business AddBusiness(Business business);

    }
}
