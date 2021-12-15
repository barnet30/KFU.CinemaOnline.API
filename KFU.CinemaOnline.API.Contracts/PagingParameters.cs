namespace KFU.CinemaOnline.API.Contracts
{
    /// <summary>
    /// Pagination settings
    /// </summary>
    public class PagingParameters
    {
        /// <summary>
        /// Max amount of request items
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Offset
        /// </summary>
        public int Offset { get; set; }
    }

    /// <summary>
    /// Pagination settings with sorting
    /// </summary>
    public class PagingSortParameters : PagingParameters
    {
        /// <summary>
        /// Sort column
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// Sort order. 0 - ascending (Asc); 1 - descending (Desc)
        /// </summary>
        public PagingSortOrder SortOrder { get; set; } = PagingSortOrder.Asc;
    }

    /// <summary>
    /// Sort order. 0 - ascending (Asc); 1 - descending (Desc)
    /// </summary>
    public enum PagingSortOrder
    {
        /// <summary>
        /// ascending (Asc)
        /// </summary>
        Asc,
        
        /// <summary>
        /// descending (Desc)
        /// </summary>
        Desc
    }
}