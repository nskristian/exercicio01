using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class CadastrarFuncionarioModel
    {
        [MaxLength(150, ErrorMessage ="Número máximo de caracteres {1}")]
        [MinLength(6, ErrorMessage ="Número minimo de caracteres {1}")]
        [Required(ErrorMessage ="Favor preencher nome!")]
        public string Nome { get; set; }

        [Range(1,999999, ErrorMessage ="Favor informe um valor entre {1} e {2}")]
        [Required(ErrorMessage ="Favor preencher salario!")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage ="Favor preencher data de admissão!")]
        public DateTime DataAdmissao { get; set; }

        [MaxLength(150, ErrorMessage = "Número máximo de caracteres {1}")]
        [MinLength(6, ErrorMessage = "Número minimo de caracteres {1}")]
        [Required(ErrorMessage ="Favor preencher cargo!")]
        public string Cargo { get; set; }
    }
}
