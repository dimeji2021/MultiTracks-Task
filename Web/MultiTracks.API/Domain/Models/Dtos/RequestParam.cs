namespace MultiTracks.API.Domain.Models.Dtos
{
    public class RequestParam
    {
        public int PageSize { get { return _pageSize; } set { _pageSize = (value > maxPageSize ? maxPageSize : value); } }
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 5;
        const int maxPageSize = 10;

    }
}
