using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher
{
   public class PhotoGrapherBooking
    {
        [Key]
        public int BookingID { get; set; }

        public int Fk_Client_Id { get; set; }    //This Is The client Id From Client Table


        public int Fk_PhotoGrapher_Id { get; set; }    //This Is The client Id From Client Table


        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

       // [ Range(11, 11, ErrorMessage = "At Least 11 And Max 11")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number  is required")]
        public int Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Date  is required")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime PreferedDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Prefered Day  is required")]
        public string PreferedDay { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Prefered Time  is required")]
        public string PreferedTime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Appointment For  is required")]
        public string AppointmentFor { get; set; }



    }
}
