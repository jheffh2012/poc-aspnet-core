using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace poc.AspNet.Core.MVC.Models
{
    public class EventoViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo Data de Inicio")]
        public DateTime DataInicio { get; set; }
        [Required(ErrorMessage = "Preencha o campo Data final")]
        public DateTime DataFinal { get; set; }

        public decimal PercentualConfirmacao { get; set; }
        public int IdOrganizador { get; set; }
        public int IdCalendario { get; set; }
        public UsuarioViewModel Organizador { get; set; }
        public CalendarioViewModel Calendario { get; set; }
        public ICollection<EventoConfirmacaoViewModel> Confirmacoes { get; set; }
    }
}
