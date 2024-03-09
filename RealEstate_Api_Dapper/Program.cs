using RealEstate_Api_Dapper.Models.DapperContext;
using RealEstate_Api_Dapper.Repositories.AboutUsDetailRepositories;
using RealEstate_Api_Dapper.Repositories.AboutUsSubDetailRepositories;
using RealEstate_Api_Dapper.Repositories.BottomGridRepositories;
using RealEstate_Api_Dapper.Repositories.CategoryRepositories;
using RealEstate_Api_Dapper.Repositories.ClientRepositories;
using RealEstate_Api_Dapper.Repositories.LocationRepositories;
using RealEstate_Api_Dapper.Repositories.ProductRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IAboutUsDetailRepository, AboutUsDetailRepository>();
builder.Services.AddTransient<IAboutUsSubDetailRepository, AboutUsSubDetailRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<ILocationRepository, LocationRepository>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();

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
