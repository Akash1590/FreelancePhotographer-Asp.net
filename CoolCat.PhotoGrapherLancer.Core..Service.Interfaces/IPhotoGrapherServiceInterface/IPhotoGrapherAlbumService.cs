using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPhotoGrapherServiceInterface
{
    public interface IPhotoGrapherAlbumService
    {

        #region //Create Album

        //Get All Album by PhotoGrapherID
        IEnumerable<Album> GetALL(int id);

        //Create Album
        bool CreateAlbum(Album create, HttpPostedFileBase File);

        #endregion


        #region //Albam Photo


        //Get All This Albam Photo
        IEnumerable<AlbamPhoto> GetAll_Albam_Photo(int AlbamId);

        //Add Albam Photo By Albam Id
        bool Add_Albam_Photo(AlbamPhoto add, HttpPostedFileBase File);


        #endregion





    }
}
