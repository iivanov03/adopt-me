namespace AdoptMe.Web.ViewModels.ViewComponents
{
    using System.Collections.Generic;
    using System.Linq;

    using AdoptMe.Data.Models;
    using AdoptMe.Services.Mapping;
    using AutoMapper;

    public class NotificationViewComponentModel : IMapFrom<ApplicationUser>
    {
        public int AnswerCounter { get; set; }

        public List<RepliesViewComponentModel> Notifications { get; set; }
    }
}
