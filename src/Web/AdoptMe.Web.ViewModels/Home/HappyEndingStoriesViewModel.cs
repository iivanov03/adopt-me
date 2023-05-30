using System;
using System.Collections.Generic;
using System.Text;
using AdoptMe.Data.Models;

namespace AdoptMe.Web.ViewModels.Home
{
    public class HappyEndingsIndexViewModel
    {
        public string Description { get; set; }

        public string PersonName { get; set; }

        public string PetName { get; set; }

        public int Likes { get; set; }

        public Picture Avatar { get; set; }

        public string CreatedOn { get; set; }
    }
}
