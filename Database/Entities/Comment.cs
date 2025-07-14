namespace blog.Database.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Relacionamento com o usuário
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }

        // Relacionamento com o post
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }

}
