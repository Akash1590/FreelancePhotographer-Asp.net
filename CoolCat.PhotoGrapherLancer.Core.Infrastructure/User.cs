using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Infrastructure
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string name { get; set; }



    }
}
