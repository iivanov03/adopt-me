namespace AdoptMe.Services.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoptMe.Data.Models;
    using AdoptMe.Web.ViewModels.Pet;
    using AdoptMe.Web.ViewModels.StoriesModels;
    using Microsoft.AspNetCore.Http;

    public interface IHappyStoriesService
    {
        Task<int> CreateStoryAsync<T>(T input, ApplicationUser user, string webRoot, string categoryName, IEnumerable<IFormFile> images);

        Task<LikeOutputModel> AddRemoveLikeToPostAsync(LikeInputModel input, ApplicationUser user);

        StoryProfileViewModel GetStoryProfile(int id, ApplicationUser user);

        Task DeleteStoryAsync(int storyId, string userId);

        IEnumerable<T> GetAllStories<T>(int page, int itemsPerPage);
    }
}
