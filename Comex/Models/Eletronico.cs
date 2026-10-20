using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Models
{
    internal class Eletronico : Produto
    {
        public double Voltagem { get; set; }
        public double Potencia { get; set; }
        public Eletronico(string nome, double preco) : base(nome, preco)
        {
        }
    }
}
