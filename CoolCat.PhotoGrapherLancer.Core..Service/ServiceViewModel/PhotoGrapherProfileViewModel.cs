using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Service.ServiceViewModel
{
    public class PhotoGrapherProfileViewModel
    {

        public PhotoGrapher PhotoGrapher { get; set; }
        public PhotoGrapherBasicProfile Basic_Profile { get; set; }
        public List<PhotoGrapherAward> Award { get; set; }
        public List<PhotoGrapherExperience> Experience { get; set; }
        public List<PhotoGrapherSkill> Skill { get; set; }
        public List<PhotoGrapherPhotoGraphyType> type {get;set;}
        public PhotoGrapherFollower Follower { get; set; }
        public PhotoGrapherFollowing Following { get; set; }


        public List<Skill>sk { get; set;}
        public List<Experience> ex { get; set;}
        public List<Award> aw { get; set; }
        public List<PhotoGraphyType> ty { get; set; }

        public List<Album> Albams { get; set; }
        public List<AlbamPhoto> AlbamPhotos { get; set; }
        public List<PhotoUploadGallary> Gallary { get; set;}
        public ProfilePicture p_Picture { get; set; }
        public List<PriceDetail> priceDetail { get; set;}

        public List<ProfilePicture>ProfilepictureList { get; set; }


    }



}
