using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
    public class PhotoGrapherExperience
    {
        [Key]
        public int Exp_ID { get; set; }


        public int Fk_PhotoGrapher_ID { get; set; }

        [ForeignKey("experinces")]
        public int ExperienceID { get; set; } //ForeignKey From Experience Entites


        public Experience experinces { get; set; }


    }
}
