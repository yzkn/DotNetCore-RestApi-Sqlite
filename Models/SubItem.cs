using System;

namespace DotNetCore_RestApi_Sqlite
{
    public class SubItem
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Item Item { get; set; }

        public string Author { get; set; }
        public string SubContent { get; set; }
        public string SubTitle { get; set; }
    }
}
