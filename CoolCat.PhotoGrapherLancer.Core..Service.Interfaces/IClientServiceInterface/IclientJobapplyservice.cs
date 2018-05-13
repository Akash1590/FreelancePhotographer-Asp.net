using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;

namespace CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IClientServiceInterface
{
    public interface IclientJobapplyservice
    {
        bool Addapplied(JobApplied apply);
        IEnumerable<JobApplied> Getallapplys();
    }
}
