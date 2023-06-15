namespace AdoptMe.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using AdoptMe.Web.ViewModels.Home;

    public interface IGetCountService
    {
        IndexViewModel GetIndexCounts();

        int GetAdoptDogCount();

        int GetAdoptCatCount();

        int GetAdoptOtherCount();
    }
}
