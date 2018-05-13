using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
   public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }
        public string ExperienceName { get; set; }

        public List<PhotoGrapherExperience> Experiences { get; set; }
    }
}
