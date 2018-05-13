using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
   public class PhotoGrapherSkill
    {
        [Key]
        public int SkillsID { get; set; }


        public int Fk_PhotoGrapher_ID { get; set; }

        [ForeignKey("Skills")]
        public int SkillID { get; set; }  //Foreign Key from skill Table


        public Skill Skills { get; set; }
    }
}
