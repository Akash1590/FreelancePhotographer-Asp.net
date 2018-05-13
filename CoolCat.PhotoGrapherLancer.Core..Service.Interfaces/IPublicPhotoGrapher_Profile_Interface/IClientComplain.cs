using CoolCat.PhotoGrapherLancer.Core.Entities.Client;
using CoolCat.PhotoGrapherLancer.Core.Entities.PublicProfilePhotoGrapher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCat.PhotoGrapherLancer.Core.Service.Interfaces.IPublicPhotoGrapher_Profile_Interface
{
    public interface IClientComplain
    {
        IEnumerable<ClientComplain> GetAllcomplains();

        ClientComplain GetComplain_Details(int id);  //Get By Contact ID

        bool AddComplain(ClientComplain Add_complain);
        bool DeleteComplain(int Delete_complain);
    }
}
