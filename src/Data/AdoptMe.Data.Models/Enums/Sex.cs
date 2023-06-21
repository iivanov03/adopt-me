namespace AdoptMe.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum Sex
    {
        [Display(Name = "Мъжко")]
        Male = 2,
        [Display(Name = "Женско")]
        Female = 3,
    }
}
