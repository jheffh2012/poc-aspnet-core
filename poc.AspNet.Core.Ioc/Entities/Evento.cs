using System;
using System.Collections.Generic;

namespace poc.AspNet.Core.Ioc.Entities
{
    public class Evento : BaseModel
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public int IdOrganizador { get; set; }
        public int IdCalendario { get; set; }
        public Usuario Organizador { get; set; }
        public Calendario Calendario { get; set; }
        public ICollection<EventoConfirmacao> Confirmacoes { get; set; }
    }
}
