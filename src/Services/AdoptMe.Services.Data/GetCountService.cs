﻿using AdoptMe.Data.Common.Repositories;
using AdoptMe.Data.Models;
using AdoptMe.Data.Models.Enums;
using AdoptMe.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptMe.Services.Data
{
    public class GetCountService : IGetCountService
    {
        private readonly IDeletableEntityRepository<PetAdoptionPost> adoptionPostsRepository;
        private readonly IDeletableEntityRepository<PetLostAndFoundPost> lostAndFoundRepository;
        private readonly IDeletableEntityRepository<Picture> pictureRepository;
        private readonly IDeletableEntityRepository<SuccessStory> successStoriesRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> users;

        public GetCountService(
        IDeletableEntityRepository<PetAdoptionPost> adoptionPostsRepository,
        IDeletableEntityRepository<PetLostAndFoundPost> lostAndFoundRepository,
        IDeletableEntityRepository<Picture> pictureRepository,
        IDeletableEntityRepository<SuccessStory> successStoriesRepository,
        IDeletableEntityRepository<ApplicationUser> users)
        {
            this.adoptionPostsRepository = adoptionPostsRepository;
            this.lostAndFoundRepository = lostAndFoundRepository;
            this.pictureRepository = pictureRepository;
            this.successStoriesRepository = successStoriesRepository;
            this.users = users;
        }

        public IndexViewModel GetIndexCounts()
        {
            var data = new IndexViewModel()
            {
                DogsCount = this.adoptionPostsRepository.AllAsNoTracking()
                            .Where(x => x.IsAdopted == false && x.Type == TypePet.Dog && x.IsApproved == true).Count() +
                            this.lostAndFoundRepository.AllAsNoTracking()
                            .Where(x => x.IsFound == false && x.Type == TypePet.Dog && x.PetStatus == PetStatus.Found && x.IsApproved == true).Count(),

                CatCount = this.adoptionPostsRepository.AllAsNoTracking()
                            .Where(x => x.IsAdopted == false && x.Type == TypePet.Cat && x.IsApproved == true).Count() +
                            this.lostAndFoundRepository.AllAsNoTracking()
                            .Where(x => x.IsFound == false && x.Type == TypePet.Cat && x.PetStatus == PetStatus.Found && x.IsApproved == true).Count(),

                OtherAnimalsCount = this.adoptionPostsRepository.AllAsNoTracking()
                            .Where(x => x.IsAdopted == false && x.Type == TypePet.Other && x.IsApproved == true).Count() +
                            this.lostAndFoundRepository.AllAsNoTracking()
                            .Where(x => x.IsFound == false && x.Type == TypePet.Other && x.PetStatus == PetStatus.Found && x.IsApproved == true).Count(),

                AdoptedAnimals = this.adoptionPostsRepository.AllAsNoTracking().Where(x => x.IsAdopted == true).Count() +
                            this.lostAndFoundRepository.AllAsNoTracking().Where(x => x.IsFound == true).Count(),

                Volunteers = this.users.AllAsNoTracking().Count(),

                HappyStories = this.successStoriesRepository.AllAsNoTracking().Select(x => new HappyEndingsIndexViewModel()
                {
                    Description = x.Description,
                    Avatar = x.PostPictures.FirstOrDefault(x => x.IsCoverPicture),
                    Likes = x.Likes,
                    PersonName = x.PersonName,
                    PetName = x.PetName,
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                }).ToList(),
            };

            return data;
        }
    }
}
