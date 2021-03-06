﻿using System.Collections.Generic;
using System.Threading.Tasks;

using DNI.Services.Shared.Paging;
using DNI.Services.Shared.Sorting;

namespace DNI.Services.Show {
    public interface IShowService {
        Task<IPagedResponse<Show>> GetShowsAsync(IPagingRequest pagingRequest, ISortingRequest sortingRequest, string keyword = null);

        Task<Show> GetLatestShowAsync();

        Task<IDictionary<string, int>> GetAggregatedKeywords();

        Task<Show> GetShowBySlugAsync(string slug);
    }
}