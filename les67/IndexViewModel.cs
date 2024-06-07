using System.Collections.Generic;

namespace WebApplication3
{
    public class IndexViewModel
    {
        public List<string> Rows { get; set; }
        public string PageTitle { get; set; }
        public int Page { get; set; }
    }
}