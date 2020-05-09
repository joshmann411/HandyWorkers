using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.ViewModels
{
    public class BusinessEditViewModel : BusinessCreateViewModel, ISector, IEmployee
    {
        //-----Implement ISector
        string ISector.SectorName { get; set; }
        int ISector.OperatingYear { get; set; }
        int ISector.OperatingMonth { get; set; }
        double ISector.ChargesPerHour { get; set; }
        //Implementation Ends

        //-----Implement IEmployee
        string IEmployee.IdNumber { get; set; }
        string IEmployee.Firstname { get; set; }
        string IEmployee.Lastname { get; set; }
        string IEmployee.Email { get; set; }
        string IEmployee.CellNo { get; set; }
        string IEmployee.Gender { get; set; }
        string IEmployee.DateOfBirth { get; set; }
        //Implementation Ends

        public int Id { get; set; }
        public string BusinessProfilePhotoPath { get; set; }
    }
}
