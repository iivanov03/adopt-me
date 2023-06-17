﻿namespace AdoptMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using AdoptMe.Data.Common.Models;
    using AdoptMe.Data.Models;
    using AdoptMe.Data.Models.Enums;

    public class PetLostAndFoundPost : BaseDeletableModel<int>
    {
        public PetLostAndFoundPost()
        {
            this.PostPictures = new HashSet<Picture>();
            this.Replies = new HashSet<Reply>();
            this.UserLikes = new HashSet<UserLostFoundPost>();
        }

        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public City Location { get; set; }

        public Sex Sex { get; set; }

        public TypePet Type { get; set; }

        public PetStatus PetStatus { get; set; }

        public int Likes { get; set; }

        public bool IsFound { get; set; } = false;

        public bool IsApproved { get; set; } = true;

        public virtual ICollection<Picture> PostPictures { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        public virtual ICollection<UserLostFoundPost> UserLikes { get; set; }
    }
}
