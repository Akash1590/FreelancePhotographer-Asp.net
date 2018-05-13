using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolCat.PhotoGrapherLancer.Core.App.Models
{
    public class photographerallprofilevm
    {
        public PhotoGrapher photoGrapher { get; set; }
        public PhotoGrapherBasicProfile photoGrapherBasicProfile { get; set; }
        public ProfilePicture p_Picture { get; set; }
    }
}
