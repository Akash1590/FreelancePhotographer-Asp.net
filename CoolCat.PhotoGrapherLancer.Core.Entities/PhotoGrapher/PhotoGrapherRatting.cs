using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
   public class PhotoGrapherRatting
    {

        [Key]
        public int RattingID { get; set; }      //Increment Automatic

        public double Ratting { get; set; }     //By Default Null Accepted

        public int Fk_Client_id { get; set; }  //which person Ratting

        public int Fk_PhotoGrapher_ID { get; set; }   //Foreign Key From PhotoGrapher.cs
    }
}
