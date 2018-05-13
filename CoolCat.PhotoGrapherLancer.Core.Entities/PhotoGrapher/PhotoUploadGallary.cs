using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
    public class PhotoUploadGallary
    {
        [Key]
        public int PhotoID { get; set; }

        [ForeignKey("PhotoGrapher")]
        public int Fk_PhotoGrapher_ID { get; set; }


        public DateTime Date_time { get; set; }    //current date time when Activity Post

        [Required]
        public string ImagePath { get; set; }      //possible null

        [Required]
        public string Caption { get; set; }       //possible null

       
        public string Description { get; set; }

        public string CameraUsed { get; set; }

       [DefaultValue("Private")]
        public String Shared { get; set;}

        public int? Likes { get; set; }          
        
        
        public PhotoGrapher PhotoGrapher { get; set; }




    }
}
