using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using poc.AspNet.Core.MVC.Models.Map;

namespace poc.AspNet.Core.MVC.Models.Extensions
{
    public static class MapperConfig
    {
        public static void AddProfiles(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton<IMapper>(mapper);
        }
    }
}
