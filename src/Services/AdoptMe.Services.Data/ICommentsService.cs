namespace AdoptMe.Services.Data
{
    using System.Threading.Tasks;

    using AdoptMe.Data.Models;

    public interface ICommentsService
    {
        Task CreateAsync(int postId, ApplicationUser currentUser, string text, string answerToNickName, int? parentId = null);

        bool IsInThisPostId(int postId, int commentId);
    }
}
