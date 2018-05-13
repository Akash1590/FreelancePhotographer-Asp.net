using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
   public class PriceDetail
    {
        [Key]
        public int PriceDetailId { get; set; }

        public int Fk_PhotoGrapher_ID { get; set; }

        [Required]
        public String Catagory { get; set; }

        [Required]
        public String Details { get; set; }

        [Required]
        public String Price { get; set; }






    }
}
