using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPhotoGrapherServiceInterface;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using System.Data.Entity;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;

namespace CoolCat.PhotoGrapherLancer.Core.Service
{
    public class PhotoGrapherSocialService : IPhotoGrapherSocialService
    {

        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();

        //DbContext Db;

        //public PhotoGrapherSocialService(DbContext context)
        //{

        //    Db = context;

        //} 

        #region //Follwers Region

        public IEnumerable<PhotoGrapherFollower> GetAllFollowers(int id)
        {
            return Db.Set<PhotoGrapherFollower>().Where(x => x.Fk_PhotoGrapher_ID == id).ToList();
        }

        public int TotalFollowers(int id)
        {
            // int ratting=0;

            var followers_list = Db.Set<PhotoGrapherFollower>().Where(x => x.Fk_PhotoGrapher_ID == id).Count();

            //    var follower = followers_list.Sum(x => x.Followers);


            return followers_list;
        }

        public bool AddFollowers(PhotoGrapherFollower Flw)
        {
            var client = Db.PhotoGrapherFollowers.Where(x => x.Fk_Client_id == Flw.Fk_Client_id && x.Fk_PhotoGrapher_ID == Flw.Fk_PhotoGrapher_ID).SingleOrDefault();

            if (client == null) {

                Db.Set<PhotoGrapherFollower>().Add(Flw);
                Db.SaveChanges();
                return true;

            }

            else
            {

                return false;
            }



        }



        #endregion

        #region //Following 

        public IEnumerable<PhotoGrapherFollowing> GetAllFollowing(int id)
        {
            return Db.Set<PhotoGrapherFollowing>().Where(x => x.Fk_PhotoGrapher_ID == id).ToList();
        }

        public int TotalFollowing(int id)
        {
            var following_list = Db.Set<PhotoGrapherFollowing>().Where(x => x.Fk_PhotoGrapher_ID == id).ToList();

            var following = following_list.Sum(x => x.Following);


            return following;
        }

        public bool AddFollowing(PhotoGrapherFollowing Flow)
        {
            Db.Set<PhotoGrapherFollowing>().Add(Flow);
            Db.SaveChanges();


            return true;
        }



        #endregion



        #region //Ratting Region
        //Total People Count
        public int Total_People_Ratting(int id)
        {
            var Total_People_list = Db.Set<PhotoGrapherRatting>().Where(x => x.Fk_PhotoGrapher_ID == id).ToList();

            var Total_People = Total_People_list.Sum(x => x.Fk_Client_id);

            return Total_People;
        }

        //Ratting ex:4.5
        public double TotalRatting(int id)
        {

            Double Result;



            var Total_People_list = Db.Set<PhotoGrapherRatting>().Where(x => x.Fk_PhotoGrapher_ID == id).Count();



            if (Total_People_list == 0)
            {

                return 0.0;
            }

            else {
                var Ratting_total = Db.Set<PhotoGrapherRatting>().Where(x => x.Fk_PhotoGrapher_ID == id).Sum(x => x.Ratting);



                Result = Math.Round((Ratting_total / Total_People_list), 1);




                return Result;
            }


        }
        public IEnumerable<PhotoGrapherRatting> GetallRatings()
        {
            
            return Db.Set<PhotoGrapherRatting>().ToList();

        }
            

        //Client Ratting Add
        public bool AddRatting(PhotoGrapherRatting Rat)
        {
            var client = Db.PhotoGrapherRattings.Where(x => x.Fk_Client_id == Rat.Fk_Client_id && x.Fk_PhotoGrapher_ID==Rat.Fk_PhotoGrapher_ID).SingleOrDefault();

            if (client == null)
            {
                Db.Set<PhotoGrapherRatting>().Add(Rat);
                Db.SaveChanges();


                return true;


            }

            else
            {
               
                return false;
            }
           
        }

        #endregion
    }
}
