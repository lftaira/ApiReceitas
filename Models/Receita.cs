using System.ComponentModel.DataAnnotations;

namespace ReceitaDeSucesso.api.Models
{
    public class Receita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Ingredientes { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string ModoDePreparo { get; set; }

        public string Imagem { get; set; }

        public string Tags { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Categoria Categoria { get; set; }
    }
}