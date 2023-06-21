namespace AdoptMe.Web.Infrastructure.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum LostFoundCreateOptions
    {
        [Display(Name = "Изгубени домашни любимци")] Lost = 1,

        [Display(Name = "Намерени домашни любимци")] Found = 2,
    }
}
