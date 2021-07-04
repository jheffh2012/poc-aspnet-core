using Microsoft.Extensions.DependencyInjection;
using poc.AspNet.Core.Ioc.EntityFramework.Repository;
using poc.AspNet.Core.Ioc.Repository;

namespace poc.AspNet.Core.Ioc.EntityFramework.Extensions
{
    public static class RespositoryEFConfiguration
    {
        public static void AddRepositorysEF(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEquipeRepository, EquipeRepository>();
            services.AddScoped<ICalendarioRepository, CalendarioRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IEventoConfirmacaoRepository, EventoConfirmacaoRepository>();
        }
    }
}
