using CoolCat.PhotoGrapherLancer.Core._.Service;
using CoolCat.PhotoGrapherLancer.Core.App.Models;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;
using CoolCat.PhotoGrapherLancer.Core.Service;
using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPublicPhotoGrapher_Profile_Interface;
using CoolCat.PhotoGrapherLancer.Core.Service.ServiceViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolCat.PhotoGrapherLancer.Core.App.Controllers
{

   [Authorize]
    public class PhotoGrapherController : Controller
    {
       // string user = System.Web.HttpContext.Current.User.Identity.Name;

        PhotoGraphyDbContext Db=new PhotoGraphyDbContext();
        ClientServices cl = new ClientServices();
        PhotoGrapherServices ph = new PhotoGrapherServices();
        JobPostService jb = new JobPostService();
         BookingService bk = new BookingService();
        AlbumService album = new AlbumService();
        PhotoGallaryService Gallary = new PhotoGallaryService();
        PhotoGrapherSocialService social = new PhotoGrapherSocialService();
        ContactService cn = new ContactService();



        int PhotoGrapherID;


        public PhotoGrapherController()
        {
            if (System.Web.HttpContext.Current.Session["useremail"] != null)
            {
                PhotoGrapherID = (int)System.Web.HttpContext.Current.Session["useremail"];


            }

            else
            {
                RedirectToAction("Login", "Account");

            }




        }


        public ActionResult Index()
        {

            // ViewBag.username = PhotoGrapherID;
            ph.Add_basicProfile(PhotoGrapherID);

            return View();
        }
        public ActionResult Warning()
        {
            return View();
        }
       


        public ActionResult Jobs()
        {
            // int PhotoGrapherId = 1;


                ViewBag.PhotoGrapherId = PhotoGrapherID;
                var JobList=jb.GetAll_Jobs_Post();
                 

            return View(JobList);



        }

        [HttpPost]
        public ActionResult AppliedPost(int PostId, int FkClientID)
        {
            JobsInterested jobs = new JobsInterested();

            jobs.FkClientID = FkClientID;
            jobs.FkJobsPostId = PostId;
            jobs.PhotoGrapherId = PhotoGrapherID;



           var result=jb.AddJobInterest(jobs);



            //if (result == true){

            //    RedirectToAction("Index");

            //}

            //else
            //{

            //    RedirectToAction("Jobs");

            //}

            return RedirectToAction ("JobApplied", "PhotoGrapher");


        }


        [HttpGet]
        public ActionResult JobApplied()
        {



            var data = jb.GetApplied(PhotoGrapherID);



            return View(data);



        }



        [HttpGet]
        public ActionResult AppointmentList()
        {

            int PhotoGrapherId = PhotoGrapherID;
            var Appointmentlist=bk.GetBooking(PhotoGrapherId);

            return View(Appointmentlist);
        }

        [HttpGet]
        public ActionResult ClientDetails(int id)
        {

            var details = cl.GetClient(id);

            return View(details);

        }


        [HttpGet]
        public ActionResult ProfilePicture()
        {

           var imagelist= ph.Get_All_ProfilePicture(PhotoGrapherID);

            return View(imagelist);

        }

        [HttpPost]
        public ActionResult ProfilePicture(ProfilePicture pic, HttpPostedFileBase File)
        {


            ph.Add_Profile_Picture(pic, File, PhotoGrapherID);

            return RedirectToAction ("ProfilePicture", "PhotoGrapher");
            //return View();

        }

        [HttpPost]
        public ActionResult Active(int PID)
        {
            ph.Active_Profile_Picture(PhotoGrapherID, PID);


            return RedirectToAction("ProfilePicture", "PhotoGrapher");

        }



        [HttpGet]
        public ActionResult  Profile()
        {

            ViewBag.photoGrapherId = PhotoGrapherID;
            ViewBag.DateTime = System.DateTime.Now;



            PhotoGrapherProfileViewModel obj = new PhotoGrapherProfileViewModel();


            obj.PhotoGrapher = Db.PhotoGraphers.Where(x => x.PhotoGrapherId == PhotoGrapherID).FirstOrDefault();
            obj.Award = Db.PhotoGrapherAwards.Include("Awards").Where(x => x.Fk_PhotoGrapher_ID == PhotoGrapherID).ToList();//inclue name showed be same navigation property name
            obj.Experience=Db.PhotoGrapherExperiences.Include("experinces").Where(x => x.Fk_PhotoGrapher_ID == PhotoGrapherID).ToList();  //inclue name showed be same navigation property name
            obj.Skill= Db.PhotoGrapherSkills.Include("Skills").Where(x => x.Fk_PhotoGrapher_ID == PhotoGrapherID).ToList();  //inclue name showed be same navigation property name
            obj.type= Db.PhotoGrapherPhotoGraphyTypes.Include("PhotoGraphyTypes").Where(x => x.Fk_PhotoGrapher_ID == PhotoGrapherID).ToList();  //inclue name showed be same navigation property name
            obj.priceDetail= Db.PriceDetails.Where(x => x.Fk_PhotoGrapher_ID == PhotoGrapherID).ToList();  //inclue name showed be same navigation property name
            obj.Albams = Db.Albums.Where(x => x.Fk_PhotoGrapher_ID == PhotoGrapherID).ToList();  //inclue name showed be same navigation property name
            obj.Gallary = Db.PhotoUploadGallarys.Where(x => x.Fk_PhotoGrapher_ID == PhotoGrapherID).OrderByDescending(x => x.PhotoID).ToList();

            var picture = Db.ProfilePictures.Where(x => x.Fk_PhotoGrapher_ID == PhotoGrapherID && x.status == "Deactive").FirstOrDefault();

          
             if (picture != null)
            {
                obj.p_Picture = picture;

            }

            else
            {
                ViewBag.p = "Picture";

            }

            var profileexist = Db.PhotoGrapherBasicProfiles.Where(x => x.Fk_PhotoGrapher_ID == PhotoGrapherID).FirstOrDefault();  //inclue name showed be same navigation property name

            if (profileexist != null)
            {
                obj.Basic_Profile = profileexist;
            }

            
           

            ViewBag.TotalFollower= social.TotalFollowers(PhotoGrapherID);
            ViewBag.TotalRatting = social.TotalRatting(PhotoGrapherID);

            //skill list
            obj.sk = Db.Skills.ToList();
            //experience List
            obj.ex = Db.Experiences.ToList();
            //award List
            obj.aw = Db.Awards.ToList();

            //photography type list
            obj.ty = Db.PhotoGraphyTypes.ToList();

            return View(obj);
        }





        [HttpPost]
        public ActionResult PriceAdd(FormCollection Form)
        {

           PriceDetail p = new PriceDetail();

            p.Fk_PhotoGrapher_ID = PhotoGrapherID;
            p.Catagory = Form["Catagory"];
            p.Details = Form["Details"];
            p.Price = Form["Price"];


            var d = ph.AddPrice(p);
            if (d == true) {

                
                TempData["msg"] = "<script>alert('Price Details Insert Sccessfully');</script>";

                return RedirectToAction("Profile", "PhotoGrapher");

                // return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
                //return new RedirectResult(Url.Action("Profile", "PhotoGrapher", new
                //{
                    
                //    tab = "Price"
                //}));

            }

            else
            {

                return HttpNotFound();
            }

          

        }






        //Create Album

        [HttpPost]
        public ActionResult CreateAlbum(FormCollection Form, HttpPostedFileBase File)
        {

            //Pass Albam Object some Property and Image File
            Album p = new Album();
            p.Fk_PhotoGrapher_ID = PhotoGrapherID;
            p.Caption = Form["Caption"];
            p.Status = Form["Privacy"];

            //Albam Service Function
            album.CreateAlbum(p, File);


            TempData["msg"] = "<script>alert('Create Albam Sccessfully');</script>";

            return RedirectToAction("Profile", "PhotoGrapher");



        }


        //Albam Photo
        [HttpGet]
        public ActionResult AlbamPhotos(int id,string AlbamName)
        {

            ViewBag.AlbamID = id;
            ViewBag.photoGrapherId = PhotoGrapherID;
            ViewBag.alabamname = AlbamName;

            PhotoGrapherProfileViewModel obj = new PhotoGrapherProfileViewModel();


          
       //     obj.AlbamPhotos = Db.AlbamPhoto.Where(x =>x.Albam_ID==id).OrderByDescending(x=>x.AlbamPhotoID).ToList();

            obj.AlbamPhotos = album.GetAll_Albam_Photo(id).ToList();


            return View(obj);
        }

        [HttpPost]
        public ActionResult AlbamPhotos(AlbamPhoto  add, HttpPostedFileBase File)
        {

            album.Add_Albam_Photo(add, File);

            //Message
            TempData["msg"] = "<script>alert('Upload  Albam Photos Successfully');</script>";



            //Current Url Redirect

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);


           // return View();
        }


        

         [HttpPost]
        public ActionResult GallaryPhotos(PhotoUploadGallary add, HttpPostedFileBase File)
        {

            Gallary.Upload_Photo_Gallary(add, File);

            //Message
            TempData["msg"] = "<script>alert('Upload Photos Successfully');</script>";



            //Current Url Redirect

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);


            // return View();
        }

        [HttpGet]
        public ActionResult PhotoDetails(int id)
        {
          

          var details=Gallary.PhotoDetails(id);
            if (details!=null)
            {
                return View(details);

            }

            else
            {


                return HttpNotFound();
            }

        }

        //Change Password View Page Show 
        [HttpGet]
        public ActionResult ChangePassword()
        {
            //Pass PhotoGrapher ID to The View Page
            PhotoGrapherChangePassword ch = new PhotoGrapherChangePassword();
            ch.PhotoGrapherId = PhotoGrapherID;
            return View(ch);

        }




        //Change Password
        [HttpPost]
        public ActionResult ChangePassword(PhotoGrapherChangePassword chng)
        {

            if (ModelState.IsValid)
            {
                // up.ConfirmPassword = up.Password;

                var pass = ph.ChangePassword(chng);

                if (pass == true)
                {
                    TempData["msg"] = "<script>alert('Change Password Sccessfully');</script>";

                    return RedirectToAction("Profile");

                }

                else
                {

                    ModelState.AddModelError("Wrong", "Current Password Incorrect");

                }




            }

            return View(chng);


        }





        [HttpPost]
        public ActionResult UpdateProfile(FormCollection form)
        {
            PhotoGrapherBasicProfile basic = new PhotoGrapherBasicProfile();

           

                basic.Fk_PhotoGrapher_ID = Int32.Parse(form["PhotoGrapherID"]);
                basic.Education = form["Education"];
                basic.Address = form["PresentLocation"];
                basic.Phone = form["Phone"];

                basic.Notes = form["Notes"];

                ph.Update_Profile_Item(basic);





            TempData["msg"] = "<script>alert('Update Profile Successfully');</script>";

            return RedirectToAction("Profile", "PhotoGrapher");
        }

          //Contact List
        [HttpGet]
        public ActionResult ContactList()
        {

            var list = cn.Get_All_PhotoGrapher_Contact(PhotoGrapherID);

            return View(list);
        }

        //Contact List
        [HttpGet]
        public ActionResult ContactDetails(int id)
        {

            var Details = cn.GetContact_Details(id);

            return View(Details);
        }

        //Add Skill
        [HttpPost]
        public ActionResult AddSkill(PhotoGrapherSkill Skill) {



            ph.AddSkill(Skill);
            TempData["msg"] = "<script>alert('Add Skill Successfully');</script>";


            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);


        }


        //Add experience
        [HttpPost]
        public ActionResult AddExp(PhotoGrapherExperience exp)
        {



            ph.AddExperience(exp);
            TempData["msg"] = "<script>alert('Add Experience Successfully');</script>";


            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);


        }


        //Add Award
        [HttpPost]
        public ActionResult AddAward(PhotoGrapherAward awd)
        {



            ph.AddAward(awd);
            TempData["msg"] = "<script>alert('Add Award Successfully');</script>";


            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);


        }


        //Add Type
        [HttpPost]
        public ActionResult Addtype(PhotoGrapherPhotoGraphyType pyped)
        {



            ph.AddPhotoGraphy_Type(pyped);
            TempData["msg"] = "<script>alert('Add PhotoGraphyType Successfully');</script>";


            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);


        }












        //public ActionResult Test()
        //{

        //    //List<ClientJobsPost> ClPost = Db.ClientJobsPosts.ToList();
        //    //List<JobsInterested> Jst = Db.JobsInteresteds.ToList();


        //    //var data= (from d in Jst
        //    //           join f in ClPost
        //    //           on d.FkJobsPostId equals f.PostId
        //    //           where d.PhotoGrapherId == 1
        //    //           select new VpostModel
        //    //           {

        //    //              JobPostList=f,
        //    //              JobInterestList=d



        //    //           }).ToList();


        //}










    }
}