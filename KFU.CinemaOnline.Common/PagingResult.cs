using System;
using System.Collections.Generic;

namespace KFU.CinemaOnline.Common
{
    public class PagingResult<T> where T : class
    {
        public IReadOnlyCollection<T> Items { get; set; }
        public int Total { get; set; }


        public static PagingResult<T> Empty => new() { Total = 0, Items = Array.Empty<T>() };
    }
}