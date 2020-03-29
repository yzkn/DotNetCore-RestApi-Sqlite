using System;
using System.Collections.Generic;

namespace DotNetCore_RestApi_Sqlite.DTO
{
    public class SubItemDTO
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Item Item { get; set; }

        public string Author { get; set; }
        public string SubContent { get; set; }
        public string SubTitle { get; set; }
    }

    public class ItemDTO
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<SubItem> SubItems { get; set; }

        public string Author { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
    }
}