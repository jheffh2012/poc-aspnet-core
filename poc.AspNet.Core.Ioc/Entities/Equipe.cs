using System.Collections.Generic;

namespace poc.AspNet.Core.Ioc.Entities
{
    public class Equipe : BaseModel
    {
        public string Nome { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<Calendario> Calendarios { get; set; }

    }
}
