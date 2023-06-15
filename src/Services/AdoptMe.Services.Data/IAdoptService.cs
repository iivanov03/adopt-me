namespace AdoptMe.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using AdoptMe.Data.Models;
    using AdoptMe.Web.ViewModels.Adopt;

    public interface IAdoptService
    {
        Task CreateAdoptionPost(CreateAdoptPetInputModel input, ApplicationUser user, string webRoot);

        IEnumerable<T> GetAll<T>(int pageNumber, int itemsPerPage);

        IEnumerable<T> GetAllDogs<T>(int pageNumber, int itemsPerPage);

        IEnumerable<T> GetAllCats<T>(int pageNumber, int itemsPerPage);

        IEnumerable<T> GetAllOther<T>(int pageNumber, int itemsPerPage);
    }
}
