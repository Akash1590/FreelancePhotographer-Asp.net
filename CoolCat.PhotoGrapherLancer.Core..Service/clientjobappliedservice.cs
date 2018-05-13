using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IClientServiceInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;

namespace CoolCat.PhotoGrapherLancer.Core.Service
{
    public class clientjobappliedservice : IclientJobapplyservice
    {
        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();
        public bool Addapplied(JobApplied apply)
        {
            Db.JobApplieds.Add(apply);
            Db.SaveChanges();
            return true;

        }
        public IEnumerable<JobApplied> Getallapplys()
        {
            return Db.Set<JobApplied>().ToList();
        }
    }
}
