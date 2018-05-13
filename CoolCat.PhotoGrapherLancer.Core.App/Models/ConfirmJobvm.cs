using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Entities.Admin;
using CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolCat.PhotoGrapherLancer.Core.App.Models
{
    public class ConfirmJobvm
    {
        public PhotoGrapher PhotoGrapher { get; set; }
        public Client client { get; set; }
        public ClientJobsPost jobpost { get; set; }
    }
}


