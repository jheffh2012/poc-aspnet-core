using Microsoft.Extensions.DependencyInjection;
using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Domain.Services;

namespace poc.AspNet.Core.Domain.Extensions
{
    public static class ServicesDomainConfiguration
    {
        public static void AddServicesDomain(this IServiceCollection services)
        {
            services.AddScoped<IPrevisaoTempoService, PrevisaoTempoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEquipeService, EquipeService>();
            services.AddScoped<ICalendarioService, CalendarioService>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IEventoConfirmacaoService, EventoConfirmacaoService>();
        }
    }
}
