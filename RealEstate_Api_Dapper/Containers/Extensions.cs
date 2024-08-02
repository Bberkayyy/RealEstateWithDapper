using RealEstate_Api_Dapper.Models.DapperContext;
using RealEstate_Api_Dapper.Repositories.AboutUsDetailRepositories;
using RealEstate_Api_Dapper.Repositories.AboutUsSubDetailRepositories;
using RealEstate_Api_Dapper.Repositories.AmenityRepositories;
using RealEstate_Api_Dapper.Repositories.BottomGridRepositories;
using RealEstate_Api_Dapper.Repositories.CategoryRepositories;
using RealEstate_Api_Dapper.Repositories.ClientRepositories;
using RealEstate_Api_Dapper.Repositories.ContactRepositories;
using RealEstate_Api_Dapper.Repositories.EstateAgentRepositories;
using RealEstate_Api_Dapper.Repositories.EstateAgentRepositories.DashboardRepositories;
using RealEstate_Api_Dapper.Repositories.LocationRepositories;
using RealEstate_Api_Dapper.Repositories.MessageRepositories;
using RealEstate_Api_Dapper.Repositories.PropertyDetailRepositories;
using RealEstate_Api_Dapper.Repositories.PropertyImageRepositories;
using RealEstate_Api_Dapper.Repositories.PropertyRepositories;
using RealEstate_Api_Dapper.Repositories.PropertyAmenityRepositoryies;
using RealEstate_Api_Dapper.Repositories.StatisticRepositories;
using RealEstate_Api_Dapper.Repositories.SubFeatureRepositories;
using RealEstate_Api_Dapper.Repositories.ToDoListRepositories;

namespace RealEstate_Api_Dapper.Containers;

public static class Extensions
{
    public static IServiceCollection ContainerDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<Context>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IPropertyRepository, PropertyRepository>();
        services.AddTransient<IAboutUsDetailRepository, AboutUsDetailRepository>();
        services.AddTransient<IAboutUsSubDetailRepository, AboutUsSubDetailRepository>();
        services.AddTransient<IBottomGridRepository, BottomGridRepository>();
        services.AddTransient<ILocationRepository, LocationRepository>();
        services.AddTransient<IClientRepository, ClientRepository>();
        services.AddTransient<IEstateAgentRepository, EstateAgentRepository>();
        services.AddTransient<IStatisticRepository, StatisticRepository>();
        services.AddTransient<IContactRepository, ContactRepository>();
        services.AddTransient<IToDoListRepository, ToDoListRepository>();
        services.AddTransient<IEstateAgentDashboardRepository, EstateAgentDashboardRepository>();
        services.AddTransient<IMessageRepository, MessageRepository>();
        services.AddTransient<IPropertyDetailRepository, PropertyDetailRepository>();
        services.AddTransient<IPropertyImageRepository, PropertyImageRepository>();
        services.AddTransient<IAmenityRepository, AmenityRepository>();
        services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
        services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();

        services.AddCors(opt =>
        {
            opt.AddPolicy("corsPolicy", builder =>
            {
                builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials();
            });
        });
        services.AddSignalR();
        services.AddHttpClient();
        return services;
    }
}
