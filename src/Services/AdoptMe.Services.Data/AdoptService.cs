﻿namespace AdoptMe.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading.Tasks;

    using AdoptMe.Data.Common.Repositories;
    using AdoptMe.Data.Models;
    using AdoptMe.Data.Models.Enums;
    using AdoptMe.Services.Mapping;
    using AdoptMe.Web.Infrastructure;
    using AdoptMe.Web.ViewModels.Adopt;

    public class AdoptService : IAdoptService
    {
        private readonly IDeletableEntityRepository<PetAdoptionPost> adoptionPostsRepository;
        private ImageBuilder imageBuilder;

        public AdoptService(IDeletableEntityRepository<PetAdoptionPost> adoptionPostsRepository)
        {
            this.adoptionPostsRepository = adoptionPostsRepository;
            this.imageBuilder = new ImageBuilder();
        }

        public async Task CreateAdoptionPostAsync(CreateAdoptPetInputModel input, ApplicationUser user, string webRoot)
        {
            var webRootPath = $"/UserImages/Adopt/{user.Nickname}/";
            var directory = webRoot + webRootPath;

            Directory.CreateDirectory(directory);

            var newAdoptPost = new PetAdoptionPost()
            {
                Description = input.Description,
                Location = input.Location,
                Sex = input.Sex,
                Type = input.Type,
                UserId = user.Id,
                Name = input.Name,
            };

            //var newAdoptPost = input.To<PetAdoptionPost>();

            var pictures = await this.imageBuilder.CreatePicturesAsync(input.Images, webRootPath, user.Id, directory);
            pictures.ForEach(x => { newAdoptPost.PostPictures.Add(x); });

            await this.adoptionPostsRepository.AddAsync(newAdoptPost);
            await this.adoptionPostsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllAnimals<T>(int pageNumber, int itemsPerPage, string orderByProperty, string orderAscDesc)
        {
            var pets = this.adoptionPostsRepository.AllAsNoTracking()
                .Where(x => x.IsAdopted == false && x.IsApproved == true);

            var orderedByParameter = pets.OrderBy(orderByProperty, orderAscDesc);

            return orderedByParameter
                .Skip((pageNumber - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        public IEnumerable<T> GetAllAdoptAnimalsByType<T>(int pageNumber, int itemsPerPage, string typeAnimal, string orderByProperty, string orderAscDesc)
        {
            TypePet type = TypePet.Dog;

            switch (typeAnimal)
            {
                case "cats":
                    type = TypePet.Cat;
                    break;
                case "other":
                    type = TypePet.Other;
                    break;
                default:
                    break;
            }

            var pets = this.adoptionPostsRepository.AllAsNoTracking()
                           .Where(x => x.Type == type && x.IsAdopted == false && x.IsApproved == true);

            var orderedByParameter = pets.OrderBy(orderByProperty, orderAscDesc);

            return orderedByParameter
                .Skip((pageNumber - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
        }
    }
}
