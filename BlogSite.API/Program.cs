using BlogSite.DataAccess.Abstract;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.DataAccess.Contexts;
using BlogSite.Service.Abstratcts;
using BlogSite.Service.Concretes;
using BlogSite.Service.Profiles;
using BlogSite.Service.Rules;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<IPostService,PostService>();
builder.Services.AddScoped<PostBusinessRules>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserBusinessRules>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
