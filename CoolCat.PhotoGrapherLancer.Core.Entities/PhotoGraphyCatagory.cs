using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities
{
  public  class PhotoGraphyCatagory
    {
        [Key]
        public int CatagoryID { get; set; }

        [Required]
        public string  CatagoryName { get; set; }


        public string CatagoryDescrip { get; set; }


    }
}
