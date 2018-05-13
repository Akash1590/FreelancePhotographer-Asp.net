using CoolCat.PhotoGrapherLancer.Core._.Service;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Entities.Admin;
using CoolCat.PhotoGrapherLancer.Core.Entities;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;
using CoolCat.PhotoGrapherLancer.Core.Service;
using CoolCat.PhotoGrapherLancer.Core.Service.ServiceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolCat.PhotoGrapherLancer.Core.App.Models;

namespace CoolCat.PhotoGrapherLancer.Core.App.Controllers
{
    public class AdminController : Controller
    {
        AdminService cl = new AdminService();
        ClientServices cs = new ClientServices();
        PhotoGrapherServices ph = new PhotoGrapherServices();
        JobPostService jb = new JobPostService();
        BookingService bk = new BookingService();
        AlbumService album = new AlbumService();
        PhotoGallaryService Gallary = new PhotoGallaryService();
        PhotoGrapherSocialService social = new PhotoGrapherSocialService();
        ContactService cn = new ContactService();
        ComplainService cc = new ComplainService();
        WarnService ws = new WarnService();
        BlockService bs = new BlockService();
        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();
        clientjobappliedservice ja = new clientjobappliedservice();
        JobPostService jps = new JobPostService();
        PhotoGrapherSocialService pgss = new PhotoGrapherSocialService();
        EmailExistService em = new EmailExistService();
        UsernameExistService us = new UsernameExistService();

        int AdminId;

        public AdminController()
        {
            if (System.Web.HttpContext.Current.Session["useremail"] != null)
            {
                PhotoGraphyDbContext dc = new PhotoGraphyDbContext();
                string useremail = (string)System.Web.HttpContext.Current.Session["useremail"];
                var ax = dc.Admins.Where(z => z.Email == useremail).FirstOrDefault();
                AdminId = ax.AdminId;

            }

            else
            {
                RedirectToAction("Login", "Account");

            }
        }


        public ActionResult Index()
        {
            return View(); 
        }
        [ChildActionOnly]
        public ActionResult HomeNumberofClientregistered()
        {
            var client = cs.GetallClient();
            int number=client.Count();
            ViewBag.no = number;
            return View();
            

        }
        [ChildActionOnly]
        public ActionResult Homelatestclient()
        {
            var client = cs.GetallClient();
            
            return View(client.Reverse());


        }
        [ChildActionOnly]
        public ActionResult HomeNumberofphotographerregistered()
        {
            var client = cl.GetAll();
            int number = client.Count();
            ViewBag.no = number;
            return View();


        }
        [ChildActionOnly]
        public ActionResult homeLatestPhotographer()
        {
            var client = cl.GetAll();
            return View(client.Reverse());


        }
        [ChildActionOnly]
        public ActionResult HomeNumberofadminregistered()
        {
            var client = cl.GetallAdmin();
            int number = client.Count();
            ViewBag.no = number;
            return View();


        }
        [ChildActionOnly]
        public ActionResult HomeNumberofwarn()
        {
            var client = ws.GetAllWarns();
            int number = client.Count();
            ViewBag.no = number;
            return View();


        }
        [ChildActionOnly]
        public ActionResult HomeNumberofBlock()
        {
            var client = bs.GetAllBlocks();
            int number = client.Count();
            ViewBag.no = number;
            return View();


        }
        [ChildActionOnly]
        public ActionResult HomeNumberofComplains()
        {
            var client = cc.GetAllcomplains();
            int number = client.Count();
            ViewBag.no = number;
            return View();


        }
        [ChildActionOnly]
        public ActionResult HomeNumberofCompletedJob()
        {
            var client = ja.Getallapplys();
            int number = client.Count();
            ViewBag.no = number;
            return View();


        }
        [ChildActionOnly]
        public ActionResult HomeLatestCompletedJob()
        {
            var client = ja.Getallapplys();
            return View(client.Reverse());


        }
        [ChildActionOnly]
        public ActionResult HomeNumberofpostedjob()
        {
            var client = jps.GetAll_Jobs_Post();
            int number = client.Count();
            ViewBag.no = number;
            return View();


        }
        [ChildActionOnly]
        public ActionResult HomeLatestpostedjob()
        {
            var client = jps.GetAll_Jobs_Post();
            return View(client.Reverse());


        }
        [ChildActionOnly]
        public ActionResult HomeTopRatedphotographer()
        {
            var client = pgss.GetallRatings();
            
            return View(client);


        }
        [HttpGet]
        public ActionResult ClientRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ClientRegister(Client Newclient)
        {
            if (ModelState.IsValid)
            {
                var isExist = em.ClintEmail(Newclient.Email);

                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(Newclient);
                }

                else
                {
                    cs.AddClient(Newclient);

                    return Redirect("/Admin/allCliernts");

                }



            }

            return View(Newclient);
        }

        [HttpGet]
        public ActionResult AdminCreateAccountPhotoGrapher()
        {


            return View();


        }
        [HttpPost]

        public ActionResult AdminCreateAccountPhotoGrapher(PhotoGrapher pht)
        {
            if (ModelState.IsValid)
            {
                var isExist = em.PhotoGrapherEmail(pht.Email);
                var isUsername = us.Phtusername(pht.UserName);

                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(pht);
                }

                else if (isUsername)
                {

                    ModelState.AddModelError("UsernameExist", "Username already exist");
                    return View(pht);

                }

                else
                {
                    ph.AddPhotoGrapher(pht);

                    return Redirect("/Admin/allPhotographer");

                }



            }

            return View(pht);



        }

        public ActionResult Allpostedjob()
        {
            var job = jps.GetAll_Jobs_Post();
            return View(job);


        }
        [HttpGet]
        public ActionResult postedjobdetails(int id)
        {
            var job = jps.ClientPost(id);
            return View(job);
        }
        [HttpGet]
        public ActionResult postedjobdelete(int id)
        {
            var job = jps.DeleteJobpost(id);
            return Redirect("/Admin/Allpostedjob");
        }

        public ActionResult CompletedJob()
        {
            var job = ja.Getallapplys();
            int amount = 0;
            foreach (var element in job)
            {
                amount = amount + int.Parse(element.Price);
            }
            ViewBag.Amount = amount;
            return View(job);
        }

        public ActionResult AllComplains()
        {
            var complain = cc.GetAllcomplains();

            return View(complain);

        }
        public ActionResult Complaindetails(int id)
        {
            var complain = cc.GetComplain_Details(id);
            return View(complain);
        }
        public ActionResult barchart()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Profile()
        {
            var admin = cl.GetAdmin(AdminId);


            return View(admin);

        }
        [HttpGet]
        public ActionResult allPhotographer()
        {
            var photographerlist = cl.GetAll();
            return View(photographerlist);
        }
        [HttpGet]
        public ActionResult allCliernts()
        {
            var clientlist = cs.GetallClient();
            
            return View(clientlist);
        }
        [HttpGet]
        public ActionResult Deleteclient(int id)
        {
            cs.DeleteClient(id);
            TempData["msg"] = "<script>alert('Delete Complain');</script>";
            return Redirect("/Admin/allCliernts");

        }
        [HttpGet]
        public ActionResult Deletephotographer(int id)
        {
            ph.Deletephotographer(id);
            TempData["msg"] = "<script>alert('Delete Complain');</script>";
            return Redirect("/Admin/allPhotographer");
        }
        [HttpGet]
        public ActionResult clientprofiledetails(int id )
        {
            var client = cs.GetClient(id);
            return View(client);

        }
        [HttpGet]
        public ActionResult  Profiledetails(int id)
        {
            photographerallprofilevm obj = new photographerallprofilevm();
            obj.photoGrapher = cl.GetPhotoGrapher(id);
            obj.photoGrapherBasicProfile = cl.GetPhotoGrapherbasic(id);
            obj.p_Picture = Db.ProfilePictures.Where(x => x.Fk_PhotoGrapher_ID == id && x.status == "Deactive").FirstOrDefault();
            return View(obj);
        }

        [HttpPost]
        public ActionResult PhotoGrapherWarning(Warn warn)
        {
            ws.AddWarnMemer(warn);


            TempData["msg"] = "<script>alert('Warning send to user');</script>";

            //Current Url Redirect

            return Redirect("/Admin/Index");

        }
        [HttpGet]
        public ActionResult Complaindelete(int id)
        {
            cc.DeleteComplain(id);
            TempData["msg"] = "<script>alert('Delete Complain');</script>";
            return Redirect("/Admin/Index");

        }

        
        [HttpGet]
        public ActionResult Warningdelete(int id)
        {
            ws.Deletewarn(id);
            TempData["msg"] = "<script>alert('Delete warning');</script>";
            return Redirect("/Admin/AllWarning");

        }
        [HttpGet]
        public ActionResult AllWarning()
        {
            var warn=ws.GetAllWarns();
            return View(warn);

        }
        [HttpGet]
        public ActionResult AddBlocklist(int id)
        {
            Warn asa= Db.Warns.Find(id);
            return View(asa);

        }
        [HttpPost]
        public ActionResult AddBlocklist(Block block)
        {
            
            bs.AddBlockMemer(block);
            TempData["msg"] = "<script>alert('Warning send to user');</script>";
            return Redirect("/Admin/AllBlockMember");

        }
        [HttpGet]
        public ActionResult AllBlockMember()
        {
           var block= bs.GetAllBlocks();
            return View(block);
        }

        [HttpGet]
        public ActionResult Blockdelete(int id)
        {
            bs.Deleteblock(id);
            TempData["msg"] = "<script>alert('Unblock');</script>";
            return Redirect("/Admin/AllBlockMember");

        }




    }
}