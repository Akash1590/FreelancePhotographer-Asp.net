using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IAdminServiceInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.Admin;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;

namespace CoolCat.PhotoGrapherLancer.Core.Service
{
    public class WarnService : IWarnService
    {
        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();

        #region

        public IEnumerable<Warn> GetAllWarns()
        {
            return Db.Set<Warn>().ToList();
        }

        public Warn GetWarn_Details(int id)   //Get By Contact ID
        {
            var Get_Contact_Details = Db.Set<Warn>().Where(x => x.WarnId == id).FirstOrDefault();
            return Get_Contact_Details;
        }


        public bool AddWarnMemer(Warn Add_warn)
        {
            Db.Set<Warn>().Add(Add_warn);
            Db.SaveChanges();
            return true;
        }
        public bool Deletewarn(int Delete_complain)
        {
            var complain = Db.Warns.Find(Delete_complain);
            Db.Warns.Remove(complain);
            Db.SaveChanges();
            return true;
        }

        #endregion
    }
}
