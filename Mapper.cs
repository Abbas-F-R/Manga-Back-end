using MangaA.Dto.Category;
using MangaA.Dto.Comment;
using MangaA.Dto.Manga;
using MangaA.Dto.Rate;
using MangaA.Dto.Tag;


namespace MangaA
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Manga, MangaDto>()
                .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => 
                    src.Tags != null
                    ? src.Tags.Select(t => t.Name).ToList()!
                    : new List<string>()))
                .ForMember(dest => dest.CategoriesName, opt => opt.MapFrom(src => 
                src.Categories != null
                    ? src.Categories.Select(t => t.Name).ToList()!
                    : new List<string>()))
                .ForMember(dest => dest.RateNumber ,opt => opt.MapFrom(src => 
                    src.Rates != null
                        ? src.Rates.Sum(r => r.RateNumber) / 5.0 
                        : 0));
            
            
            CreateMap<MangaForm, MangaDto>().ReverseMap();
            CreateMap<MangaUpdate, MangaDto>().ReverseMap();
            CreateMap<Manga, MangaUpdate>().ReverseMap();
            CreateMap<MangaForm, Manga>();
            CreateMap<Manga, SearchResponse>().ForMember(dest => dest.RateNumber, opt => opt.MapFrom(src =>
                src.Rates != null
                    ? src.Rates.Sum(r => r.RateNumber) / 5.0 // قسمة المجموع على 5
                    : 0));


            CreateMap<User, UserForm>().ReverseMap();

            CreateMap<Manga, MangaResponse>()
                .ForMember(dest => dest.ChapterNumber, opt => opt.MapFrom(src =>
                    src.ChaptersList != null
                        ? src.ChaptersList
                            .OrderByDescending(c => c.CreationDate)
                            .Take(2)
                            .Select(c => c.ChapterNumber ?? 0)
                            .ToList()
                        : new List<int>())) // Return an empty list if ChaptersList is null
                .ForMember(dest => dest.ChapterId, opt => opt.MapFrom(src =>
                    src.ChaptersList != null
                        ? src.ChaptersList
                            .OrderByDescending(c => c.CreationDate)
                            .Take(2)
                            .Select(c => c.Id)
                            .ToList()
                        : new List<Guid>())) // Return an empty list if ChaptersList is null
                .ForMember(dest => dest.CreationDate, opt =>
                    opt.MapFrom(src => src.ChaptersList != null
                            ? src.ChaptersList
                                .OrderByDescending(c => c.CreationDate)
                                .Take(2)
                                .Select(c => c.CreationDate.ToString("yyyy-MM-dd"))
                                .ToList()
                            : new List<string>() // Changed from List<int> to List<string> to match the output type
                    )).ForMember(dest => dest.RateNumber, opt => opt.MapFrom(src =>
                        src.Rates != null
                            ? src.Rates.Sum(r => r.RateNumber) / 5.0 // قسمة المجموع على 5
                            : 0));


            // Chapter Maps
            CreateMap<Chapter, ChapterDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Manga.Title)) // Map Title from Manga
                .ForMember(dest => dest.MangaId, opt => opt.MapFrom(src => src.Manga.Id)); // Map MangaId from Manga's Id
            CreateMap<ChapterDto, Chapter>();
            CreateMap<Chapter, ChapterForm>();
            CreateMap<ChapterForm, Chapter>();
            CreateMap<Chapter, ChapterUpdate>();
            CreateMap<ChapterUpdate, Chapter>();
            CreateMap<Chapter, ChapterResponse>();
            
            // Category Maps
            CreateMap<Category, CategoryResponse>();
            CreateMap<CategoryResponse, Category>();
            CreateMap<CategoryForm, Category>(); 
            CreateMap<Category, CategoryForm>();
            
            
            // User Maps
            CreateMap<User, UserResponse>();
            CreateMap<UserResponse, User>();
            CreateMap<UserForm, User>();

            // Rate Maps
            CreateMap<Rate, RateDto>();
            CreateMap<RateDto, Rate>();
            CreateMap<RateForm, Rate>();
            CreateMap<Rate, RateUpdate>();
            CreateMap<RateUpdate, Rate >();
            
            // Tag Maps
            CreateMap<Tag, TagResponse>();
            CreateMap<TagResponse, Tag>();
            CreateMap<TagForm, Tag>();
            
            // Comment Maps
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<CommentForm, Comment>();
            CreateMap<Comment, CommentUpdate>();
            CreateMap<CommentUpdate, Comment>();
            CreateMap<Comment, CommentResponse>() 
                .ForMember(dest => dest.CreationDate, 
                    opt => opt.MapFrom(src => src.CreationDate.ToString("yyyy-MM-dd HH:mm:ss")));;
            
            // Like Maps
            CreateMap<Like, LikeDto>();
            CreateMap<LikeDto, Like>();
            // CreateMap<LikeForm, Like>();
            
            // Search Maps
            CreateMap<Manga, SearchResponse>();
            CreateMap<SearchResponse, Manga>();
            
            // CreateMap<Manga, MangaResponse>()
            //     .ForMember(dest => dest.ChapterNumber, opt => opt.MapFrom(src => 
            //         src.ChaptersList
            //             .OrderByDescending(c => c.ChapterNumber)
            //             .Take(2)
            //             .Select(c => c.ChapterNumber?? 0)
            //             .ToList()))
            //     .ForMember(dest => dest.ChapterId, opt => opt.MapFrom(src => 
            //         src.ChaptersList
            //             .
            
            // Search Maps
            CreateMap<Manga, SearchResponse>();
            CreateMap<SearchResponse, Manga>();
            
            // CreateMap<Manga, MangaResponse>()
            //     .ForMember(dest => dest.ChapterNumber, opt => opt.MapFrom(src => 
            //         src.ChaptersList
            //             .OrderByDescending(c => c.ChapterNumber)
            //             .Take(2)
            //             .Select(c => c.ChapterNumber ?? 0)
            //             .ToList()))
            //     .ForMember(dest => dest.ChapterId, opt => opt.MapFrom(src => 
            //         src.ChaptersList
            //             .OrderByDescending(c => c.ChapterNumber)
            //             .Take(2)
            //             .Select(c => c.Id)
            //             .ToList()));





            // CreateMap<UserForm, UserDto>().ReverseMap();  
            // CreateMap<UserUpdate, UserDto>().ReverseMap(); 
            // CreateMap<ProductDto, Product>();
            //
            // CreateMap<Product, ProductDto>();
            //
            // CreateMap<Product, ProductForm>()
            //     .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.Store!.Id))
            //     .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category!.Id))
            //     .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.ProductStatus!.Status));
            //
            // CreateMap<UserDto, User>();
        }
    }
}