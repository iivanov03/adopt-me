namespace AdoptMe.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using AdoptMe.Services.Data;
    using AdoptMe.Web.Controllers;
    using AdoptMe.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IGetCountService getCountService;

        public HomeController(IGetCountService getCountService)
        {
            this.getCountService = getCountService;
        }

        public IActionResult Index()
        {
            var viewModel = this.getCountService.GetIndexCounts();
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
