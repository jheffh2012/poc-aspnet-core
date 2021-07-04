namespace poc.AspNet.Core.Ioc.Entities
{
    public class PrevisaoTempoCidade
    {
        public int temp { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string condition_code { get; set; }
        public string description { get; set; }

        public string city_name { get; set; }
    }
}
