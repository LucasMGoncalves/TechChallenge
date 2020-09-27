using System;
using System.Linq;
using TechChallenge.Lib;

namespace TechChallenge.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string OPCOES_MENU = @"O que deseja fazer:
1 - Obter todos divisores de um número
2 - Obter somente divisores primos de um número
3 - Limpar
4 - Sair

Opçao: ";

            try
            {
                int opcao, numero;

                opcao = ValidarEntradaNumerica(OPCOES_MENU, "Opção inválida!");

                while (opcao != 4)
                {
                    if (opcao == 1)
                    {
                        numero = ValidarEntradaNumerica("Informe um número: ", "Número inválido!");

                        Console.WriteLine("\nOs divisores do número informado são: ");
                        Console.WriteLine(string.Join(", ", NumerosLib.ObterDivisores(numero)));
                    }
                    else if (opcao == 2)
                    {
                        numero = ValidarEntradaNumerica("Informe um número: ", "Número inválido!");

                        Console.WriteLine("\nOs divisores primos do número informado são: ");
                        Console.WriteLine(string.Join(", ", NumerosLib.DecomporEmFatoresPrimos(numero, false)));
                    }
                    else if (opcao == 3)
                    {
                        Console.Clear();
                    }
                    else if (opcao == 4)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("\nOpção inválida!");
                    }

                    Console.Write("\n\n" + OPCOES_MENU);
                    opcao = int.Parse(Console.ReadLine());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Desculpe, ocorreu um erro inesperado.\n Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Válida um número informado pelo usuário
        /// </summary>
        /// <param name="msgEntrada">Mensagem a ser exibida ao solicitar a entrada</param>
        /// <param name="msgErro">Mensagem de erro a ser exibida</param>
        /// <returns></returns>
        private static int ValidarEntradaNumerica(string msgEntrada, string msgErro)
        {
            int numero;
            Console.Write("\n" + msgEntrada);

            string input = Console.ReadLine();

            while (!int.TryParse(input, out numero))
            {
                Console.Write("\n" + msgErro);
                Console.Write("\n" + msgEntrada);

                input = Console.ReadLine();
            }

            return numero;
        }
    }
}
