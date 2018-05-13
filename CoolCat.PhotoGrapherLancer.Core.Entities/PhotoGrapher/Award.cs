using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
    public  class Award
    {
        [Key]
        public int AwardID { get; set; }

        public string AwardName { get; set; }

        public virtual List<PhotoGrapherAward> PhotoGrapherAwards { get; set; }  //Indivisual Client Post




    }
}
