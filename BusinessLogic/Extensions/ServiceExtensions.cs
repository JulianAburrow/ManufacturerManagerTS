using ManufacturerManagerTS.BusinessLogic.Handlers;
using ManufacturerManagerTS.BusinessLogic.Handlers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Managers;
using ManufacturerManagerTS.BusinessLogic.Managers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Validations;
using ManufacturerManagerTS.BusinessLogic.Validations.Interfaces;
using ManufacturerManagerTS.DataAccess.Entities;
using ManufacturerManagerTS.DataAccess.Repositories;
using ManufacturerManagerTS.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ManufacturerManagerTS.BusinessLogic.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IManufacturerPagesManager, ManufacturerPagesManager>();
            services.AddTransient<IWidgetPagesManager, WidgetPagesManager>();
            services.AddTransient<IColourHandler, ColourHandler>();
            services.AddTransient<IColourJustificationHandler, ColourJustificationHandler>();
            services.AddTransient<IManufacturerHandler, ManufacturerHandler>();
            services.AddTransient<IManufacturerStatusHandler, ManufacturerStatusHandler>();
            services.AddTransient<IWidgetHandler, WidgetHandler>();
            services.AddTransient<IWidgetStatusHandler, WidgetStatusHandler>();
            services.AddTransient<IWidgetValidator, WidgetValidator>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<ManufacturerEntity>, GenericRepository<ManufacturerEntity>>();
            services.AddTransient<IGenericRepository<ManufacturerStatusEntity>, GenericRepository<ManufacturerStatusEntity>>();
            services.AddTransient<IGenericRepository<ColourEntity>, GenericRepository<ColourEntity>>();
            services.AddTransient<IGenericRepository<ColourJustificationEntity>, GenericRepository<ColourJustificationEntity>>();
            services.AddTransient<IGenericRepository<WidgetEntity>, GenericRepository<WidgetEntity>>();
            services.AddTransient<IGenericRepository<WidgetStatusEntity>, GenericRepository<WidgetStatusEntity>>();
        }

        public static void AddOther(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
        }
    }
}
