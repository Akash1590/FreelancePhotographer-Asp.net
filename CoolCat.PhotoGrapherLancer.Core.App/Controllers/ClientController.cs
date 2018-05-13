using CoolCat.PhotoGrapherLancer.Core._.Service;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;
using CoolCat.PhotoGrapherLancer.Core.Service;
using CoolCat.PhotoGrapherLancer.Core.App.Models;

using CoolCat.PhotoGrapherLancer.Core.Service.ServiceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolCat.PhotoGrapherLancer.Core.App.Controllers
{



   [Authorize]
    public class ClientController : Controller
    {
        // GET: Client Index


        ClientServices cl = new ClientServices();
        PhotoGrapherServices ph = new PhotoGrapherServices();
        JobPostService jb = new JobPostService();
        PhotoGrapherSocialService social = new PhotoGrapherSocialService();
        BookingService bk = new BookingService();
        ContactService cn = new ContactService();
        PhotoGallaryService Gallary = new PhotoGallaryService();
        AlbumService albam = new AlbumService();
        ComplainService cc = new ComplainService();
        clientjobappliedservice cj = new clientjobappliedservice();
        


        PhotoGraphyDbContext Db =new PhotoGraphyDbContext();

        int ClientID;


        public ClientController()
        {
            if (System.Web.HttpContext.Current.Session["useremail"] != null)
            {
                ClientID = (int)System.Web.HttpContext.Current.Session["useremail"];


            }

            else
            {
                RedirectToAction("Login", "Account");

            }
        }









        public ActionResult Index()
        {
            PhotoGrapherProfileViewModel obj = new PhotoGrapherProfileViewModel();


          //  obj.PhotoGrapher = Db.PhotoGraphers.Where().FirstOrDefault();         
           // obj.Basic_Profile = Db.PhotoGrapherBasicProfiles.Where(x => x.Fk_PhotoGrapher_ID == 1).FirstOrDefault();  //inclue name showed be same navigation property name
            //obj.Albams = Db.Albums.Where(x => x.Fk_PhotoGrapher_ID == 1 && x.Status == "Public").ToList();  //inclue name showed be same navigation property name
            obj.Gallary = Db.PhotoUploadGallarys.Include("PhotoGrapher").Where(x=>x.Shared == "public").OrderByDescending(x => x.PhotoID).ToList();
            obj.ProfilepictureList = Db.ProfilePictures.Include("Pht").Where(x=>x.status == "Deactive").ToList();

            ViewBag.jobpost = Db.ClientJobsPosts.Where(x => x.FkClientID == ClientID).ToList();




            return View(obj);
        }

         public ActionResult PhotoGrapherList()
        {
            PhotoGrapherProfileViewModel obj = new PhotoGrapherProfileViewModel();

            obj.ProfilepictureList = Db.ProfilePictures.Include("Pht").Where(x=>x.status == "Deactive").ToList();


            return View(obj);
        }





        //
        [HttpGet]
        public ActionResult PostShow()
        {
            
            var postlist = jb.GetALLPost(ClientID);

            return View(postlist);
        }
        [HttpGet]
        public ActionResult PostDelete(int id)
        {
            jb.DeleteJobpost(id);
            return Redirect("/Client/PostShow");

        }


        [HttpGet]
        public ActionResult JobsInterestd(int id)
        {
            
            var obj = jb.GetAllInterest(id).ToList();
            
           
            

            return View(obj);
        }


        [HttpGet]
        public ActionResult Profile()
        {
            var client = cl.GetClient(ClientID);


            return View(client);

        }
        [HttpGet]
        public ActionResult jobinterestDelete(int id)
        {
            jb.DeleteJobInterested(id);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);

        }
        [HttpGet]
        public ActionResult jobConfirm(int id)
        {
            ConfirmJobvm obj = new ConfirmJobvm();
            var interestedjob = Db.JobsInteresteds.Find(id);
            obj.client = Db.Clients.Where(x => x.ClientId == interestedjob.FkClientID).FirstOrDefault();
            obj.PhotoGrapher = Db.PhotoGraphers.Where(z => z.PhotoGrapherId == interestedjob.PhotoGrapherId).FirstOrDefault();
            obj.jobpost = Db.ClientJobsPosts.Where(y => y.PostId == interestedjob.FkJobsPostId).FirstOrDefault();

            return View(obj);
        }
        [HttpPost]
        public ActionResult jobConfirm(JobApplied apply)
        {
            cj.Addapplied(apply);
            int id;
            id = apply.PostId;
            jb.DeleteJobpost(id);
            return Redirect("/Client/PostShow");
        }




        [HttpGet]
        public ActionResult Edit(int id)
        {
           // id = 2;

          var e=  cl.GetClient(id);
            return View(e);



        }

        [HttpPost]
        public ActionResult Edit(Client up)
        {
            // id = 2;

           // Client clt = new Client();

            if (ModelState.IsValid)
            {
               // up.ConfirmPassword = up.Password;
                
                cl.EditClient(up);



                return RedirectToAction("Index");
            }

            return View(up);

        }


        [HttpGet]
        public ActionResult ChangePassword()
        {
            ChangePassword v = new Entities.Client.ChangePassword();

            v.ClientId = ClientID;


            return View(v);


        }


        [HttpPost]
        public ActionResult ChangePassword(ChangePassword chng)
        {

            if (ModelState.IsValid)
            {
                // up.ConfirmPassword = up.Password;

               var pass= cl.ChangePassword(chng);

                if (pass==true)
                {
                    return RedirectToAction("Profile");

                }

                else
                {

                    ModelState.AddModelError("Wrong", "Old Password Wrong");

                }



               
            }

            return View(chng);


        }


        public ActionResult NeedPhotoGrapher()
        {

            ClientJobsPost c = new ClientJobsPost();
            c.FkClientID = ClientID;

            return View(c);


        }

        [HttpPost]
        public ActionResult NeedPhotoGrapher(ClientJobsPost post)
        {


            if (ModelState.IsValid)
            {
                // up.ConfirmPassword = up.Password;

                jb.AddJobsPost(post);



                return RedirectToAction("Index");
            }

            return View(post);




        }

        [HttpGet]
        public ActionResult EditPost(int id)
        {
           // EditViewModel e = new EditViewModel();

          //  e.clientid = 2;
            

          //e.ct= 
              var a=  jb.ClientPost(id);

            return View(a);

        }

        [HttpPost]
        public ActionResult EditPost(ClientJobsPost upd)
        {
            if (ModelState.IsValid)
            {
                // up.ConfirmPassword = up.Password;

                jb.EditJobsPost(upd);



                return RedirectToAction("Index");
            }

            return View(upd);

        }




        [HttpGet]
        public ActionResult PhotoGrapherProfile(int id )
        {



            int clientid = ClientID;

            //Fetch The Client Name
            var a = Db.Clients.Where(x => x.ClientId == clientid).SingleOrDefault();


             ViewBag.ClientName = a.Name;
             ViewBag.ClientID = a.ClientId;
            ViewBag.photographerid = id;


            //id = 1;

            //ViewBag.photoGrapherId = 1;
            //ViewBag.DateTime = System.DateTime.Now;



            PhotoGrapherProfileViewModel obj = new PhotoGrapherProfileViewModel();


            obj.PhotoGrapher = Db.PhotoGraphers.Where(x => x.PhotoGrapherId == id).FirstOrDefault();
            obj.Award = Db.PhotoGrapherAwards.Include("Awards").Where(x => x.Fk_PhotoGrapher_ID == id).ToList();//inclue name showed be same navigation property name
            obj.Experience = Db.PhotoGrapherExperiences.Include("experinces").Where(x => x.Fk_PhotoGrapher_ID == id).ToList();  //inclue name showed be same navigation property name
            obj.Skill = Db.PhotoGrapherSkills.Include("Skills").Where(x => x.Fk_PhotoGrapher_ID == id).ToList();  //inclue name showed be same navigation property name
            obj.type = Db.PhotoGrapherPhotoGraphyTypes.Include("PhotoGraphyTypes").Where(x => x.Fk_PhotoGrapher_ID == id).ToList();  //inclue name showed be same navigation property name
            obj.priceDetail = Db.PriceDetails.Where(x => x.Fk_PhotoGrapher_ID == id).ToList();  //inclue name showed be same navigation property name
            obj.Basic_Profile = Db.PhotoGrapherBasicProfiles.Where(x => x.Fk_PhotoGrapher_ID == id).FirstOrDefault();  //inclue name showed be same navigation property name
            obj.Albams = Db.Albums.Where(x => x.Fk_PhotoGrapher_ID == id && x.Status=="Public").ToList();  //inclue name showed be same navigation property name
            obj.Gallary = Db.PhotoUploadGallarys.Where(x => x.Fk_PhotoGrapher_ID == id && x.Shared=="public").OrderByDescending(x => x.PhotoID).ToList();
            obj.p_Picture = Db.ProfilePictures.Where(x => x.Fk_PhotoGrapher_ID == id && x.status == "Deactive").FirstOrDefault();



            //Check This Client This PhotoGrapher Ratting or Not
            var cl= Db.PhotoGrapherFollowers.Where(x => x.Fk_Client_id == clientid && x.Fk_PhotoGrapher_ID==id).SingleOrDefault();
            if (cl != null)
            {
                obj.Follower = cl;

            }

            else
            {

                ViewBag.f = "Follow";
            }
           


            ViewBag.TotalFollower = social.TotalFollowers(id);
            ViewBag.TotalRatting = social.TotalRatting(id);


            return View(obj);

                }

        






        //PhotoGrapher Booking
        [HttpPost]
        public ActionResult PhotoGrapherBooking(PhotoGrapherBooking book)
        {

            bk.AddBooking(book);

            TempData["msg"] = "<script>alert('PhotoGrapher Booking Successfully ,FeedBack Soon');</script>";

            //Current Url Redirect

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);

        }

        //Contact With PhotoGrapher
        [HttpPost]
        public ActionResult PhotoGrapherContact(ClientContact Contact)
        {

            cn.AddContact(Contact);

            TempData["msg"] = "<script>alert('Contact Sent Successfully,FeedBack Soon');</script>";

            //Current Url Redirect

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);

        }
        //Contact With PhotoGrapher
        [HttpPost]
        public ActionResult PhotoGrapherComplain(ClientComplain complain)
        {
            cc.AddComplain(complain);
            

            TempData["msg"] = "<script>alert('Complain Sent Successfully,FeedBack Soon');</script>";

            //Current Url Redirect

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);

        }



        // Gallary Photo Details
        [HttpGet]
        public ActionResult PhotoDetails(int id)
        {


            var details = Gallary.PhotoDetails(id);
            if (details != null)
            {
                return View(details);

            }

            else
            {


                return HttpNotFound();
            }

        }


        //Portfolio all Photo
        [HttpGet]
        public ActionResult PortfolioPhotos(int id, string AlbamName)
        {

            
            ViewBag.alabamname = AlbamName;

            PhotoGrapherProfileViewModel obj = new PhotoGrapherProfileViewModel();



            //     obj.AlbamPhotos = Db.AlbamPhoto.Where(x =>x.Albam_ID==id).OrderByDescending(x=>x.AlbamPhotoID).ToList();

            obj.AlbamPhotos = albam.GetAll_Albam_Photo(id).ToList();


            return View(obj);
        }


        //Portfolio all Photo
        [HttpPost]
        public ActionResult Follow(PhotoGrapherFollower flw)
        {


             var result=  social.AddFollowers(flw);

            if (result == true)
            {

               // TempData["msg"] = "<script>alert('You Followed This PhotoGrapher');</script>";

                //Current Url Redirect

                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
            }

            else { 

                //TempData["msg"] = "<script>alert('You Already Follows This PhotoGrapher');</script>";

                //Current Url Redirect

                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
            }




        }



        //When Client Unfollow
        [HttpPost]
        public ActionResult UnFollow(int UnfollowID)
        {


               var result = Db.PhotoGrapherFollowers.Find(UnfollowID);

                 Db.PhotoGrapherFollowers.Remove(result);
                 Db.SaveChanges();

                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);



        }


        [HttpPost]
        public ActionResult AddRatting(PhotoGrapherRatting rat)
        {

            
         var res=social.AddRatting(rat);
            if (res== true)
            {
                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);

            }

            else
            {

                ViewBag.RattingMessage = "You Alread Rate This Profile";
                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);


            }





        }



        


    }




}