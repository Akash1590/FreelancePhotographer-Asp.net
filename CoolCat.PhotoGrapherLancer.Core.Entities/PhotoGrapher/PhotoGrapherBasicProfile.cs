using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
   public class PhotoGrapherBasicProfile
    {
        [Key]
        public int ProfileID { get; set; }

        public int Fk_PhotoGrapher_ID { get; set; }

        public string Education { get; set; }

        public string Address { get; set; }

      //  [Range(11, 11, ErrorMessage = "At Least 11 And Max 11")]
        public string   Phone { get; set; }

        public string Notes { get; set; }








    }
}
