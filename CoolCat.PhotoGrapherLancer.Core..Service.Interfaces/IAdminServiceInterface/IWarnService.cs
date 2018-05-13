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
    public interface IWarnService
    {
        IEnumerable<Warn> GetAllWarns();

        Warn GetWarn_Details(int id);  //Get By Contact ID

        bool AddWarnMemer(Warn Add_warn);
        bool Deletewarn(int Delete_complain);

    }
}
