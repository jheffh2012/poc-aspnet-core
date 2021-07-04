using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace poc.AspNet.Core.MVC.Models
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Apelido { get; set; }
        [Required(ErrorMessage = "Preencha o campo Setor")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Setor { get; set; }
        [Required(ErrorMessage = "Preencha o campo DDD")]
        [MaxLength(2, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string DDD { get; set; }
        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(9, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(8, ErrorMessage = "Minimo {0} caracteres")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(255, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Email { get; set; }
        public string Senha { get; set; }

        public int IdEquipe { get; set; }
        public EquipeViewModel Equipe { get; set; }

        public IEnumerable<SelectListItem> Equipes { get; set; }

        public ICollection<EventoConfirmacaoViewModel> Confirmacoes { get; set; }

        public ICollection<EventoViewModel> EventosOrganizados { get; set; }
    }
}
