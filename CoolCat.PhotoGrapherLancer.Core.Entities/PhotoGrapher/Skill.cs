using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }

        public string SkillName { get; set; }

        public List<PhotoGrapherSkill> skills { get; set;}
    }
}
