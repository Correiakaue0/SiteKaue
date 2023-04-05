﻿using System.ComponentModel.DataAnnotations;

namespace Store.Model
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public double Valor { get; set; }

        public string Imagem { get; set; }
    }
}
