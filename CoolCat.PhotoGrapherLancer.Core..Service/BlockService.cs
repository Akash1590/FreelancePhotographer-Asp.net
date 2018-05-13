using CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IAdminServiceInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCat.PhotoGrapherLancer.Core.Entities.Admin;
using CoolCat.PhotoGrapherLancer.Core.Infrastructure;

namespace CoolCat.PhotoGrapherLancer.Core.Service
{
   public  class BlockService : IblockService
    {
        PhotoGraphyDbContext Db = new PhotoGraphyDbContext();

        #region

        public IEnumerable<Block> GetAllBlocks()
        {
            return Db.Set<Block>().ToList();
        }

        public Block GetBlock_Details(int id)   //Get By Contact ID
        {
            var Get_Contact_Details = Db.Set<Block>().Where(x => x.BlockId == id).FirstOrDefault();
            return Get_Contact_Details;
        }


        public bool AddBlockMemer(Block Add_block)
        {
            Db.Set<Block>().Add(Add_block);
            Db.SaveChanges();
            return true;
        }
        public bool Deleteblock(int Delete_block)
        {
            var complain = Db.Blocks.Find(Delete_block);
            Db.Blocks.Remove(complain);
            Db.SaveChanges();
            return true;
        }

        #endregion
    }
}
