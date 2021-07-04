using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace poc.AspNet.Core.MVC.Models
{
    public class CalendarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }
        public int IdEquipe { get; set; }
        public EquipeViewModel Equipe { get; set; }

        public ICollection<EventoViewModel> Eventos { get; set; }
    }
}
