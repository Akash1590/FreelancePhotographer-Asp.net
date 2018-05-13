using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.Client
{
    class ClientResetPassword
    {
        [Required(ErrorMessage = "New password required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New password and confirm password does not match")]
        [Required(ErrorMessage = "Confirm password required", AllowEmptyStrings = false)]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Required]
        public string ResetCode { get; set; }     //This Field Hidden For view PAge Come From DataBase
    }
}
