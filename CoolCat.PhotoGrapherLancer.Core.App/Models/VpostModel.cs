using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolCat.PhotoGrapherLancer.Core.App.Models
{
    public class VpostModel
    {
        public ClientJobsPost JobPostList{ get; set; }
        public JobsInterested JobInterestList { get; set; }
        public PhotoGrapher PhotoGrapherList { get; set; }

    }
}