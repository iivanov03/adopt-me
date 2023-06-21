namespace AdoptMe.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum TypePet
    {
        [Display(Name = "Куче")]
        Dog = 2,
        [Display(Name = "Котка")]
        Cat = 3,
        [Display(Name = "Други")]
        Other = 4,
    }
}
