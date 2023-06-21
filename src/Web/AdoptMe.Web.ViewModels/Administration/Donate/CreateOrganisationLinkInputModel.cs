﻿namespace AdoptMe.Web.ViewModels.Administration.Donate
{
    using System.ComponentModel.DataAnnotations;

    using AdoptMe.Data.Models;
    using AdoptMe.Services.Mapping;

    public class CreateOrganisationLinkInputModel : IMapTo<OrganisationLink>,IMapFrom<OrganisationLink>
    {
        [Display(Name = "Име на линка")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Името трябва да е от 2 до 1000 символа")]
        public string LinkName { get; set; }

        [UrlAttribute(ErrorMessage = "Линкът не е валиден")]
        [Display(Name = "Линк към страницата")]
        public string LinkHref { get; set; }
    }
}
