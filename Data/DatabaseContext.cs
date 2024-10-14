using Microsoft.EntityFrameworkCore;
namespace MangaA.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Manga> Mangas { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Rate> Rates { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Like> Likes { get; set; }     
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentImage> CommentImages { get; set; }

    //
    //



}