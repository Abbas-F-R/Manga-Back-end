global using MangaA.Model;
global using MangaA.Dto;
global using AutoMapper;
global using MangaA.Base;
global using MangaA.Data;
global using MangaA.Dto.AppUser;
global using MangaA.Dto.Chapter;
global using MangaA.Enums;
global using MangaA.Interface;
global using MangaA.Repository;
global using MangaA.Dto.Manga;
global using MangaA.Dto.Search;
global using MangaA.Dto.Like;
global using MangaA.Service.UserService;
global using MangaA.Services.AuthService;
global using MangaA.Service.TagService;
global using MangaA.Service.RateService;
global using MangaA.Service.ChapterService;
global using MangaA.Service.CommentService;




using MangaA.Extensions;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSecurityExtension(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration); 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // السماح بالنطاق لمشروع Next.js
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();

