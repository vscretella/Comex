Dictionary<string, string> clientes = new(); // chave: CPF do cliente, valor: nome do cliente
Dictionary<string, double> produtos = new(); // chave: nome do produto, valor: preço do produto
Dictionary<string, List<string>> carrinho = new(); // chave: nome do cliente, valor: lista de produtos no carrinho

void ExibirMenuDeOpcoes()
{
    Console.WriteLine("-- PROJETO COMEX --");

    //exibir opção de cadastrar cliente
    Console.WriteLine("\nDigite 1 para cadastrar um Cliente");
    Console.WriteLine("\nDigite 2 para listar os Clientes");
    Console.WriteLine("\nDigite 3 para cadastrar um Produto");
    Console.WriteLine("\nDigite 4 para listar os Produtos");
    Console.WriteLine("\nDigite 5 para alterar preço de produto");
    Console.WriteLine("\nDigite 6 para adicionar produto no carrinho");
    Console.WriteLine("\nDigite 7 para fechar a compra");
    Console.WriteLine("\nDigite -1 para sair do programa");

    Console.Write("\n\nDigite a sua opção: ");
    int opcao = int.Parse(Console.ReadLine()!);

    switch (opcao)
    {
        case 1:
            CadastrarCliente();
            break;
        case 2:
            ListarClientes();
            break;
        case 3:
            CadastrarProduto();
            break;
        case 4:
            ListarProdutos();
            break;
        case 5: 
            AlterarPrecoProduto(); 
            break;
        case 6:
            AdicionarProdutoNoCarrinho();
            break;
        case 7:
            FecharCompra();
            break;
        case -1:
            Console.WriteLine("Saindo do programa...");
            break;
        default:
            break;
    }
}

void FecharCompra()
{
    Console.Clear();
    Console.WriteLine("--Fechar Compra--");

    Console.WriteLine("\nDigite o nome do cliente que deseja fechar a compra");
    string nomeCliente = Console.ReadLine()!;
    if (!carrinho.ContainsKey(nomeCliente))
    {
        Console.WriteLine("Cliente não cadastrado!");
        VoltarAoMenuPrincipal();
        return;
    }

    double total = 0;
    Console.WriteLine($"\nProdutos no carrinho de {nomeCliente}:");
    foreach (var produto in carrinho[nomeCliente])
    {
        double preco = produtos[produto];
        total += preco;
        Console.WriteLine($"Produto: {produto} - Preço: {preco}");
    }

    Console.WriteLine($"\nTotal da compra: {total}");

    Console.WriteLine("\nEscreva os dados do seu cartão:");
    string dadosCartao = Console.ReadLine()!;
    Console.WriteLine($"\nRealizando pagamento de R${total} no cartão {dadosCartao}");

    carrinho.Remove(nomeCliente);
    VoltarAoMenuPrincipal();
}

void AdicionarProdutoNoCarrinho()
{
    Console.Clear();
    Console.WriteLine("--Adicionar Produto no Carrinho--");

    Console.WriteLine("\nQual usuário está adicionando o produto ao carrinho?");
    string nomeCliente = Console.ReadLine()!;
    if (!clientes.ContainsValue(nomeCliente))
    {
        Console.WriteLine("Usuário não cadastrado!");
        VoltarAoMenuPrincipal();
        return;
    }

    Console.WriteLine("\nDigite o nome do produto que deseja adicionar ao carrinho");
    string nomeProduto = Console.ReadLine()!;

    if (!produtos.ContainsKey(nomeProduto))
    {
        Console.WriteLine("Produto não cadastrado!");
        VoltarAoMenuPrincipal();
        return;
    }

    //se não existir carrinho para o cliente, criar um novo
    if (!carrinho.ContainsKey(nomeCliente))
    {
        carrinho[nomeCliente] = new List<string>();
    }
    carrinho[nomeCliente].Add(nomeProduto);

    Console.WriteLine($"\nProduto {nomeProduto} adicionado ao carrinho com sucesso!");
    VoltarAoMenuPrincipal();
}

void AlterarPrecoProduto()
{
    Console.Clear();
    Console.WriteLine("--Alterar Preço do Produto--");

    Console.WriteLine("\nDigite o nome do produto que quer alterar o preço");
    string nome = Console.ReadLine()!;
    if (!produtos.ContainsKey(nome))
    {
        Console.WriteLine("Produto não cadastrado no sistema!");
        VoltarAoMenuPrincipal();
        return;
    }

    Console.WriteLine("\nDigite o novo preço do produto");
    double novoPreco = double.Parse(Console.ReadLine()!);

    produtos[nome] = novoPreco;

    Console.WriteLine($"Preço do produto {nome} alterado para {novoPreco} com sucesso!");
    VoltarAoMenuPrincipal();
}

void CadastrarCliente()
{
    Console.Clear();
    Console.WriteLine("--Cadastrar Cliente--");

    Console.WriteLine("\nDigite o CPF do cliente");
    string cpf = Console.ReadLine()!;
    if (clientes.ContainsKey(cpf))
    {
        Console.WriteLine("Cliente já cadastrado!");
        VoltarAoMenuPrincipal();
        return;
    }

    Console.WriteLine("\nDigite o nome do cliente");
    string nome = Console.ReadLine()!;

    clientes.Add(cpf, nome);

    Console.WriteLine($"Cliente {nome} cadastrado com sucesso!");
    VoltarAoMenuPrincipal();
}

void ListarClientes()
{
    Console.Clear();
    Console.WriteLine("--Listar Clientes--");
    foreach (var cliente in clientes)
    {
        Console.WriteLine($"CPF: {cliente.Key} - Nome: {cliente.Value}");
    }
    VoltarAoMenuPrincipal();
}

void VoltarAoMenuPrincipal()
{
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
    ExibirMenuDeOpcoes();
}

void CadastrarProduto()
{
    Console.Clear();
    Console.WriteLine("--Cadastrar Produto--");

    Console.WriteLine("\nDigite o nome do produto");
    string nome = Console.ReadLine()!;
    if (produtos.ContainsKey(nome))
    {
        Console.WriteLine("Produto já cadastrado!");
        VoltarAoMenuPrincipal();
        return;
    }

    Console.WriteLine("\nDigite o preço do produto");
    double preco = double.Parse(Console.ReadLine()!);

    produtos.Add(nome, preco);

    Console.WriteLine($"Produto {nome} cadastrado com sucesso!");
    VoltarAoMenuPrincipal();
}

void ListarProdutos()
{
    Console.Clear();
    Console.WriteLine("--Listar Produtos--");
    foreach (var produto in produtos)
    {
        Console.WriteLine($"Código: {produto.Key} - Preço: {produto.Value}");
    }
    VoltarAoMenuPrincipal();
}

ExibirMenuDeOpcoes();