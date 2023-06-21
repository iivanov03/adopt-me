﻿namespace AdoptMe.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptMe.Data.Common.Repositories;
    using AdoptMe.Data.Models;
    using AdoptMe.Services.Mapping;
    using AdoptMe.Web.ViewModels.Pet;

    public class PetProfileService : IPetProfileService
    {
        private readonly IDeletableEntityRepository<PetPost> petPostsRepository;
        private readonly IDeletableEntityRepository<UserPetPostLikes> userPetPostsRepository;

        public PetProfileService(
            IDeletableEntityRepository<PetPost> petPostsRepository,
            IDeletableEntityRepository<UserPetPostLikes> userPetPostsRepository)
        {
            this.petPostsRepository = petPostsRepository;
            this.userPetPostsRepository = userPetPostsRepository;
        }

        public PetProfileViewModel GetPetProfile(int postId, ApplicationUser user)
        {
            var userLikedThisPost = new List<UserPetPostLikes>();
            if (user != null)
            {
                userLikedThisPost = this.userPetPostsRepository.AllAsNoTracking()
               .Where(x => x.ApplicationUserId == user.Id && x.PetPostId == postId).ToList();
            }

            var viewModel = this.petPostsRepository.AllAsNoTracking()
                         .Where(x => x.Id == postId && x.IsApproved == true)
                         .To<PetProfileViewModel>()
                         .FirstOrDefault();

            var postCreatorId = this.petPostsRepository.AllAsNoTracking()
                          .Where(x => x.Id == postId && x.IsApproved == true).FirstOrDefault().UserId;

            var currentUserId = user?.Id;
            viewModel.IsPostLiked = userLikedThisPost.Any();
            viewModel.IsPostCreator = currentUserId == postCreatorId;

            if (viewModel.PetStatus == "За Осиновяване")
            {
                viewModel.Category = "Adopt";
            }
            else
            {
                viewModel.Category = "LostFound";
            }

            return viewModel;
        }

        public async Task<LikeOutputModel> AddRemoveLikeToPostAsync(LikeInputModel input, ApplicationUser user)
        {
            var outputModel = new LikeOutputModel();
            outputModel.ToLike = "Post";

            var post = this.petPostsRepository.All().Where(x => x.Id == input.PostId && x.IsApproved).FirstOrDefault();

            if (post != null)
            {
                if (input.IsLiked)
                {
                    post.Likes--;
                    var like = this.userPetPostsRepository.AllAsNoTracking().Where(x => x.ApplicationUserId == user.Id && x.PetPostId == input.PostId).FirstOrDefault();
                    this.userPetPostsRepository.HardDelete(like);
                    outputModel.Likes = post.Likes;
                    outputModel.IsLiked = false;

                    await this.petPostsRepository.SaveChangesAsync();
                    await this.userPetPostsRepository.SaveChangesAsync();

                    return outputModel;
                }
                else
                {
                    var userLikes = new UserPetPostLikes() { PetPostId = post.Id, ApplicationUserId = user.Id };
                    post.Likes++;
                    await this.userPetPostsRepository.AddAsync(userLikes);
                    outputModel.Likes = post.Likes;
                    outputModel.IsLiked = true;

                    await this.petPostsRepository.SaveChangesAsync();
                    await this.userPetPostsRepository.SaveChangesAsync();

                    return outputModel;
                }
            }

            outputModel.Likes = -1;
            return outputModel;
        }
    }
}
