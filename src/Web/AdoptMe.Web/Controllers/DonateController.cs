namespace AdoptMe.Web.Controllers
{
    using AdoptMe.Services.Data.AdministrationServices;
    using AdoptMe.Web.ViewModels.Administration.Donate;
    using Microsoft.AspNetCore.Mvc;

    public class DonateController : BaseController
    {
        private readonly IDonateService donateService;

        public DonateController(IDonateService donateService)
        {
            this.donateService = donateService;
        }

        public IActionResult All()
        {
            var view = this.donateService.GetAllOrganisations<DonateOrganisationUserViewModel>();
            return this.View(view);
        }
    }
}
