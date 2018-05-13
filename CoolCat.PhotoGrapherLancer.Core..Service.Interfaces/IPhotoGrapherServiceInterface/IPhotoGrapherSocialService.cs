using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPhotoGrapherServiceInterface
{
   public interface IPhotoGrapherSocialService
    {

        #region //This Region Basically Follower 

        //Get All Follower List By PhotoGrapher ID
        //Thsi id PhotoGrapher Id

        IEnumerable<PhotoGrapherFollower> GetAllFollowers(int id);

        //Count Total Followers
        //Thsi id PhotoGrapher Id
        int TotalFollowers(int id);     


        //Save Followers
        //Check Condition 1 Client only one time Follow
        bool AddFollowers(PhotoGrapherFollower Flw); 

        #endregion



        #region //This Region Basically Following

        //Get All Follower List By PhotoGrapher ID
        //Thsi id PhotoGrapher Id
        IEnumerable<PhotoGrapherFollowing> GetAllFollowing(int id);

        //Count Total Followers
        //Thsi id PhotoGrapher Id
        int TotalFollowing(int id);    


        //Save Following
        //Check Condition 1 Client only one time Follow
        bool AddFollowing(PhotoGrapherFollowing Flow);

        #endregion


        #region //This Region Basically Ratting

        //count All The People Which Is Rating this PhotoGrapher
        int Total_People_Ratting(int id);


        //Count Total Followers
        //Sum All Rating Point And Calculation And Return Value
        //Thsi id PhotoGrapher Id
        Double TotalRatting(int id);


        //Save Ratting
        //Check Condition 1 Client only one time Ratting Next Time Update
        bool AddRatting(PhotoGrapherRatting Rat);
        IEnumerable<PhotoGrapherRatting> GetallRatings();

        #endregion 




    }
}
