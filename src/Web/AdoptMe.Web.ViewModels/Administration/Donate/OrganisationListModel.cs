namespace AdoptMe.Web.ViewModels.Administration.Donate
{
    using AdoptMe.Data.Models;
    using AdoptMe.Services.Mapping;
    using AutoMapper;

    public class OrganisationListModel : IMapFrom<DonateOrganisation>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Organisation { get; set; }

        public string Creator { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DonateOrganisation, OrganisationListModel>()
            .ForMember(x => x.Creator, opt => opt.MapFrom(x => x.User.Nickname));
        }
    }
}
