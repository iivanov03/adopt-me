namespace AdoptMe.Web.ViewModels.StoriesModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AdoptMe.Common;
    using AdoptMe.Data.Models;
    using AdoptMe.Services.Mapping;
    using AdoptMe.Web.Infrastructure.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class CreateStoryInputModel : IMapTo<SuccessStory>
    {
        [Required(ErrorMessage = "Описанието е задължително поле")]
        [Display(Name = "Историята ...Максимум 2000 символа")]
        [DataType(DataType.MultilineText)]
        [StringLength(GlobalConstants.MaxCharactersInStoryDescription, MinimumLength = 10, ErrorMessage = "Описанието трябва да е от 10 до 2000 символа")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Името е задължително поле")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Името трябва да е от 2 до 40 символа")]
        [Display(Name = "Твоето име")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Името е задължително поле")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Името трябва да е от 2 до 20 символа")]
        [Display(Name = "Името на твоят любимец")]
        public string PetName { get; set; }

        [Required(ErrorMessage = "Трябва да качите поне 1 снимка")]
        [ImageValidationAttribute(GlobalConstants.MaximumSizeOfOnePicture, GlobalConstants.MaxPostPhotosUserCanUpload)]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
