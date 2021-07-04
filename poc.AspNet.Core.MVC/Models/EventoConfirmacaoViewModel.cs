using System.ComponentModel.DataAnnotations;

namespace poc.AspNet.Core.MVC.Models
{
    public class EventoConfirmacaoViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Evento")]
        public int IdEvento { get; set; }
        [Required(ErrorMessage = "Preencha o campo Usuário")]
        public int IdUsuario { get; set; }

        public EventoViewModel Evento { get; set; }
        public UsuarioViewModel Usuario { get; set; }
    }
}
