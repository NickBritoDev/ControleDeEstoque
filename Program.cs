using System;
using System.Collections.Generic;

class Program
{
    static List<Produto> estoque = new List<Produto>();

    static void Main(string[] args)
    {
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("========= Gerenciamento de Estoque =========");
            Console.WriteLine("[1] Novo Produto");
            Console.WriteLine("[2] Listar Produtos");
            Console.WriteLine("[3] Remover Produto");
            Console.WriteLine("[4] Entrada de Estoque");
            Console.WriteLine("[5] Saída de Estoque");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("===========================================");

            Console.Write("Digite a opção desejada: ");
            string? opcao = Console.ReadLine();

            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    NovoProduto();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "3":
                    RemoverProduto();
                    break;
                case "4":
                    EntradaEstoque();
                    break;
                case "5":
                    SaidaEstoque();
                    break;
                case "0":
                    sair = true;
                    Console.WriteLine("Saindo do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Digite um número válido.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void NovoProduto()
    {
        Console.WriteLine("==== Novo Produto ====");
        Console.Write("Digite o nome do produto: ");
        string? nome = Console.ReadLine();

        Console.Write("Digite a quantidade inicial do produto: ");
        string? quantidadeInput = Console.ReadLine();
        int quantidade = string.IsNullOrWhiteSpace(quantidadeInput) ? 0 : int.Parse(quantidadeInput);

        Console.Write("Digite o preço do produto: ");
        string? precoInput = Console.ReadLine();
        decimal preco = string.IsNullOrWhiteSpace(precoInput) ? 0 : decimal.Parse(precoInput);

        Console.Write("Digite o autor do produto: ");
        string? autor = Console.ReadLine();

        Console.Write("Digite o gênero do produto: ");
        string? genero = Console.ReadLine();

        if (nome != null && autor != null && genero != null)
        {
            Produto novoProduto = new Produto(nome, quantidade, preco, autor, genero);
            estoque.Add(novoProduto);

            Console.WriteLine("Produto adicionado ao estoque com sucesso!");
        }
        else
        {
            Console.WriteLine("Dados inválidos. Produto não adicionado.");
        }
    }

    static void ListarProdutos()
    {
        Console.WriteLine("==== Produtos no Estoque ====");
        if (estoque.Count == 0)
        {
            Console.WriteLine("Nenhum produto encontrado.");
        }
        else
        {
            foreach (Produto produto in estoque)
            {
                Console.WriteLine(
                    $"Produto: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco}, Autor: {produto.Autor}, Gênero: {produto.Genero}"
                );
            }
        }
    }

    static void RemoverProduto()
    {
        Console.WriteLine("==== Remover Produto ====");
        Console.Write("Digite o nome do produto que deseja remover: ");
        string? nome = Console.ReadLine();

        if (nome != null)
        {
            Produto? produto = estoque.Find(p => p.Nome == nome);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado no estoque.");
            }
            else
            {
                estoque.Remove(produto);
                Console.WriteLine("Produto removido do estoque com sucesso!");
            }
        }
        else
        {
            Console.WriteLine("Nome inválido.");
        }
    }

    static void EntradaEstoque()
    {
        Console.WriteLine("==== Entrada de Estoque ====");
        Console.Write("Digite o nome do produto: ");
        string? nome = Console.ReadLine();

        Console.Write("Digite a quantidade a ser adicionada ao estoque: ");
        string? quantidadeInput = Console.ReadLine();
        int quantidade = string.IsNullOrWhiteSpace(quantidadeInput) ? 0 : int.Parse(quantidadeInput);

        if (nome != null)
        {
            Produto? produto = estoque.Find(p => p.Nome == nome);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado no estoque.");
            }
            else
            {
                produto.Quantidade += quantidade;
                Console.WriteLine("Entrada de estoque realizada com sucesso!");
            }
        }
        else
        {
            Console.WriteLine("Nome inválido.");
        }
    }

    static void SaidaEstoque()
    {
        Console.WriteLine("==== Saída de Estoque ====");
        Console.Write("Digite o nome do produto: ");
        string? nome = Console.ReadLine();

        Console.Write("Digite a quantidade a ser removida do estoque: ");
        string? quantidadeInput = Console.ReadLine();
        int quantidade = string.IsNullOrWhiteSpace(quantidadeInput) ? 0 : int.Parse(quantidadeInput);

        if (nome != null)
        {
            Produto? produto = estoque.Find(p => p.Nome == nome);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado no estoque.");
            }
            else if (produto.Quantidade < quantidade)
            {
                Console.WriteLine("Quantidade insuficiente no estoque.");
            }
            else
            {
                produto.Quantidade -= quantidade;
                Console.WriteLine("Saída de estoque realizada com sucesso!");
            }
        }
        else
        {
            Console.WriteLine("Nome inválido.");
        }
    }
}

class Produto
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
    public string Autor { get; set; }
    public string Genero { get; set; }

    public Produto(string nome, int quantidade, decimal preco, string autor, string genero)
    {
        Nome = nome;
        Quantidade = quantidade;
        Preco = preco;
        Autor = autor;
        Genero = genero;
    }
}
