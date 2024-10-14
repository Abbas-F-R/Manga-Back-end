namespace MangaA.Model
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }
        public string? PasswordHash { get; set; }
        public string Username { get; set; }
        public string? ImageProfile { get; set; }
        public Role Role { get; set; }
        
        public List<Manga>? Mangas { get; set; }
        public List<Like>? Likes { get; set; }
        public List<Comment>? Comments { get; set; }

    }
}
