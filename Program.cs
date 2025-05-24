using System;
using System.Security.Policy;
using System.IO;

namespace EditorDeTexto {
    class Program {
        static void Main(string[] args) {
            Menu();
        }

        static void Menu() {

            Console.Clear();

            Console.WriteLine("Bem-vindo(a) ao Editor de Texto!");
            Console.WriteLine("Escolha a operação desejada:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1 - Abrir aquivo");
            Console.WriteLine("2 - Criar novo aquivo");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("-------------------------------");
            short opcao = short.Parse(Console.ReadLine());

            switch(opcao) {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    AbrirArquivo();
                    break;
                case 2:
                    CriarArquivo();
                    break;
                default:
                    Console.WriteLine("Escolha um opção valida");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Menu();
                break;
            }
        }

        static void AbrirArquivo() {

            Console.Clear();

            Console.WriteLine("Qual caminho do arquivo?");
            string caminho = Console.ReadLine();

            // Abrir e Fechar
            using(var arquivo = new StreamReader(caminho)) {
                string texto = arquivo.ReadToEnd(); // Ler o texto até o final
                Console.WriteLine("\n--- Conteúdo do Arquivo ---");
                Console.WriteLine(texto);
                Console.WriteLine("---------------------------\n");
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
            
        }

        static void CriarArquivo() {

            Console.Clear();

            Console.WriteLine("Digite seu texto:  (ESC para sair)");
            Console.WriteLine("----------------------------------");
            string texto = "";

            // Enquanto o usuario não apertar o ESC não sai.
            do {
                texto += Console.ReadLine(); // O que ja tem no texto mais o que o usuario digitou
                texto += Environment.NewLine; // Quebrando a linha no final de cada execução
            } while(Console.ReadKey().Key != ConsoleKey.Escape);
            // Console.ReadKey().Key espera um tecla e informa qual foi pressionada; (.Key): Retorna uma enumeração ConsoleKey que representa a tecla que foi pressionada.

            SalvarArquivo(texto);
            
        }

        static void SalvarArquivo(string texto) {

            Console.Clear();

            Console.WriteLine("Qual o caminho para salvar o arquivo?");
            Console.WriteLine("-------------------------------------");
            var caminho = Console.ReadLine();

            // Abrir e Fechar
            using(var arquivo = new StreamWriter(caminho)) {
                arquivo.Write(texto); // Escrevento um arquivo
            }

            Console.WriteLine($"Arquivo '{caminho}' salvo com sucesso!");
            Console.ReadLine();
            Menu();
            
        }
    }
}