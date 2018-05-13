using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.Admin
{
    public class Admin
    {
        // This iS The Admin Model

        
            [Key]
            public int AdminId { get; set; }


            [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
            public string Name { get; set; }



            [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }


            [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
            public string Password { get; set; }



            [Display(Name = "Confirm Password")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
            [NotMapped]
            public string ConfirmPassword { get; set; }



            //  [Range(11, 11, ErrorMessage = "At Least 11 And Max 11")]
            public int? Phone { get; set; }                 //Nullable Bydefault ?(nullable)

            public string Address { get; set; }              //NullAble Bydefault 

            public string ResetPasswordCode { get; set; }    // NullAble Bydefault 

            public string ImagePath { get; set; }            // NullAble Bydefault 


        }

    }

