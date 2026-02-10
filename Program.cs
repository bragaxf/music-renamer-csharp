using System;
using System.IO;

namespace MusicRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            // O padrão que você quer remover
            string padrao = "SpotiDownloader.com - ";
            // Pega a pasta onde o .exe está rodando
            string caminhoPasta = AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine("______  ___  ___  ___          _       ______                                     \r\n|  _  \\|_  | |  \\/  |         (_)      | ___ \\                                    \r\n| | | |  | | | .  . |_   _ ___ _  ___  | |_/ /___ _ __   __ _ _ __ ___   ___ _ __ \r\n| | | |  | | | |\\/| | | | / __| |/ __| |    // _ \\ '_ \\ / _` | '_ ` _ \\ / _ \\ '__|\r\n| |/ /\\__/ / | |  | | |_| \\__ \\ | (__  | |\\ \\  __/ | | | (_| | | | | | |  __/ |   \r\n|___/\\____/  \\_|  |_/\\__,_|___/_|\\___| \\_| \\_\\___|_| |_|\\__,_|_| |_| |_|\\___|_|   \r\n                                                                                  \r");
            Console.WriteLine("  __  __         _       _           ___ ___    _   ___   _   \r\n |  \\/  |__ _ __| |___  | |__ _  _  | _ ) _ \\  /_\\ / __| /_\\  \r\n | |\\/| / _` / _` / -_) | '_ \\ || | | _ \\   / / _ \\ (_ |/ _ \\ \r\n |_|  |_\\__,_\\__,_\\___| |_.__/\\_, | |___/_|_\\/_/ \\_\\___/_/ \\_\\\r\n                              |__/                            ");

            Console.WriteLine($"Bem-Vindo, está é a primeira versão e so remove para o SpotiDownloader.com!\n\nLimpando pasta: {caminhoPasta}\n");
            int contador = 0;

            try
            {
                string[] arquivos = Directory.GetFiles(caminhoPasta);
                

                foreach (string caminhoCompleto in arquivos)
                {
                    string nomeArquivo = Path.GetFileName(caminhoCompleto);

                    if (nomeArquivo.StartsWith(padrao, StringComparison.OrdinalIgnoreCase))
                    {
                        string novoNome = nomeArquivo.Replace(padrao, "");
                        string novoCaminho = Path.Combine(caminhoPasta, novoNome);

                        if (!File.Exists(novoCaminho))
                        {
                            File.Move(caminhoCompleto, novoCaminho);
                            Console.WriteLine($"[LIMPO] {novoNome}");
                            contador++;
                        }
                    }
                }
                if (contador == 0)
                {
                    Console.WriteLine("\nNenhum arquivo possui o padrao.");
                }
                else {
                    Console.WriteLine($"\nSucesso! {contador} músicas organizadas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            Console.WriteLine("");
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}