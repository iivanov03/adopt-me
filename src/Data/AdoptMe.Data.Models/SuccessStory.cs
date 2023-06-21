namespace AdoptMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using AdoptMe.Data.Common.Models;
    using AdoptMe.Data.Models;

    public class SuccessStory : BaseDeletableModel<int>
    {
        public SuccessStory()
        {
            this.PostPictures = new HashSet<Picture>();
            this.UserLikes = new HashSet<UserSuccessStoryLikes>();
        }

        public string Description { get; set; }

        public string PersonName { get; set; }

        public string PetName { get; set; }

        public int Likes { get; set; }

        public bool IsApproved { get; set; } = true;

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<Picture> PostPictures { get; set; }

        public virtual ICollection<UserSuccessStoryLikes> UserLikes { get; set; }
    }
}
