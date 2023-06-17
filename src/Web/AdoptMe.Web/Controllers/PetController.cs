namespace AdoptMe.Web.Controllers
{
    using System.Threading.Tasks;

    using AdoptMe.Data.Models;
    using AdoptMe.Services.Data;
    using AdoptMe.Web.Controllers;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PetController : BaseController
    {
        private readonly IPetService petService;
        private readonly UserManager<ApplicationUser> userManager;

        public PetController(IPetService petService, UserManager<ApplicationUser> userManager)
        {
            this.petService = petService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Profile(int id)
        {
            var postId = id;
            var user = await this.userManager.GetUserAsync(this.User);
            var viewModel = this.petService.GetPetProfile(postId, user);

            return this.View(viewModel);
        }
    }
}
