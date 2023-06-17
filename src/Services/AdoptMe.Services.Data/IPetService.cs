namespace AdoptMe.Services.Data
{
    using System.Threading.Tasks;

    using AdoptMe.Data.Models;
    using AdoptMe.Web.ViewModels.Pet;

    public interface IPetService
    {
        PetProfileViewModel GetPetProfile(int postId, ApplicationUser user);

        Task<LikeOutputModel> AddRemoveLikeToPostAsync(LikeInputModel input, ApplicationUser user);
    }
}
