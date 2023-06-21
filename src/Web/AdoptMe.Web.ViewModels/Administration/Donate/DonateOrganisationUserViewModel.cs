namespace AdoptMe.Web.ViewModels.Administration.Donate
{
    using System.Collections.Generic;

    using AdoptMe.Data.Models;
    using AdoptMe.Services.Mapping;

    public class DonateOrganisationUserViewModel : IMapFrom<DonateOrganisation>
    {
        public string Organisation { get; set; }

        public string Description { get; set; }

        public virtual ICollection<OrganisationLinkViewModel> OrganisationLinks { get; set; }
    }
}
