using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.Admin
{
    public class Warn
    {
        [Key]
        public int WarnId { get; set; }
        public int Fk_PhotoGrapherID { get; set; }  //Complained photographer
        public string PhotographerName { get; set; }
    }
}
