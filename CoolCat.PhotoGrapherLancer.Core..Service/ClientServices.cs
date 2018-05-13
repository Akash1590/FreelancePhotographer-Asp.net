using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IClientServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using System.Data.Entity;

using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPublicPhotoGrapher_Profile_Interface;
using CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;

namespace CoolCat.PhotoGrapherLancer.Core._.Service
{
    public class ClientServices : IClientServices
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


        //Client Registration
        public bool AddClient(Client Newclient)
        {
            Db.Clients.Add(Newclient);
            Db.SaveChanges();


            return true;

        }


        //Cliet Her Profile Update
        public bool EditClient(Client editclient)
        {
            //var client = Db.Clients.Where(x => x.ClientId == editclient.ClientId).FirstOrDefault();

            //client.Name = editclient.Name;
            //client.Phone = editclient.Phone;
            //client.Address = editclient.Address;
            //client.ImagePath = editclient.ImagePath;

            //Db.Configuration.ValidateOnSaveEnabled = false;
            Db.Entry(editclient).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }

        //Pass_Change Is Model Object This Objec Inside ClientID
        public bool ChangePassword(ChangePassword Pass_Change)
        {
            //Find The Client Object
            var obj = Db.Clients.Where(a => a.ClientId == Pass_Change.ClientId).FirstOrDefault();

            if (obj.Password == Pass_Change.CurrentPassword)
            {

                //new Password set
                obj.Password = Pass_Change.NewPassword;

                //Single Field Update
                Db.Configuration.ValidateOnSaveEnabled = false;

                Db.SaveChanges();
                return true;
            }

            else
            {

                return false;

            }
            

           
        }


        public bool DeleteClient(int deleteclient)
        {
            var complain = Db.Clients.Find(deleteclient);
            Db.Clients.Remove(complain);
            Db.SaveChanges();
            return true;
        }
       


        #endregion




    }
}
