using HandyBusiness.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.ViewModels
{
    public class CreateBusinessViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid Email Format")]
        [Required]
        public List<BusinessEmails> Emails { get; set; }
        
        [Required]
        public List<BusinessPhones> Phones { get; set; }
        
        [Required]
        [Display(Name = "Number Of Staffs")]
        public int NoOfStaffs { get; set; }
        
        [Required]
        [Display(Name = "Province")]
        public string Province { get; set; }
        
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
        
        [Required]
        [Display(Name = "Address Line")]
        public string AddressLine { get; set; }
        
        [Required]
        [MaxLength(6, ErrorMessage = "Poastal Code can not exceed 6 characters")]
        public string PostalCode { get; set; }
        
        public List<Sector> Sectors { get; set; }
        
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
