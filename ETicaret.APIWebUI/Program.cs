using ETicaretAPI.Business.Abstract;
using ETicaretAPI.Business.Concrete;
using ETicaretAPI.DataAccess.Abstract;
using ETicaretAPI.DataAccess.Concrete;
using ETicaretAPI.DataAccess.Context;
using ETicaretAPI.Model.ViewModel;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Veri Tabaný
builder.Services.AddDbContext<BaseDbContext>();
// AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Admin 
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();

// User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Product
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Category
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Cart
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartService,CartService>();

builder.Services.AddScoped<UserToProduct>();




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
