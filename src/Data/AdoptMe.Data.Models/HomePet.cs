using AdoptMe.Data.Common.Models;
using AdoptMe.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdoptMe.Data.Models
{
    public class HomePet : BaseDeletableModel<int>
    {
        public HomePet()
        {
            this.PetPictures = new HashSet<Picture>();
        }

        public string Name { get; set; }

        public TypePet Type { get; set; }

        public string Breed { get; set; }

        public Sex Sex { get; set; }

        public DateTime DateOfBirth { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<Picture> PetPictures { get; set; }
    }
}
