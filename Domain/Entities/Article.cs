using System;

namespace Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Author { get; set; }

    }
}