using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using Microsoft.AspNetCore.Http;

using AdoptMe.Data.Models;
using AdoptMe.Data.Models.Enums;
using AdoptMe.Web.Infrastructure.ValidationAttributes;

namespace AdoptMe.Web.ViewModels.Adopt
{
    public class CreatePetInputModel
    {
        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [MinLength(10)]
        [MaxLength(3000)]
        public string Description { get; set; }

        public string UserId { get; set; }

        [Required]
        public City Location { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Required]
        public TypePet Type { get; set; }

        [Required]
        [MaxFileSizeAttribute(15)]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
