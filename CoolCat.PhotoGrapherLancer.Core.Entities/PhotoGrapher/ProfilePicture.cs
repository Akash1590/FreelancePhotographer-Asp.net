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
    public class ProfilePicture
    {
        [Key]
        public int Pf_ID { get; set; }

        [ForeignKey("Pht")]
        public int Fk_PhotoGrapher_ID { get; set; }

       
        public string ImagePath { get; set; }      //possible null

        [DefaultValue("unset")]                     
        public string status { get; set; }          //when picture set status change to current

        public PhotoGrapher Pht { get; set; }


    }
}
