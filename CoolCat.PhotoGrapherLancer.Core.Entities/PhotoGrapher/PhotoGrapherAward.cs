using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
     public class PhotoGrapherAward   //This Class Is The use for award/price compition
    {
        [Key]
        public int KeyAwardID { get; set; }


        public int Fk_PhotoGrapher_ID { get; set; }

        [ForeignKey("Awards")]
        public int AwardID { get; set; }


       public Award Awards { get; set; }



    }
}
