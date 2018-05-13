using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IAdminServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Entities.Admin;
using System.Data.Entity;

using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPublicPhotoGrapher_Profile_Interface;
using CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;



namespace CoolCat.PhotoGrapherLancer.Core.Service
{
    public class AdminService:IAdminService
    {
        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();

        #region // Client Service
        //Get All Client Fetch By Admin
        public IEnumerable<Client> GetallClient()
        {
            return Db.Clients.ToList();
        }
        //Single Client Details
        public Client GetClient(int id)
        {
            var obj_Client = Db.Clients.Find(id);

            return obj_Client;
        }
        public IEnumerable<Admin> GetallAdmin()
        {
            return Db.Admins.ToList();
        }

        public Admin GetAdmin(int id)
        {
            var obj_admin = Db.Admins.Find(id);
            return obj_admin;
        }

       public IEnumerable<PhotoGrapher> GetAll()
        {
            return Db.PhotoGraphers.ToList();
        }

        public  PhotoGrapherBasicProfile GetPhotoGrapherbasic(int id )
        {

            var obj = Db.PhotoGrapherBasicProfiles.Find(id);
            
            return obj;
        }
        public PhotoGrapher GetPhotoGrapher(int id)
        {
            var obj = Db.PhotoGraphers.Find(id);
            return obj;
        }
        #endregion


    }
}
