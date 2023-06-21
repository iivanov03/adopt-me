namespace AdoptMe.Data.Models
{
    using System.Collections.Generic;

    using AdoptMe.Data.Common.Models;

    public class DonateOrganisation : BaseDeletableModel<int>
    {
        public DonateOrganisation()
        {
            this.OrganisationLinks = new HashSet<OrganisationLink>();
        }

        public string Organisation { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<OrganisationLink> OrganisationLinks { get; set; }
    }
}
