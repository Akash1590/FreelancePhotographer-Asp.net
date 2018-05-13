using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.Admin;
using CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IAdminServiceInterface
{
    public interface IblockService
    {
        IEnumerable<Block> GetAllBlocks();

        Block GetBlock_Details(int id);  //Get By Contact ID

        bool AddBlockMemer(Block Add_block);
        bool Deleteblock(int Delete_block);
    }
}
