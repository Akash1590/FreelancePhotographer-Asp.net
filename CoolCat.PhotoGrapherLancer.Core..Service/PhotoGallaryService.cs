using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPhotoGrapherServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using System.Data.Entity;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;
using System.Web;
using System.IO;

namespace CoolCat.PhotoGrapherLancer.Core.Service
{
    public class PhotoGallaryService : IPhotoGrapherPhotoGallaryService
    {

        PhotoGraphyDbContext Db=new PhotoGraphyDbContext();

        //DbContext Db;

        //public PhotoGallaryService(DbContext context)
        //{
        //    Db = context;
        //}


        //Get All Gallary Photo By PhotoGrapher ID
        public IEnumerable<PhotoUploadGallary> Get_All_Gallary_Photo(int id)
        {
            return Db.Set<PhotoUploadGallary>().Where(x => x.Fk_PhotoGrapher_ID == id).ToList();

        }

        //All Public Photo Shared File
        public IEnumerable<PhotoUploadGallary> Get_All_Gallary_Photo_Public(int id)
        {

            return Db.Set<PhotoUploadGallary>().Where(x => x.Shared == "public").ToList();


        }

        //Single PhotoDetails
        public PhotoUploadGallary PhotoDetails(int photoId)
        {
            return Db.Set<PhotoUploadGallary>().Find(photoId);
        }


        //Add Photo
        public bool Upload_Photo_Gallary(PhotoUploadGallary upload, HttpPostedFileBase File)
        {
            string filename = Path.GetFileNameWithoutExtension(File.FileName);
            string extension = Path.GetExtension(File.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            upload.ImagePath = "~/Content/Image/GallaryPhoto/" + filename;
            filename = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Image/GallaryPhoto/"), filename);
            upload.Shared ="public";
            File.SaveAs(filename);


            Db.Set<PhotoUploadGallary>().Add(upload);
            Db.SaveChanges();
            return true;
        }

        //Update Gallary Photo
        public bool UpdateGallaryPhoto(PhotoUploadGallary UpdatePhoto)
        {

            Db.Entry(UpdatePhoto).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }
    }
}
