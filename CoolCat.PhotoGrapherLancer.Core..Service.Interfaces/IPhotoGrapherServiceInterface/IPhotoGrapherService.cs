using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPhotoGrapherServiceInterface
{
    public interface IPhotoGrapherService
    {

        #region // PhotoGrapher Basic Profile

        //Get All PhotoGrapher
        IEnumerable<PhotoGrapher> GetAll();


        //PhotoGrapher Details By Id
        //This Is The Get Id Then All type Of Details Fetch by This ID 
        PhotoGrapher GetPhotoGrapher(int id);



        //Add PhotoGrapher When Register Basic Item
        //When Add Another Table Update PhotoGrapher_Basic_Profile Only Id Update
        bool AddPhotoGrapher(PhotoGrapher pht_Add);


        //Basic PhotoGrapher Additional Profile Item Edit View
        //This Id Is photoGrapher Id
        PhotoGrapherBasicProfile GetBasicProfile(int id);       


        //Add PhotoGrapher Additional Profile Item
        bool Update_Profile_Item(PhotoGrapherBasicProfile BasicAdd);

        bool Deletephotographer(int deletephotographer);


        #endregion



        #region //PhotoGrapher Experience Region


        //Add Experience
        bool AddExperience(PhotoGrapherExperience Exp);

        //Get Experience List By User Id
        //This The PhotoGrapher ID Fetch All Experience This Id And Reurn List
        IEnumerable<PhotoGrapherExperience> GetExperience(int id);


        //Update View 
        //This Id Experience ID
        bool UpdateExperience(PhotoGrapherExperience ExpUpdate,int id); 

        #endregion




        #region //PhotoGrapher Skill Region


        //Add Experience
        bool AddSkill(PhotoGrapherSkill Add_Skill);

        //Get Experience List By User Id
        //This The PhotoGrapher ID Fetch All Experience This Id And Reurn List
        IEnumerable<PhotoGrapherSkill> GetSkill(int id);


        //Update View 
        //This Id Skill ID
        bool UpdateSkill(PhotoGrapherSkill UpSkill, int id);  

        #endregion



        #region //PhotoGrapher Award Region


        //Add Experience
        bool AddAward(PhotoGrapherAward Add_Award);

        //Get Experience List By User Id
        //This The PhotoGrapher ID Fetch All Award This Id And Reurn List
        IEnumerable<PhotoGrapherAward> GetAward(int id);


        //Update View 
        //This Id Award ID
        bool UpdateAward(PhotoGrapherAward UpAward, int id);

        #endregion


        #region //PhotoGrapher PhotoGarphy Type Region


        //Add Experience
        bool AddPhotoGraphy_Type(PhotoGrapherPhotoGraphyType Add_Type);

        //Get Experience List By User Id
        //This The PhotoGrapher ID Fetch All Experience This Id And Reurn List
        IEnumerable<PhotoGrapherPhotoGraphyType> GetPhotoGraphy_Type(int id);


        //Update View 
        //This Id Skill ID
        bool UpdatePhotoGraphy_Type(PhotoGrapherPhotoGraphyType UpType, int id);

        #endregion




        #region //Price Details Section Add


        //All PriceDetails by photoGrapherid
        //This Id PhotoGrapher id
        IEnumerable<PriceDetail> GetAll(int id);


        //Get Price Details Invidual Id
        //Price Id get Invidual id of the row
        PriceDetail GetDetails(int priceId);



        //Add Price Details
        bool AddPrice(PriceDetail Add_Price);


        //Update Price details 
        bool UpdatePriceDetails(PriceDetail UpPrice);

        #endregion



        #region  //Change Profile Picture


        //Get All Profile Picture By photoGrapher Id
        //This id PhotoGrapher Id
        IEnumerable<ProfilePicture> Get_All_ProfilePicture(int id);
        
        //current Profile Picture
        ProfilePicture CurrentProfilePicture(int id);

        //Add Profile Picture
        bool Add_Profile_Picture(ProfilePicture chng, HttpPostedFileBase File, int id);

        //Active Profile Picture
        //This picture id update status (set) And This PhotoGrapher Other Profile Picture Status unset
        bool Active_Profile_Picture(int id, int PictureID);





        #endregion

        #region //Change Password

        //Password Change 
        bool ChangePassword(PhotoGrapherChangePassword Pass_Change);
        #endregion





    }
}
