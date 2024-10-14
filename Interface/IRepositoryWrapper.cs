namespace MangaA.Interface;

public interface IRepositoryWrapper
{ 
   IUserRepository User { get; }
   IMangaRepository Manga { get; }
   IChapterRepository Chapter { get; }
   ICategoryRepository Category { get; }
   IRateRepository Rate { get; }
   ITagRepository Tag { get; }
   ILikeRepository Like { get; }
   ICommentRepository Comment { get; }
}