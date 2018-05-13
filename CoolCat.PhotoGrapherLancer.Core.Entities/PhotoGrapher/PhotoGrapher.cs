using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
    public  class PhotoGrapher
    {

        [Key]
        public int PhotoGrapherId { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName is required")]
        public string UserName { get; set; }


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




        public string ResetPasswordCode { get; set; }    // NullAble Bydefault 









    }
}
