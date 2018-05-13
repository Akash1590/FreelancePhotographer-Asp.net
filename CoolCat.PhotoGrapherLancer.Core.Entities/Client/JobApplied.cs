using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CoolCat.PhotoGrapherLancer.Core.Entities.Client
{
    public class JobApplied
    {
        [Key]
        public int AppliedId { get; set; }

        public int PhotoGrapherID { get; set; }   

        public int ClientId { get; set; }     

        public int PostId { get; set; }  

        public string ClientName { get; set; }

        public string PhotographerName { get; set; }

        public string Price { get; set; }

        public string Type { get; set; }

    }
}
