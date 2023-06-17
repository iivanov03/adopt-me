namespace AdoptMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AdoptMe.Data.Common.Models;

    public class UserLostFoundPost : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int LostFoundPostId { get; set; }

        public PetLostAndFoundPost LostFoundPost { get; set; }
    }
}
