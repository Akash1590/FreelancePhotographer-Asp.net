using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPhotoGrapherServiceInterface
{
   public interface IPhotoGrapherPhotoGallaryService
    {

        #region //Upload photo to the Gallary

        //Get All Upload Photo By Photographer Id
        //This Id Is The PhotoGrapher Id 
        IEnumerable<PhotoUploadGallary> Get_All_Gallary_Photo(int id);

        //client Show Public Gallary Photo only public Photo
        IEnumerable<PhotoUploadGallary> Get_All_Gallary_Photo_Public(int id);

        //Details Single Image
        PhotoUploadGallary PhotoDetails(int photoId);



        //Upload Photo Gallary
        bool Upload_Photo_Gallary(PhotoUploadGallary upload, HttpPostedFileBase File);


        //Update when Image In Public or private
        //Only Update On field Shared Coloum public/Private
        bool UpdateGallaryPhoto(PhotoUploadGallary UpdatePhoto);

        #endregion

    }
}
