﻿namespace AdoptMe.Web.Controllers
{
    using System.Threading.Tasks;

    using AdoptMe.Data.Models;
    using AdoptMe.Services.Data;
    using AdoptMe.Web.ViewModels.Adopt;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AdoptController : BaseController
    {
        private readonly IAdoptService adoptService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdoptController(
            IAdoptService adoptService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            this.adoptService = adoptService;
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult SearchResults()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePetInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            var webRoot = this.webHostEnvironment.WebRootPath;

            await this.adoptService.CreateAdoptionPost(input, user, webRoot);

            return this.RedirectToAction(nameof(All));
        }
    }
}
