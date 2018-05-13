using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.Client
{
   public class ClientJobsPost
    {
        [Key]
        public int PostId {get; set;}

        [Required]
         [ForeignKey("Clients")]
        public int FkClientID { get; set; }  //This IsClientID  ForeignKey From Client Table

        [Required]
        public string Title { get; set; }

     
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime HireDate { get; set; }

        [Required]
        public string HireTime { get; set; }

        [Required]
        public string payment { get; set; }   //Negotable or/amount


        [Required]
        public string Description { get; set; }



        [Required]
        public string Address { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public int Phone { get; set; }



        //[InverseProperty("ClientJobsPosts")]
        public  Client Clients { get; set; }    //Which Client Post the Jobs Invidual

       
    }
}
