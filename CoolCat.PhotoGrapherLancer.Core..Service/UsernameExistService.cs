using CoolCat.PhotoGrapherLancer.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Service
{
   public class UsernameExistService
    {
        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();

        public bool Phtusername(string username)
        {

            var Pht = Db.PhotoGraphers.Where(x => x.UserName == username).FirstOrDefault();

            return Pht != null;


        }
    }
}
