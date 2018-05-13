using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher
{
    public class ClientComplain
    {
        [Key]
        public int ComplainId { get; set; }

        public int Fk_ClientID { get; set; }  //Victim client

        public int Fk_PhotoGrapherID { get; set; }  //Complained photographer

        public string VictimName { get; set; }

        public string PhotographerName { get; set; }

        public string Message { get; set; }

    }
}
