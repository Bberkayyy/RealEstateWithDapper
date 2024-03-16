using RealEstate_Api_Dapper.Hubs;
using RealEstate_Api_Dapper.Models.DapperContext;
using RealEstate_Api_Dapper.Repositories.AboutUsDetailRepositories;
using RealEstate_Api_Dapper.Repositories.AboutUsSubDetailRepositories;
using RealEstate_Api_Dapper.Repositories.BottomGridRepositories;
using RealEstate_Api_Dapper.Repositories.CategoryRepositories;
using RealEstate_Api_Dapper.Repositories.ClientRepositories;
using RealEstate_Api_Dapper.Repositories.ContactRepositories;
using RealEstate_Api_Dapper.Repositories.EmployeeRepositories;
using RealEstate_Api_Dapper.Repositories.LocationRepositories;
using RealEstate_Api_Dapper.Repositories.ProductRepositories;
using RealEstate_Api_Dapper.Repositories.StatisticRepositories;
using RealEstate_Api_Dapper.Repositories.ToDoListRepositories;

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
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IStatisticRepository, StatisticRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IToDoListRepository, ToDoListRepository>();
builder.Services.AddHttpClient();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("corsPolicy", builder =>
    {
        builder.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials();
    });
});
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalRHub");

app.Run();
