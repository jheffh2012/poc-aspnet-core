using System.Collections.Generic;

namespace poc.AspNet.Core.Ioc.Entities
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Setor { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }

        public string Email { get; set; }
        public string Senha { get; set; }

        public int IdEquipe { get; set; }
        public Equipe Equipe { get; set; }

        public ICollection<EventoConfirmacao> Confirmacoes { get; set; }

        public ICollection<Evento> EventosOrganizados { get; set; }
    }
}
