using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities;
using CoolCat.PhotoGrapherLancer.Core.Entities.PhotoGrapher;

namespace CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IClientServiceInterface
{
     public  interface IClientJobsPost_Services
    {
        //All Jobs Post
        IEnumerable<ClientJobsPost> GetAll_Jobs_Post();


        //Get All Client Post(By Client Id)

        IEnumerable<ClientJobsPost> GetALLPost (int id);


        //All Jobs Interest PhotoGrapher
        IEnumerable<JobsInterested> Get_All_Jobs_Applied(int id);


        //SinglePost
        //This Id Job Post Id
        ClientJobsPost ClientPost(int id);



        //Add post

        bool AddJobsPost(ClientJobsPost jobspost);



        //Edit
        bool EditJobsPost(ClientJobsPost editPost);


        //Job Interest add

        bool AddJobInterest(JobsInterested Interest);


        //JobsInterest PhotoGrapherList by ClientID

        IEnumerable<JobsInterested> GetAllInterest(int PostId);  //individual client search by all post and interested

        bool DeleteJobpost(int deleteclient);
        bool DeleteJobInterested(int id);














    }
}
