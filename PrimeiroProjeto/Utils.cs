using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroProjeto
{
    internal class Utils
    {
        public static void ExibirLogo()
        {
            Console.Clear();
            Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
            Console.WriteLine("\nSeja bem vindo ao Screen Sound!");
        }

        //Como é só uma funcao para enfeitar texto eu decidi nao colocar ela com retorno
        //Uma funcao para gerar um layout de "-----" nas palavras titulos das opcoes.
        public static void GerarLayoutTitulo(string titulo)
        {
            //eu poderia usar o for, mas usei um constructor da classe string que facilita e deixa o codigo mais limpo
            string linha = new string('-', titulo.Length);
            Console.WriteLine("{0}\n{1}\n{0}\n", linha, titulo);
            

        }

    }
}
