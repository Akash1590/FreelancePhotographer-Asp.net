using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CoolCat.PhotoGrapherLancer.Core.Entities.Client
{
    public class JobsInterested
    {

        [Key]
        public int InterestId { get; set; }

        public int FkJobsPostId { get; set; }   //Foreignkey from job post table

        public int FkClientID { get; set; }     //Foreignkey from client Table

        public int PhotoGrapherId { get; set; }  //Foreignkey From PhotoGrapher Model


       




    }
}
