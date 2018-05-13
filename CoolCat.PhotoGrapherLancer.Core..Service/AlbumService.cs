using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPhotoGrapherServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using System.Data.Entity;
using System.Web;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;
using System.IO;

namespace CoolCat.PhotoGrapherLancer.Core.Service
{
    public class AlbumService : IPhotoGrapherAlbumService
    {


        PhotoGraphyDbContext Db=new PhotoGraphyDbContext();

        //public AlbumService(DbContext context)
        //{

        //    Db = context;

        //}

        //Create Album
        public bool CreateAlbum(Album create, HttpPostedFileBase File)
        {
            string filename = Path.GetFileNameWithoutExtension(File.FileName);
            string extension = Path.GetExtension(File.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            create.ImagePath = "~/Content/Image/Albam/" + filename;
            filename = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Image/Albam/"), filename);
            File.SaveAs(filename);
         //   create.Status = "Public";

            Db.Set<Album>().Add(create);
            Db.SaveChanges();
            return true;
        }
        
        //get all Albam by phohgrapher id
        public IEnumerable<Album> GetALL(int id)
        {
            return Db.Set<Album>().Where(x => x.Fk_PhotoGrapher_ID == id).OrderByDescending(x=>x.AlbamID).ToList();
        }



        //add Album Photo
        public bool Add_Albam_Photo(AlbamPhoto add, HttpPostedFileBase File)
        {
            string filename = Path.GetFileNameWithoutExtension(File.FileName);
            string extension = Path.GetExtension(File.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            add.ImagePath = "~/Content/Image/AlbamPhoto/" + filename;
            filename = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Image/AlbamPhoto/"), filename);

            File.SaveAs(filename);


            Db.Set<AlbamPhoto>().Add(add);
            Db.SaveChanges();
            return true;
        }

        //Get All Album Photo 
        public IEnumerable<AlbamPhoto> GetAll_Albam_Photo(int AlbamId)
        {
            return Db.Set<AlbamPhoto>().Where(x => x.Albam_ID == AlbamId).OrderByDescending(x => x.AlbamPhotoID).ToList();
        }
    }
}
