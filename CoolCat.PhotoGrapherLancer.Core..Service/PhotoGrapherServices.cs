using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPhotoGrapherServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using System.Data.Entity;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;
using System.Web;
using System.IO;

namespace CoolCat.PhotoGrapherLancer.Core.Service
{
    public class PhotoGrapherServices : IPhotoGrapherService
    {
        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();


        //DbContext Db;

        //public PhotoGrapherServices(DbContext context)
        //{

        //    Db = context;

        //}


        //Get All PhotoGrapher
        public IEnumerable<PhotoGrapher> GetAll()
        {
            throw new NotImplementedException();
        }

        //PhotoGrapher Profile
        public PhotoGrapher GetPhotoGrapher(int id)
        {
            throw new NotImplementedException();
        }

        //When Register PhotoGrapher Add
        public bool AddPhotoGrapher(PhotoGrapher pht_Add)
        {
            Db.Set<PhotoGrapher>().Add(pht_Add);
           // Add_basicProfile(pht_Add.Email);
            Db.SaveChanges();

          





            return true;

        }

        //PhotoGrapher Change Password
        public bool ChangePassword(PhotoGrapherChangePassword Pass_Change)
        {
            //Find The Client Object
            var obj = Db.Set<PhotoGrapher>().Where(a => a.PhotoGrapherId == Pass_Change.PhotoGrapherId).FirstOrDefault();

            if (obj.Password == Pass_Change.CurrentPassword)
            {

                //new Password set
                obj.Password = Pass_Change.NewPassword;

                //Single Field Update
                Db.Configuration.ValidateOnSaveEnabled = false;

                Db.SaveChanges();
                return true;
            }

            else
            {

                return false;

            }
        }


        #region //Profile Picture Region


        //Get All Profile Picture List PhotGrapher
        public IEnumerable<ProfilePicture> Get_All_ProfilePicture(int id)
        {
            return Db.Set<ProfilePicture>().Where(x => x.Fk_PhotoGrapher_ID == id).ToList();
        }


        //Current Profile Picture Show
        public ProfilePicture CurrentProfilePicture(int id)
        {
            var Change_Profile_Picture = Db.Set<ProfilePicture>().Where(x => x.Fk_PhotoGrapher_ID == id && x.status == "set").FirstOrDefault();
            return Change_Profile_Picture;

        }


        //Profile picture Change Add To Database 
        public bool Add_Profile_Picture(ProfilePicture chng, HttpPostedFileBase File, int id)
        {
            string filename = Path.GetFileNameWithoutExtension(File.FileName);
            string extension = Path.GetExtension(File.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            chng.ImagePath = "~/Content/Image/ProfileImage/" + filename;
            filename = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Image/ProfileImage/"), filename);
            chng.Fk_PhotoGrapher_ID = id;
            chng.status = "Deactive";
            File.SaveAs(filename);


            Db.Set<ProfilePicture>().Add(chng);
            Db.SaveChanges();

            return true;
        }

        public bool Deletephotographer(int deletephotographer)
        {
            var complain = Db.PhotoGraphers.Find(deletephotographer);
            Db.PhotoGraphers.Remove(complain);
            Db.SaveChanges();
            return true;
        }


        //Change Current Profile Picture
        public bool Active_Profile_Picture(int id, int PictureID)
        {
            var set_Staus_check = Db.Set<ProfilePicture>().Where(x => x.Fk_PhotoGrapher_ID == id && x.status == "Deactive").FirstOrDefault();
            var Pht_Grapher = Db.Set<ProfilePicture>().Where(x => x.Fk_PhotoGrapher_ID == id && x.Pf_ID == PictureID).FirstOrDefault();

            if (Pht_Grapher != null)
            {

                //new Password set
                Pht_Grapher.status = "Deactive";//Present set Profile Picture
                set_Staus_check.status = "Active"; //Previous which set Preset Unset


                //Single Field Update
                Db.Configuration.ValidateOnSaveEnabled = false;

                Db.SaveChanges();
                return true;



            }

            else
            {

                return false;
            }

        }

        #endregion


        #region //PhotoGrapher Award Region

        //Get All Award PhotoGrapher
        public IEnumerable<PhotoGrapherAward> GetAward(int id)
        {
            var get_All_award = Db.Set<PhotoGrapherAward>().Where(x => x.Fk_PhotoGrapher_ID == id).ToList();
            return get_All_award;
        }


        public bool AddAward(PhotoGrapherAward Add_Award)
        {
            Db.Set<PhotoGrapherAward>().Add(Add_Award);
            Db.SaveChanges();
            return true;

        }

        //Award Update 
        public bool UpdateAward(PhotoGrapherAward UpAward, int id)
        {
            var find_single_Award = Db.Set<PhotoGrapherAward>().Find(id);
            if (find_single_Award != null)
            {

                Db.Entry(UpAward).State = EntityState.Modified;
                Db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion


        #region //PhotoGrapher Experience region

        //Get All Experience
        public IEnumerable<PhotoGrapherExperience> GetExperience(int id)
        {
            var get_All_ExpList = Db.Set<PhotoGrapherExperience>().Where(x => x.Fk_PhotoGrapher_ID == id).ToList();
            return get_All_ExpList;
        }



        //Add Experience
        public bool AddExperience(PhotoGrapherExperience Exp)
        {
            Db.Set<PhotoGrapherExperience>().Add(Exp);
            Db.SaveChanges();


            return true;

        }

        //Update Experience
        public bool UpdateExperience(PhotoGrapherExperience ExpUpdate, int id)
        {
            var find_single_Exp = Db.Set<PhotoGrapherExperience>().Find(id);
            if (find_single_Exp != null)
            {

                Db.Entry(ExpUpdate).State = EntityState.Modified;
                Db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion


        #region //Skill Region
        //Get All Skill
        public IEnumerable<PhotoGrapherSkill> GetSkill(int id)
        {
            var get_All_SkillKist = Db.Set<PhotoGrapherSkill>().Where(x => x.Fk_PhotoGrapher_ID == id).ToList();
            return get_All_SkillKist;
        }

        //Add Skill
        public bool AddSkill(PhotoGrapherSkill Add_Skill)
        {
            Db.Set<PhotoGrapherSkill>().Add(Add_Skill);
            Db.SaveChanges();


            return true;
        }

        //Update Skill
        public bool UpdateSkill(PhotoGrapherSkill UpSkill, int id)
        {
            var find_single_skill = Db.Set<PhotoGrapherSkill>().Find(id);
            if (find_single_skill != null)
            {

                Db.Entry(UpSkill).State = EntityState.Modified;
                Db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region //Type Of Catagory


        //Get All Type PhotoGraphy 
        public IEnumerable<PhotoGrapherPhotoGraphyType> GetPhotoGraphy_Type(int id)
        {
            var get_All_type = Db.Set<PhotoGrapherPhotoGraphyType>().Where(x => x.Fk_PhotoGrapher_ID == id).ToList();
            return get_All_type;
        }

        public bool AddPhotoGraphy_Type(PhotoGrapherPhotoGraphyType Add_Type)
        {
            Db.Set<PhotoGrapherPhotoGraphyType>().Add(Add_Type);
            Db.SaveChanges();


            return true;
        }

        public bool UpdatePhotoGraphy_Type(PhotoGrapherPhotoGraphyType UpType, int id)
        {
            var find_single_type = Db.Set<PhotoGrapherPhotoGraphyType>().Find(id);
            if (find_single_type != null)
            {

                Db.Entry(UpType).State = EntityState.Modified;
                Db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }



        #endregion


        #region //Price Catagory

        //Get All Price List
        public IEnumerable<PriceDetail> GetAll(int id)
        {
            return Db.Set<PriceDetail>().Where(x => x.Fk_PhotoGrapher_ID == id).ToList();
        }

        //Add
        public bool AddPrice(PriceDetail Add_Price)
        {
            Db.Set<PriceDetail>().Add(Add_Price);
            Db.SaveChanges();


            return true;
        }





        public bool UpdatePriceDetails(PriceDetail UpPrice)
        {
            Db.Entry(UpPrice).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }


        public PriceDetail GetDetails(int priceId)
        {
            return Db.Set<PriceDetail>().Find(priceId);
        }



        #endregion



        #region //PhotoGrahper Basic Profile

        public PhotoGrapherBasicProfile GetBasicProfile(int id)
        {
            return Db.Set<PhotoGrapherBasicProfile>().Find(id);
        }

        //Update By default All Field Null
        public bool Update_Profile_Item(PhotoGrapherBasicProfile BasicAdd)
        {

            var user = Db.PhotoGrapherBasicProfiles.Where(x => x.Fk_PhotoGrapher_ID == BasicAdd.Fk_PhotoGrapher_ID).FirstOrDefault();

            if (user != null)
            {

                user.Fk_PhotoGrapher_ID = BasicAdd.Fk_PhotoGrapher_ID;
                user.Education = BasicAdd.Education;
                user.Address = BasicAdd.Address;
                user.Phone = BasicAdd.Phone;
                user.Notes = BasicAdd.Notes;

                Db.SaveChanges();
                return true;
            }

            else
            {

                return false;
            }


            // Db.Entry(BasicAdd).State = EntityState.Modified;

        }



        public bool Add_basicProfile(int id)
        {
            var user = Db.PhotoGrapherBasicProfiles.Where(x => x.Fk_PhotoGrapher_ID ==id).FirstOrDefault();

            

            if (user == null)
            {
                PhotoGrapherBasicProfile p = new PhotoGrapherBasicProfile();
                p.Fk_PhotoGrapher_ID =id;
                p.Address = "";
                p.Education = "";
                p.Phone = "";

                Db.PhotoGrapherBasicProfiles.Add(p);
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
