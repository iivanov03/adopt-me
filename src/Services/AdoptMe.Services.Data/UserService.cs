﻿namespace AdoptMe.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptMe.Common;
    using AdoptMe.Data.Common.Repositories;
    using AdoptMe.Data.Models;
    using AdoptMe.Data.Models.Enums;
    using AdoptMe.Services.Mapping;
    using AdoptMe.Web.Infrastructure;
    using AdoptMe.Web.ViewModels.User;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;


    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<PetPost> petPostsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Picture> pictureRepository;
        private readonly IDeletableEntityRepository<Reply> replyRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private ImageBuilder imageBuilder;

        public UserService(
                           IDeletableEntityRepository<PetPost> petPostsRepository,
                           IDeletableEntityRepository<ApplicationUser> userRepository,
                           IDeletableEntityRepository<Picture> pictureRepository,
                           IDeletableEntityRepository<Reply> replyRepository,
                           UserManager<ApplicationUser> userManager)
        {
            this.petPostsRepository = petPostsRepository;
            this.userRepository = userRepository;
            this.pictureRepository = pictureRepository;
            this.replyRepository = replyRepository;
            this.userManager = userManager;
            this.imageBuilder = new ImageBuilder();
        }

        public UserViewModel GetUserProfile(string userId)
        {
            var userViewModel = this.userRepository.AllAsNoTracking().Where(x => x.Id == userId).To<UserViewModel>().FirstOrDefault();

            return userViewModel;
        }

        public async Task<bool> IsUserPostAuthorized(int postId, ApplicationUser user)
        {
            var postUserId = this.petPostsRepository.AllAsNoTracking().Where(x => x.Id == postId).Select(x => x.UserId).FirstOrDefault();

            if (postUserId == user.Id)
            {
                return true;
            }

            if (await this.userManager.IsInRoleAsync(user, GlobalConstants.AdministratorRoleName))
            {
                return true;
            }

            if (await this.userManager.IsInRoleAsync(user, GlobalConstants.ModeratorRoleName))
            {
                return true;
            }

            return false;
        }

        public bool IsUserProfileOperationAuthorized(string pictureOwner, string currentUser)
        {
            if (pictureOwner == currentUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsUsernameTaken(string nickname)
        {
            var isUserTaken = this.userRepository.AllAsNoTracking().Where(x => x.Nickname == nickname).ToList();

            return isUserTaken.Any();
        }

        public IEnumerable<T> GetAllUserProfilePics<T>(string id)
        {
            var userPictures = this.userRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => x.UserPictures).FirstOrDefault().AsQueryable().To<T>().ToList();

            return userPictures;
        }

        public async Task SetProfilePictureAsync(string pictureId, string userId)
        {
            var pictures = this.userRepository.All().Where(x => x.Id == userId)
                .Select(x => x.UserPictures).FirstOrDefault().ToList();

            if (this.IsUserProfileOperationAuthorized(pictures[0].UserPictureId, userId))
            {
                for (int i = 0; i < pictures.Count; i++)
                {
                    pictures[i].IsCoverPicture = false;

                    if (pictures[i].Id == pictureId)
                    {
                        pictures[i].IsCoverPicture = true;
                    }
                }

                await this.userRepository.SaveChangesAsync();
            }
        }

        public async Task DeletePictureAsync(string pictureId, string userId)
        {
            var picture = this.pictureRepository.All().Where(x => x.Id == pictureId).FirstOrDefault();

            if (this.IsUserProfileOperationAuthorized(picture.UserPictureId, userId))
            {
                this.pictureRepository.Delete(picture);
                await this.pictureRepository.SaveChangesAsync();
            }
        }

        public bool IsUsernameTakenForRegisteredUsers(string nickname, string userId)
        {
            var isUserTaken = this.userRepository.AllAsNoTracking().Where(x => x.Nickname == nickname && x.Id != userId).ToList();

            return isUserTaken.Any();
        }

        public async Task UpdateUserImagesAsync(ApplicationUser user, string webRoot, string categoryName, IEnumerable<IFormFile> images)
        {
            var baseUser = this.userRepository.All().Where(x => x.Id == user.Id).FirstOrDefault();

            int count = images?.ToList().Count() ?? 0;
            if (count != 0)
            {
                var pathInRoot = $"/UserImages/{categoryName}/{user.Nickname}/";
                var directory = webRoot + pathInRoot;

                Directory.CreateDirectory(directory);

                var pictures = await this.imageBuilder.CreatePicturesAsync(images, pathInRoot, user.Id, directory, categoryName);
                pictures.ForEach(x => { baseUser.UserPictures.Add(x); });
            }

            await this.userRepository.SaveChangesAsync();
        }

        public async Task UpdateUserInfoAsync(UserInfoInputModel input, ApplicationUser user)
        {
            var baseUser = this.userRepository.All().Where(x => x.Id == user.Id).FirstOrDefault();

            baseUser.Nickname = input.Nickname;
            baseUser.Living = input.Living;
            baseUser.Age = input.Age;
            baseUser.Sex = (UserSex)input.Sex;
            baseUser.Description = input.Description;

            await this.userRepository.SaveChangesAsync();
        }

        public T GetUserByNickName<T>(string nickName)
        {
            var viewModel = this.userRepository.AllAsNoTracking()
                .Where(x => x.Nickname == nickName)
                .To<T>()
                .FirstOrDefault();

            return viewModel;
        }

        public async Task ClearNotificationsAsync(string userId)
        {
            var user = this.userRepository.All().Where(x => x.Id == userId).FirstOrDefault();
            user.AnswerCounter = 0;

            await this.userRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetNotifications<T>(string userId, int pageNumber, int itemsPerPage)
        {
            var notifications = this.replyRepository.AllAsNoTracking()
                                                    .Where(x => x.PostCreatorId == userId || x.RepliedToUserId == userId)
                                                    .OrderByDescending(x => x.Id)
                                                    .Skip((pageNumber - 1) * itemsPerPage)
                                                    .Take(itemsPerPage)
                                                    .To<T>()
                                                    .ToList();
            return notifications;
        }
    }
}
