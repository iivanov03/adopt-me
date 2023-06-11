using AdoptMe.Data.Models;
using AdoptMe.Web.ViewModels.Adopt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdoptMe.Services.Data
{
    public interface IAdoptService
    {
        Task CreateAdoptionPost(CreatePetInputModel input, ApplicationUser user, string webRoot);
    }
}
