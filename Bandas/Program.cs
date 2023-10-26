using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Screen_Sound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Screen Sound
            string mensagemDeBoasVindas = "Boas vindas (a) ao Screen Sound";
            //List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Calypso" };

            Dictionary<string, List<double>> BandasRegistradas = new Dictionary<string, List<double>>();
            BandasRegistradas.Add("Linkin Park", new List<double> { 10, 8, 6 });
            BandasRegistradas.Add("The Beatles", new List<double>());

            void ExibirLogo()
            {
                Console.WriteLine("Screen Sound");
                Console.WriteLine(mensagemDeBoasVindas);
            }

            void ExibirOpcoesDoMenu()
            {
                ExibirLogo();
                Console.WriteLine("\nDigite 1 para registrar uma banda");
                Console.WriteLine("Digite 2 para mostrar todas as bandas");
                Console.WriteLine("Digite 3 para avaliar uma banda");
                Console.WriteLine("Digite 4 para exibir a média de uma banda");
                Console.WriteLine("Digite 5 para sair");

                Console.Write("\nDigite a sua opção: ");
                string opcaoEscolhida = Console.ReadLine();
                int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

                switch (opcaoEscolhidaNumerica)
                {
                    case 1:
                        RegistrarBanda();
                        break;
                    case 2:
                        MostrarBandasRegistradas();
                        break;
                    case 3:
                        AvaliarUmaBanda();
                        break;
                    case 4:
                        MediaBandas();
                        break;
                    case 5:
                        Console.WriteLine("Tchau tchau :)");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }

            void RegistrarBanda()
            {
                Console.Clear();
                ExibirTituloDasOpcoes("Registro de bandas");
                Console.Write("Digite o nome da banda que deseja registrar: ");
                string nomeDaBanda = Console.ReadLine();
                //listaDasBandas.Add(nomeDaBanda); (faz parte da lista)
                BandasRegistradas.Add(nomeDaBanda, new List<double>());
                Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            void MostrarBandasRegistradas()
            {
                Console.Clear();
                ExibirTituloDasOpcoes("Exibindo todas as bandas registradas");

                //for (int i = 0; i < listaDasBandas.Count; i++)
                //{
                //Console.WriteLine($"Banda: {listaDasBandas[i]}");
                //}

                foreach (string banda in BandasRegistradas.Keys)
                {
                    Console.WriteLine($"Banda: {banda}");
                }

                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();

            }

            void ExibirTituloDasOpcoes(string titulo)
            {
                int QuantidadeDeLetras = titulo.Length;
                string Asteriscos = string.Empty.PadLeft(QuantidadeDeLetras, '*');
                Console.WriteLine(Asteriscos);
                Console.WriteLine(titulo);
                Console.WriteLine(Asteriscos + "\n");
            }

            void AvaliarUmaBanda()
            {
                // digitar qual banda quer avaliar
                // ver se a banda existe
                // atribuir uma nota
                // se não existir volta pro menu

                Console.Clear();
                ExibirTituloDasOpcoes("Avaliar Banda");
                Console.Write("Digite o nome da banda que deseja avaliar: ");    
                string nomeDaBanda = Console.ReadLine();
                if (BandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    Console.Write($"\nQual a nota que a banda {nomeDaBanda} merece: ");
                    double nota = double.Parse(Console.ReadLine());
                    BandasRegistradas[nomeDaBanda].Add(nota);
                    Console.WriteLine($"\nA nota foi registrada com sucesso para a banda {nomeDaBanda}");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
                else
                {
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
                
            }
            
            void MediaBandas()
            {
                Console.Clear();
                ExibirTituloDasOpcoes("Média das bandas");
                Console.WriteLine("Digite o nome da banda que deseja ver a média: ");
                string nomeDaBanda = Console.ReadLine();
                if (BandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    List < double > notasDasBandas = BandasRegistradas[nomeDaBanda];
                    Console.WriteLine($"A média da banda {nomeDaBanda} é {notasDasBandas.Average()}.");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey ();
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
                else 
                {
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
            }

            ExibirOpcoesDoMenu();


        }
    }
}
