using poc.AspNet.Core.Ioc.Entities;

namespace poc.AspNet.Core.Domain.Interfaces.Services
{
    public interface IPrevisaoTempoService
    {
        PrevisaoTempoCidade GetPrevisaoPorIp(string Ip);
    }
}
