using System;
using System.Globalization;

namespace TargetSistemasTest
{
    public static class Desafio3
    {
        public static void Executar()
        {
            Console.WriteLine("\n--- Cálculo de Juros ---");

            Console.Write("Digite o valor do boleto: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valorOriginal))
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");
            string? inputData = Console.ReadLine();
            if (!DateTime.TryParseExact(inputData, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataVencimento))
            {
                Console.WriteLine("Data inválida. Certifique-se de usar o formato dd/MM/yyyy (ex: 29/11/2025).");
                return;
            }

            DateTime hoje = DateTime.Today;

            if (dataVencimento >= hoje)
            {
                Console.WriteLine("O boleto não está vencido. Juros: R$ 0,00");
                Console.WriteLine($"Valor Total a Pagar: {valorOriginal:C}");
                return;
            }

            TimeSpan atraso = hoje - dataVencimento;
            int diasAtraso = atraso.Days;

            decimal taxaDiaria = 0.025m;
            decimal valorJuros = valorOriginal * taxaDiaria * diasAtraso;
            decimal valorTotal = valorOriginal + valorJuros;

            Console.WriteLine($"\nDias de atraso: {diasAtraso}");
            Console.WriteLine($"Valor Original: {valorOriginal:C}");
            Console.WriteLine($"Juros (2,5% ao dia): {valorJuros:C}");
            Console.WriteLine($"Valor Total a Pagar: {valorTotal:C}");
        }
    }
}
