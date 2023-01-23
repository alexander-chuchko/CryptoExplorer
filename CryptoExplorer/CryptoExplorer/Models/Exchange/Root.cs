using System.Collections.Generic;

namespace CryptoExplorer.Models.Exchange
{
    public class Root
    {
        public List<Market>? Markets { get; set; }
        public string? Next { get; set; }

    }
}
