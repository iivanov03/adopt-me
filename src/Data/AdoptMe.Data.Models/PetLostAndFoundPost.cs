﻿using AdoptMe.Data.Common.Models;
using AdoptMe.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdoptMe.Data.Models
{
    public class PetLostAndFoundPost : BaseDeletableModel<int>
    {
        public PetLostAndFoundPost()
        {
            this.PostPictures = new HashSet<Picture>();
            this.Replies = new HashSet<Reply>();
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
    }
}
