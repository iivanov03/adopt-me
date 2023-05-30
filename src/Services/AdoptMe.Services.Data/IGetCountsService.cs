using System;
using System.Collections.Generic;
using System.Text;
using AdoptMe.Web.ViewModels.Home;

namespace AdoptMe.Services.Data
{
    public interface IGetCountsService
    {
        IndexViewModel GetIndexCounts();
    }
}
