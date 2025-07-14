namespace blog.Database.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; }

        // Relacionamento
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }

}
