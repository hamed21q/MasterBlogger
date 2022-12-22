using MB.Application;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrustructure.EFCore;
using MB.Infrustructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
builder.Services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
builder.Services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>(); 
builder.Services.AddTransient<IArticleApplication, ArticleApplication>();
builder.Services.AddTransient<IArticleRepository, ArticleRepository>();
builder.Services.AddDbContext<MasterBlogerContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("MasterBlogerDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
