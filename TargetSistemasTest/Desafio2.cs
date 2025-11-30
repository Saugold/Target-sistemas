using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TargetSistemasTest
{
    public class Produto
    {
        public int codigoProduto { get; set; }
        public string? descricaoProduto { get; set; }
        public int estoque { get; set; }
    }

    public class EstoqueData
    {
        public List<Produto>? estoque { get; set; }
    }

    public static class Desafio2
    {
        public static void Executar()
        {
            string filePath = "estoque.json";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Arquivo estoque.json não encontrado.");
                return;
            }

            try
            {
                string jsonString = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var estoqueData = JsonSerializer.Deserialize<EstoqueData>(jsonString, options);

                if (estoqueData?.estoque == null)
                {
                    Console.WriteLine("Estoque vazio ou inválido.");
                    return;
                }

                Console.WriteLine("\n--- Controle de Estoque ---");
                Console.WriteLine("Produtos disponíveis:");
                foreach (var p in estoqueData.estoque)
                {
                    Console.WriteLine($"ID: {p.codigoProduto} | {p.descricaoProduto} | Qtd: {p.estoque}");
                }

                Console.Write("\nDigite o ID do produto para movimentar: ");
                if (!int.TryParse(Console.ReadLine(), out int idProduto))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }

                var produto = estoqueData.estoque.FirstOrDefault(p => p.codigoProduto == idProduto);
                if (produto == null)
                {
                    Console.WriteLine("Produto não encontrado.");
                    return;
                }

                Console.Write("Digite o ID da movimentação (ex: 1001): ");
                string? idMovimentacao = Console.ReadLine();

                Console.Write("Digite a descrição da movimentação (ex: Venda, Reposição): ");
                string? descricao = Console.ReadLine();

                Console.Write("Tipo de movimentação (E - Entrada, S - Saída): ");
                string? tipo = Console.ReadLine()?.ToUpper();

                Console.Write("Quantidade: ");
                if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
                {
                    Console.WriteLine("Quantidade inválida. Deve ser maior que zero.");
                    return;
                }

                if (tipo == "S")
                {
                    if (produto.estoque < quantidade)
                    {
                        Console.WriteLine("Erro: Estoque insuficiente para realizar a saída.");
                        return;
                    }
                    produto.estoque -= quantidade;
                }
                else if (tipo == "E")
                {
                    produto.estoque += quantidade;
                }
                else
                {
                    Console.WriteLine("Tipo de movimentação inválido.");
                    return;
                }

                Console.WriteLine("\n--- Movimentação Realizada com Sucesso ---");
                Console.WriteLine($"Movimentação ID: {idMovimentacao}");
                Console.WriteLine($"Descrição: {descricao}");
                Console.WriteLine($"Produto: {produto.descricaoProduto}");
                Console.WriteLine($"Novo Estoque: {produto.estoque}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
