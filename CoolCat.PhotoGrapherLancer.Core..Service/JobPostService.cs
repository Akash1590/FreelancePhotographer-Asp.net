using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IClientServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using System.Data.Entity;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;
using CoolCat.PhotoGrapherLancer.Core.Service.ServiceViewModel;

namespace CoolCat.PhotoGrapherLancer.Core.Service
{
    public class JobPostService : IClientJobsPost_Services
    {
        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();

        //DbContext Db;

        //public JobPostService(DbContext context)
        //{

        //    Db = context;

        //}


        #region//Client Job Post Service

        //Get All Job Post
        public IEnumerable<ClientJobsPost> GetAll_Jobs_Post()
        {

          //  var join = Db.ClientJobsPosts.Include(a => a.);

            return Db.Set<ClientJobsPost>().Include("Clients").ToList();     //Join Use by navigation property
        }




        //Get All Post By Client ID
        public IEnumerable<ClientJobsPost> GetALLPost(int id)
        {
            var All_Obj_Post = Db.Set<ClientJobsPost>().Include("Clients").Where(x => x.FkClientID == id).ToList();

            return All_Obj_Post;
        }






        //Single Job Post
        public ClientJobsPost ClientPost(int id)
        {
            var JobPostDetails = Db.Set<ClientJobsPost>().Where(x => x.PostId == id).FirstOrDefault();
            return JobPostDetails;
        }


        //Add Post
        public bool AddJobsPost(ClientJobsPost jobspost)
        {
            Db.Set<ClientJobsPost>().Add(jobspost);
            Db.SaveChanges();
            return true;

        }


        //Edit JobsPost
        public bool EditJobsPost(ClientJobsPost editPost)
        {

            Db.Entry(editPost).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }

        //Interest PhotoGrapher List
        public IEnumerable<JobsInterested> GetAllInterest(int PostId)
        {
            
            var InterestList_PhotoGrapher = Db.Set<JobsInterested>().Where(x=>x.FkJobsPostId == PostId).ToList();

            return InterestList_PhotoGrapher;


        }



        //No Way Data Pass So I use View model
        public IEnumerable<AppliedPostViewModel> GetApplied(int id)
        {
            List<ClientJobsPost> ClPost = Db.ClientJobsPosts.ToList();
            List<JobsInterested> Jst = Db.JobsInteresteds.ToList();


            var data = (from d in Jst
                        join f in ClPost
                        on d.FkJobsPostId equals f.PostId
                        where d.PhotoGrapherId == id
                        select new AppliedPostViewModel
                        {

                            JobPostList = f,
                            JobInterestList = d



                        }).ToList();

            return data;

        }

        //Get By PhotoGrapherID
        public IEnumerable<JobsInterested> Get_All_Jobs_Applied(int id)
        {
            return Db.Set<JobsInterested>().Where(x => x.PhotoGrapherId == id).ToList();

        }

        //Job Interest Add
        public bool AddJobInterest(JobsInterested Interest)
        {
            Db.Set<JobsInterested>().Add(Interest);
            Db.SaveChanges();


            return true;
        }
        public bool DeleteJobpost(int id)
        {
            var delete = Db.ClientJobsPosts.Find(id);
            Db.ClientJobsPosts.Remove(delete);
            Db.SaveChanges();
            return true;
        }
        public bool DeleteJobInterested(int id)
        {
            var complain = Db.JobsInteresteds.Find(id);
            Db.JobsInteresteds.Remove(complain);
            Db.SaveChanges();
            return true;

        }




        #endregion

    }
}
