﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReceitaDeSucesso.api.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Ingredientes { get; set; }
        public string ModoDePreparo { get; set; }
        public string Imagem { get; set; }
        public string Tags { get; set; }
        public Categoria Categoria { get; set; }
    }
}
