using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Ioc.Entities;
using System;
using System.Net.Http;

namespace poc.AspNet.Core.Domain.Services
{
    public class PrevisaoTempoService : IPrevisaoTempoService
    {
        protected readonly IConfiguration _configuration;

        public PrevisaoTempoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetChave()
        {
            return _configuration.GetSection("ChavePrevisaoTempo").Value;
        }

        public PrevisaoTempoCidade GetPrevisaoPorIp(string Ip)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.hgbrasil.com");
                var dados = client.GetAsync($"weather?key={GetChave()}&user_ip={Ip}");

                dados.Wait();
                var response = dados.Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseJson = response.Content.ReadAsStringAsync().Result;
                    var objetoJson = JsonConvert.DeserializeObject<PrevisaoTempo>(responseJson);

                    return objetoJson.results;
                }

                return null;
            }
        }
    }
}
