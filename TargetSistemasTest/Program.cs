using System;

namespace TargetSistemasTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Teste Target Sistemas ===");
                Console.WriteLine("1. Desafio 1 - Comissão de Vendas");
                Console.WriteLine("2. Desafio 2 - Controle de Estoque");
                Console.WriteLine("3. Desafio 3 - Cálculo de Juros");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Desafio1.Executar();
                        break;
                    case "2":
                        Desafio2.Executar();
                        break;
                    case "3":
                        Desafio3.Executar();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
