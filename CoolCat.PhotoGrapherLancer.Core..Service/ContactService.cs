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
   public class ContactService: IClientContact_Service
    {

        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();

        //DbContext Db;

        //public ContactService(DbContext context)
        //{

        //    Db = context;

        //}

        #region //Client Contract PhotoGrapher

        //Admin All The Contact List
        public IEnumerable<ClientContact> AllGetContact()
        {
            return Db.Set<ClientContact>().ToList();
        }

        //PhotoGrapher Get  Single Contact Details
        public ClientContact GetContact_Details(int id)
        {
            var Get_Contact_Details = Db.Set<ClientContact>().Where(x => x.ContactId == id).FirstOrDefault();
            return Get_Contact_Details;
        }


        //PhotoGrapher Get All Contact List
        public IEnumerable<ClientContact> Get_All_PhotoGrapher_Contact(int id)
        {
            var Contact_List = Db.Set<ClientContact>().Where(x => x.Fk_PhotoGrapherID == id).ToList();

            return Contact_List;
        }


        public bool AddContact(ClientContact Add_Contact)
        {
            Db.Set<ClientContact>().Add(Add_Contact);
            Db.SaveChanges();
            return true;
        }

        #endregion
    }
}
