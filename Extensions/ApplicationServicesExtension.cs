using MangaA.Service.FileService;
using MangaA.Service.AuthService;
using MangaA.Service.CategoryService;
using MangaA.Service.LikeService;
using MangaA.Service.MangaService;
using MangaA.Service.SearchService;
using Microsoft.EntityFrameworkCore;
namespace MangaA.Extensions;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
       
        // إضافة DbContext مع اتصال PostgreSQL
        services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

        // إضافة AutoMapper مع التجميع الحالي
        services.AddAutoMapper(typeof(Program).Assembly);

        // إضافة الخدمات بالمدى المحدد (Scoped)
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        services.AddScoped<IJwtService, JwtService>(); 
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IMangaService, MangaService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IChapterService, ChapterService>();
        services.AddScoped<ISearchService, SearchService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IRateService, RateService>();
        services.AddScoped<ILikeService, LikeService>();
        services.AddScoped<ICommentService, CommentService>();
        

        
       
        
        return services;

    } 
}