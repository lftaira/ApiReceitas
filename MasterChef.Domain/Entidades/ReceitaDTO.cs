using System;
using System.ComponentModel.DataAnnotations;

namespace MasterChef.Domain.Entidades
{
    public class ReceitaDTO
    {
        public Int64 ID { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Ingredientes { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string ModoDePreparo { get; set; }

        public string Imagem { get; set; }

        public string Tags { get; set; }

        public CategoriaDTO Categoria { get; set; }
    }
}