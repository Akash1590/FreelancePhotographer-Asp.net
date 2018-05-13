using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Service.ServiceViewModel
{
    public  class AppliedPostViewModel
    {
        public ClientJobsPost JobPostList { get; set; }
        public JobsInterested JobInterestList { get; set; }
      
    }
}
