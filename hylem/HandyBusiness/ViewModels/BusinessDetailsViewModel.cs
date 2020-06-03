using HandyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.ViewModels
{
    public class BusinessDetailsViewModel
    {
        public Business business { get; set; }
        public EmployeeCreateViewModel employeeCreator { get; set; }
    }
}
