﻿namespace AdoptMe.Web.ViewModels.Adopt
{
    using System.Globalization;
    using System.Linq;

    using AdoptMe.Data.Models;
    using AdoptMe.Data.Models.Enums;
    using AdoptMe.Services.Mapping;
    using AutoMapper;

    public class PetInListViewModel : IMapFrom<PetAdoptionPost>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public City Location { get; set; }

        public Sex Sex { get; set; }

        public TypePet Type { get; set; }

        public string CreatedOn { get; set; }

        public string CoverPicturePath { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<PetAdoptionPost, PetInListViewModel>()
                .ForMember(x => x.CreatedOn, opt => opt.MapFrom(x => x.CreatedOn.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(x => x.CoverPicturePath, opt => opt.MapFrom(x => x.PostPictures.Where(x => x.IsCoverPicture).FirstOrDefault().Path != null ?
                                                                            x.PostPictures.Where(x => x.IsCoverPicture).FirstOrDefault().Path :
                                                                            x.PostPictures.Where(x => x.IsCoverPicture).FirstOrDefault().RemoteImageUrl))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description.Substring(0, 125) + "..."));
        }
    }
}