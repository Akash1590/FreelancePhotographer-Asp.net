
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IClientServiceInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Infrastructure
{
    class Program
    {


        //IClientServices i;

        //public Program(IClientServices t)
        //{

        //    i = t;
        //}


        static void Main(string[] args)
        {


       
        PhotoGraphyDbContext db = new PhotoGraphyDbContext();

        User c = new User();

        c.ID = 1;
        c.name = "Saha";

        //db.users.Add(c);
        //db.SaveChanges();

       // Client c = new Client();

          // c.ClientId = 1;
          //  c.Name = "Saha";
          //  c.Email = "s@gmail.com";
           // c.Password = "12345678";
           // c.Phone = 01;
           // c.Address = "dddddd";          
          //  c.ResetPasswordCode = "dddd";
          //  c.ImagePath = "dd";

            db.users.Add(c);
            db.SaveChanges();


        }

    }
}
