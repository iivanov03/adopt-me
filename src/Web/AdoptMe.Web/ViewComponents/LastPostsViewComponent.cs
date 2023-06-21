namespace AdoptMe.Web.ViewComponents
{
    using System.Linq;

    using AdoptMe.Data.Common.Repositories;
    using AdoptMe.Data.Models;
    using AdoptMe.Data.Models.Enums;
    using AdoptMe.Services.Mapping;
    using AdoptMe.Web.Infrastructure;
    using AdoptMe.Web.ViewModels.ViewComponents;
    using Microsoft.AspNetCore.Mvc;

    public class LastPostsViewComponent : ViewComponent
    {
        private readonly IDeletableEntityRepository<PetPost> petPostsRepository;

        public LastPostsViewComponent(IDeletableEntityRepository<PetPost> petPostsRepository)
        {
            this.petPostsRepository = petPostsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var randomPosts = this.petPostsRepository.All()
              .Where(x => x.IsApproved && x.PetStatus == PetStatus.ForAdoption)
              .OrderByDescending(x => x.Id)
              .Take(6)
              .To<LastPostViewComponentModel>().ToList();

            return this.View(randomPosts);
        }
    }
}
