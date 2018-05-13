using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.Admin
{
    public class Block
    {
        [Key]
        public int BlockId { get; set; }
        public int Fk_PhotoGrapherID { get; set; }  
        public string PhotographerName { get; set; }
    }
}
