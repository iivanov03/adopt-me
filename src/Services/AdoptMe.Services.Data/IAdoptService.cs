namespace AdoptMe.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoptMe.Data.Models;
    using AdoptMe.Web.ViewModels.Adopt;

    public interface IAdoptService
    {
        Task CreateAdoptionPostAsync(CreateAdoptPetInputModel input, ApplicationUser user, string webRoot);

        IEnumerable<T> GetAllAnimals<T>(int pageNumber, int itemsPerPage, string orderByProperty, string orderAscDesc);

        IEnumerable<T> GetAllAdoptAnimalsByType<T>(int pageNumber, int itemsPerPage, string typeAnimal, string orderByProperty, string orderAscDesc);
    }
}
