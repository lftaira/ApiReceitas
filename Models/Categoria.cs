using System.ComponentModel.DataAnnotations;

namespace ReceitaDeSucesso.api.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 5)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descrição { get; set; }
    }
}