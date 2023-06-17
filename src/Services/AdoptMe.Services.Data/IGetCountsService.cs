namespace AdoptMe.Services.Data
{
    using AdoptMe.Web.ViewModels.Home;

    public interface IGetCountService
    {
        IndexViewModel GetIndexCounts();

        int GetAllAdoptAnimalsByTypeCount(string type);

        int GetAllAdoptAnimalsCount();
    }
}
