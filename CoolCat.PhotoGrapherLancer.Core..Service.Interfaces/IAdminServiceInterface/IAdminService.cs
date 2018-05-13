using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IAdminServiceInterface
{
   public interface IAdminService
    {
        //Get All Client
        IEnumerable<Client> GetallClient();

        //Client Profile
        Client GetClient(int id);

        IEnumerable<Admin> GetallAdmin();

        Admin GetAdmin(int id);



        //Get All PhotoGrapher
        IEnumerable<PhotoGrapher> GetAll();

        //PhotoGrapher Details By Id
        //This Is The Get Id Then All type Of Details Fetch by This ID 
         PhotoGrapher GetPhotoGrapher(int id);
         PhotoGrapherBasicProfile GetPhotoGrapherbasic(int id);

    }
}
