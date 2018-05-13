using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
   public class PhotoGrapherPhotoGraphyType
    {

        [Key]
        public int TypesID { get; set; }


        public int Fk_PhotoGrapher_ID { get; set; }

        [ForeignKey("PhotoGraphyTypes")]
        public int TypeID { get; set; } //Foreign Key From PhotoGraphyType Table

        public PhotoGraphyType PhotoGraphyTypes { get; set;}

    }
}
