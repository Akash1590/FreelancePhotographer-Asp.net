using CoolCat.PhotoGrapherLancer.Core._.Service;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;
using CoolCat.PhotoGrapherLancer.Core.Entities.Admin;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;
using CoolCat.PhotoGrapherLancer.Core.Service;
using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IClientServiceInterface;
using CoolCat.PhotoGrapherLancer.Core.Service.ServiceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CoolCat.PhotoGrapherLancer.Core.App.Controllers
{
    public class AccountController : Controller
    {

        

        ClientServices cl = new ClientServices();
        PhotoGrapherServices ph = new PhotoGrapherServices();
        EmailExistService em = new EmailExistService();
        UsernameExistService us = new UsernameExistService();
        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();



        public string index()
        {

            return "Success";

        }


        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }


        [HttpPost]
        
        public ActionResult CreateAccount(Client Newclient)
        {
            if (ModelState.IsValid)
            {
                var isExist =em.ClintEmail(Newclient.Email);

                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(Newclient);
                }

                else
                {
                    cl.AddClient(Newclient);

                    return RedirectToAction("Index");

                }


               
            }

            return View(Newclient);



        }



        [HttpGet]
        public ActionResult CreateAccountPhotoGrapher()
        {


            return View();


        }

        [HttpPost]

        public ActionResult CreateAccountPhotoGrapher(PhotoGrapher pht)
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

                    return RedirectToAction("Login","Account");

                }



            }

            return View(pht);



        }

        
        public ActionResult Block()
        {
            return View();
        }
        public ActionResult Warning()
        {
            return View();
        }


        [HttpGet]
       public ActionResult Login()
        {


            return View();

        }




        [HttpPost]
        public ActionResult Login(VLogin login, string ReturnUrl = "")
        {


            string message = "";
            using (PhotoGraphyDbContext dc = new PhotoGraphyDbContext())
            {
                var v = dc.Clients.Where(a => a.Email == login.EmailID).FirstOrDefault();
                var p = dc.PhotoGraphers.Where(x => x.Email == login.EmailID).FirstOrDefault();
                var ax = dc.Admins.Where(z => z.Email == login.EmailID).FirstOrDefault();
                
                if (v != null)
                {
                    
                    
                    if (string.Compare(login.Password, v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 2 : 5; 
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);
                      





                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            Session["useremail"] = v.ClientId;
                            Session["FullName"] = v.Name;


                            return RedirectToAction("Index", "Client");
                            //  Response.Write("<script>alert('Welcome to User')</script>");
                        }
                    }
                    else
                    {
                        message = "Invalid Email Or Password";
                    }
                }

                else if(p !=null)
                {


                    var block = dc.Blocks.Where(z => z.Fk_PhotoGrapherID == p.PhotoGrapherId).SingleOrDefault();
                    var warn = dc.Warns.Where(z => z.Fk_PhotoGrapherID == p.PhotoGrapherId).SingleOrDefault();
                    //Warn warn = dc.Warns.Find(p.PhotoGrapherId);

                    if (string.Compare(login.Password, p.Password) == 0)
                    {
                        if (block == null)
                        {
                           

                            
                            int timeout = login.RememberMe ? 2 : 1;
                            var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                            string encrypted = FormsAuthentication.Encrypt(ticket);
                            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                            cookie.Expires = DateTime.Now.AddMinutes(timeout);
                            cookie.HttpOnly = true;
                            Response.Cookies.Add(cookie);





                            if (Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }
                            else
                            {
                                
                                Session["useremail"] = p.PhotoGrapherId;
                                Session["FullName"] = p.FullName;
                               
                                
                                if(warn == null)
                                {
                                    return RedirectToAction("Index", "PhotoGrapher");
                                }
                                else
                                {
                                    return RedirectToAction("Warning", "PhotoGrapher");
                                }
                               
                                //  Response.Write("<script>alert('Welcome to User')</script>");
                            }
                            
                           
                               
                                

                            

                        }
                        else
                        {

                            return RedirectToAction("Block", "Account");


                        }
                    }
                    else
                    {
                        message = "Invalid Email Or Password";
                    }




                }
                else if (ax != null)
                {

                    if (string.Compare(login.Password, ax.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 2 : 1;
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);





                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            Session["useremail"] = ax.Email;
                            Session["FullName"] = ax.Name;
                           

                            return RedirectToAction("Index", "Admin");
                            //  Response.Write("<script>alert('Welcome to User')</script>");
                        }
                    }
                    else
                    {
                        message = "Invalid Email Or Password";
                    }




                }





                else
                {
                    message = "Invalid UserName Or Password";
                }
            }
            ViewBag.Message = message;
            return View();

        }



        [Authorize]
        public ActionResult Logout()
        {


            Session.Clear();
            FormsAuthentication.SignOut();
            //FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("Login", "Account");

        }


    }
}