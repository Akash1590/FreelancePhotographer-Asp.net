using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher
{
   public class ClientContact
    {
        [Key]
        public int ContactId { get; set; }

        public int Fk_PhotoGrapherID { get; set; }  //Whose Person The Contact


        public int Fk_ClientID { get; set; }  //Which Client Contact The PhotoGrapher


        //[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        //public string Name { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

       // [Range(11, 11, ErrorMessage = "At Least 11 And Max 11")]
        public int? Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Message is required")]
        //[MinLength(20,ErrorMessage = "Mimimum Type 20 character"),MaxLength(120, ErrorMessage = "Not Gretter Then 120 Character")]
        public String Message { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }






    }
}
