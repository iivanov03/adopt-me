namespace AdoptMe.Web.ViewModels.User
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AdoptMe.Common;
    using AdoptMe.Web.Infrastructure.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class UserImageInputModel
    {
        [Required(ErrorMessage = "Не са избрани снимки за качване")]
        [ImageValidationAttribute(GlobalConstants.MaximumSizeOfOnePicture, GlobalConstants.MaxUserPhotosUserCanUpload)]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}