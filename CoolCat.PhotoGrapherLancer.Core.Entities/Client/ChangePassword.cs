using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.Client
{
   public  class ChangePassword
    {

        [Required(ErrorMessage = "CurrentPassword password required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        //[MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New password and confirm password does not match")]
        [Required(ErrorMessage = "Confirm password required", AllowEmptyStrings = false)]
        
        public string ConfirmPassword { get; set; }

        [Required]  //That is The Hidden
        public int ClientId { get; set; }
    }
}
