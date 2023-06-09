﻿namespace AdoptMe.Web.ViewModels.SearchResults
{
    using System;
    using System.Collections.Generic;

    using AdoptMe.Web.ViewModels.SearchResults;

    public class PetListViewModel
    {
        public int ItemsPerPage { get; set; }

        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PagesCount => (int)Math.Ceiling((double)this.AnimalCount / this.ItemsPerPage);

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public IEnumerable<PetInListViewModel> Animals { get; set; }

        public int AnimalCount { get; set; }

        public SearchResultsInputModel UrlInfo { get; set; }
    }
}
