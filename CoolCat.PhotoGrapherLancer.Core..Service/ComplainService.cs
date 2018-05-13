using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPublicPhotoGrapher_Profile_Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;

namespace CoolCat.PhotoGrapherLancer.Core.Service
{
    public class ComplainService : IClientComplain
    {

        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();

        #region

        public IEnumerable<ClientComplain> GetAllcomplains()
        {
            return Db.Set<ClientComplain>().ToList();
        }

        public ClientComplain GetComplain_Details(int id)   //Get By Contact ID
        {
            var Get_Contact_Details = Db.Set<ClientComplain>().Where(x => x.ComplainId == id).FirstOrDefault();
            return Get_Contact_Details;
        }
        

       public bool AddComplain(ClientComplain Add_complain)
        {
            Db.Set<ClientComplain>().Add(Add_complain);
            Db.SaveChanges();
            return true;
        }
        public bool DeleteComplain(int Delete_complain)
        {
            var complain = Db.ClientComplains.Find(Delete_complain);
            Db.ClientComplains.Remove(complain);
            Db.SaveChanges();
            return true;
        }

        #endregion
    }
}
