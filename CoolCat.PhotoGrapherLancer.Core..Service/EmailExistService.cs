using CoolCat.PhotoGrapherLancer.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Service
{
   public class EmailExistService
    {

        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();


        public bool ClintEmail(string email)
        {

            var client = Db.Clients.Where(x => x.Email == email).FirstOrDefault();

            return client != null;

           
        }



        public bool PhotoGrapherEmail(string email)
        {

            var Pht = Db.PhotoGraphers.Where(x => x.Email == email).FirstOrDefault();

            return Pht != null;


        }




    }
}
