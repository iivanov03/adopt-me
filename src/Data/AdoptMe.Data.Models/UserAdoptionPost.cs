namespace AdoptMe.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using AdoptMe.Data.Common.Models;

    public class UserAdoptionPost : BaseDeletableModel<int>
    {
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int PetAdoptionPostId { get; set; }

        [ForeignKey("PetAdoptionPostId")]
        public PetAdoptionPost PetAdoptionPost { get; set; }
    }
}
