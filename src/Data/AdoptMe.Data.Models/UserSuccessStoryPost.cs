namespace AdoptMe.Data.Models
{
    using AdoptMe.Data.Common.Models;

    public class UserSuccessStoryPost : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int SuccessStoryId { get; set; }

        public SuccessStory SuccessStory { get; set; }
    }
}
