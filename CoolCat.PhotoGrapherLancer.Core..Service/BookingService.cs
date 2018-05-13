using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPublicPhotoGrapher_Profile_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher;
using System.Data.Entity;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;

namespace CoolCat.PhotoGrapherLancer.Core.Service
{
    public class BookingService : IClientBooking_Service
    {

        //DbContext Db;

        //public BookingService(DbContext context)
        //{

        //    Db = context;

        //}

        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();


        #region //PhotoGrapher Booking Service
        //get all Booking list
        public IEnumerable<PhotoGrapherBooking> GelALLBooking()
        {
            return Db.Set<PhotoGrapherBooking>().ToList();
        }

        //PhotoGrapher All The List Who Is Booked
        public IEnumerable<PhotoGrapherBooking> GetBooking(int id)
        {
            var BookingList = Db.Set<PhotoGrapherBooking>().Where(x => x.Fk_PhotoGrapher_Id == id).ToList();

            return BookingList;
        }

        //CLient All The List Who Is Booked
        public IEnumerable<PhotoGrapherBooking> GetBooking_Client_Show(int id)
        {
            var Client_BookingList = Db.Set<PhotoGrapherBooking>().Where(x => x.Fk_Client_Id == id).ToList();

            return Client_BookingList;
        }


        public bool AddBooking(PhotoGrapherBooking Booked)
        {
            Db.Set<PhotoGrapherBooking>().Add(Booked);
            Db.SaveChanges();
            return true;
        }



        #endregion
    }
}
