using System;

namespace Application.DTOs
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
    public class CreateArticleDto
    {
       public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
    public class UpdateArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

    }
}