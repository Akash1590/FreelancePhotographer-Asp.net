using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
   public class PhotoGraphyType
    {
        [Key]
        public int TypeID { get; set; }

        public string PhotoGraphyTypes { get; set; }

      public List<PhotoGrapherPhotoGraphyType> Types { get; set;}

    }
}
