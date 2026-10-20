namespace Comex.Models;

internal class Produto
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public double Preco { get; private set; }
    public int Quantidade { get; set; }

    public Produto(string nome, double preco)
    {
        Nome = nome;
        Preco = preco;
    }

    public void AtualizarPreco(double novoPreco)
    {
        Preco = novoPreco;
    }

    public string ExibirResumo()
    {
        return $"Produto: {Nome} - Preço: {Preco}";
    }
}
