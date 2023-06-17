﻿namespace AdoptMe.Web.Controllers.ApiControllers
{
    using System.Threading.Tasks;

    using AdoptMe.Data.Models;
    using AdoptMe.Services.Data;
    using AdoptMe.Web.ViewModels.Pet;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("/api/[controller]")]
    [ApiController]
    public class PetProfileController : ControllerBase
    {
        private readonly IPetService petService;
        private readonly UserManager<ApplicationUser> userManager;

        public PetProfileController(IPetService petService, UserManager<ApplicationUser> userManager)
        {
            this.petService = petService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<LikeOutputModel>> AddLikeAsync(LikeInputModel inputModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var output = await this.petService.AddRemoveLikeToPostAsync(inputModel, user);
            return output;
        }
    }
}
