using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdoptMe.Web.Infrastructure.Enums
{
    public enum SearchSex
    {
        [Display(Name = "Всички")]
        All = 1,
        [Display(Name = "Мъжко")]
        Male = 2,
        [Display(Name = "Женско")]
        Female = 3,
    }
}
