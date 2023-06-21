﻿namespace AdoptMe.Web.ViewModels.PostModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AdoptMe.Common;
    using AdoptMe.Data.Models;
    using AdoptMe.Data.Models.Enums;
    using AdoptMe.Services.Mapping;
    using AdoptMe.Web.Infrastructure.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class CreateAdoptPetInputModel : IMapTo<PetPost>
    {
        [Required(ErrorMessage = "Описанието е задължително поле")]
        [Display(Name = "Описание (Точно местоположение,телефон,състояние и др...Максимум 6000 символа)")]
        [DataType(DataType.MultilineText)]
        [StringLength(GlobalConstants.MaxCharactersInPostDescription, MinimumLength = 10, ErrorMessage = "Описанието трябва да е от 10 до 6000 символа")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Името е задължително поле")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Името трябва да е от 2 до 20 символа")]
        [Display(Name = "Име")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Името не трябва да съдържа празни полета")]
        public string Name { get; set; }

        [Required]
        public City Location { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Required]
        public TypePet Type { get; set; }

        [Required(ErrorMessage = "Трябва да качите поне 1 снимка")]
        [ImageValidationAttribute(GlobalConstants.MaximumSizeOfOnePicture, GlobalConstants.MaxPostPhotosUserCanUpload)]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
