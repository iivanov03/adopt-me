namespace AdoptMe.Data.Models.Enums
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public enum UserSex
    {
        [Display(Name = "Мъж")]
        Male = 2,
        [Display(Name = "Женa")]
        Female = 3,
    }
}
