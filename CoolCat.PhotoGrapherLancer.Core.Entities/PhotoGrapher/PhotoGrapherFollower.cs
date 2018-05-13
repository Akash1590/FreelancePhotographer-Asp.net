using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher
{
   public class PhotoGrapherFollower
    {
        [Key]
        public int FollowerID { get; set; }      //Increment Automatic

       // public int Followers { get; set; }     //By Default Null Accepted

        public int Fk_Client_id { get; set; }  //which person follow

        public int Fk_PhotoGrapher_ID { get; set; }   //Foreign Key From PhotoGrapher.cs





    }
}
