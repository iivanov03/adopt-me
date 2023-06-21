﻿using AdoptMe.Data.Models;
using AdoptMe.Services.Mapping;
using AutoMapper;

namespace AdoptMe.Web.ViewModels.User
{
    public class UserProfilePicViewModel : IMapFrom<Picture>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Path { get; set; }

        public bool IsCoverPicture { get; set; }

        public string DataSize { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Picture, UserProfilePicViewModel>()
               .ForMember(x => x.Path, opt => opt.MapFrom(x => x.Path != null ?
                                                               x.Path :
                                                               x.RemoteImageUrl))
                .ForMember(x => x.DataSize, opt => opt.MapFrom(x => x.Width.ToString() + 'x' + x.Height.ToString()));
        }
    }
}
