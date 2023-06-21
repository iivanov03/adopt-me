namespace AdoptMe.Web.ViewModels.Administration.Donate
{
    using AdoptMe.Data.Models;
    using AdoptMe.Services.Mapping;

    public class OrganisationLinkViewModel : IMapFrom<OrganisationLink>
    {
        public string LinkName { get; set; }

        public string LinkHref { get; set; }
    }
}
