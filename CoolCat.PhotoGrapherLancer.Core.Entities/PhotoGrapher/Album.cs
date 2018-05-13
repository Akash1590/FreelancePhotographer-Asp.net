using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
    public class Album
    {
        [Key]
        public int AlbamID { get; set; }

        public int Fk_PhotoGrapher_ID { get; set; }

       

        public string Caption { get; set; }

        public string ImagePath { get; set; }      //possible null

        public string Status { get; set; }







    }
}
