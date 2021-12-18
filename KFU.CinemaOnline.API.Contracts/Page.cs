using System;
using System.Collections.Generic;

namespace KFU.CinemaOnline.API.Contracts
{
    public class Page<T>
    {
        public IReadOnlyCollection<T> Items { get; set; } = Array.Empty<T>();

        public int Total { get; set; }
    }
}