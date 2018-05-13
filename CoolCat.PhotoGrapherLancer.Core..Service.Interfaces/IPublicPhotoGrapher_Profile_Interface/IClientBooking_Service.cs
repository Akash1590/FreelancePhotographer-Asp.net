using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPublicPhotoGrapher_Profile_Interface
{
   public interface IClientBooking_Service
    {


        //Get All Booking Show By Admin

        IEnumerable<PhotoGrapherBooking> GelALLBooking();



        //PhtoGrapher All Booking List By PhotoGrapher ID
        IEnumerable<PhotoGrapherBooking> GetBooking(int id);  //PhotoGrapher ID


        //Booking List By Client
        IEnumerable<PhotoGrapherBooking> GetBooking_Client_Show(int id);  //Client ID


        //PhotoGrapher Booking By Client Save Database Table
        bool AddBooking(PhotoGrapherBooking Booked);

    }
}
