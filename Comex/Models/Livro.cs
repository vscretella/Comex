using System;
using System.Collections.Generic;
using System.Text;
using Comex.Interfaces

namespace Comex.Models
{
    internal class Livro : Produto, IIdentificavel
    {
        public string Isbn { get; set; }
        public int TotalPaginas { get; set; }
        public Livro(string nome, double preco) : base(nome, preco)
        {
        }

        public string Identificar()
        {
            return $"Livro: {Nome}, ISBN: {Isbn}";
        }
    }
}
