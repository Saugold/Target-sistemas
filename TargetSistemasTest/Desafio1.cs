using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TargetSistemasTest
{
    public class Venda
    {
        public string? vendedor { get; set; }
        public decimal valor { get; set; }
    }

    public class VendasData
    {
        public List<Venda>? vendas { get; set; }
    }

    public static class Desafio1
    {
        public static void Executar()
        {
            string filePath = "vendas.json";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Arquivo vendjsn não encontrado");
                return;
            }

            try
            {
                string jsonString = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var vendasData = JsonSerializer.Deserialize<VendasData>(jsonString, options);

                if (vendasData?.vendas == null)
                {
                    Console.WriteLine("Nenhuma venda encontrada no arquivo.");
                    return;
                }

                Console.WriteLine("\n--- Relatório de Comissões ---");

                var comissoesPorVendedor = new Dictionary<string, decimal>();

                foreach (var venda in vendasData.vendas)
                {
                    if (string.IsNullOrEmpty(venda.vendedor)) continue;

                    decimal comissao = 0;

                    if (venda.valor >= 500)
                    {
                        comissao = venda.valor * 0.05m;
                    }
                    else if (venda.valor >= 100)
                    {
                        comissao = venda.valor * 0.01m;
                    }

                    if (!comissoesPorVendedor.ContainsKey(venda.vendedor))
                    {
                        comissoesPorVendedor[venda.vendedor] = 0;
                    }
                    comissoesPorVendedor[venda.vendedor] += comissao;
                }

                foreach (var kvp in comissoesPorVendedor)
                {
                    Console.WriteLine($"Vendedor: {kvp.Key} | Total de Comissão: {kvp.Value:C}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar vendas: {ex.Message}");
            }
        }
    }
}
