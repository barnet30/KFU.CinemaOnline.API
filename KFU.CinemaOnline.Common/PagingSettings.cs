namespace KFU.CinemaOnline.Common
{
    public class PagingSettings
    {
        public const int DefaultLimit = 10;
        
        public int Limit { get; set; } = DefaultLimit;
        public int Offset { get; set; }
    }
    
    public class PagingSortSettings : PagingSettings
    {
        public string SortColumn { get; set; }
        public SortOrder SortOrder { get; set; } = SortOrder.Asc;
    }

    public enum SortOrder
    {
        Asc,
        Desc
    }
}