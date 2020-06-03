using HandyBusiness.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.ViewModels
{
    public class EmployeeCreateViewModel
    {
        //Id number
        [MaxLength(13, ErrorMessage = "Length cannot exceed 13 characters")]
        [Display(Name = "ID Number")]
        public string IdNumber { get; set; }

        //Firstname
        [MaxLength(50, ErrorMessage = "Length cannot exceed 13 characters")]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        //Lastname
        [MaxLength(50, ErrorMessage = "Length cannot exceed 13 characters")]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        //Email
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        //Cell Number
        [Display(Name = "Phone Number")]
        public string CellNo { get; set; }
        
        //Gender
        [MaxLength(7)]
        public Gender? Gender { get; set; }

        //Date Of Birth
        public string DateOfBirth { get; set; }

        public IFormFile PhotoPath { get; set; }
        public int businessId { get; set; }
        [ForeignKey("businessId")]
        public Business business { get; set; }
    }
}
