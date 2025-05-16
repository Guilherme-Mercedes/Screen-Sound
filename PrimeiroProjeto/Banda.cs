using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroProjeto
{
    internal class Banda
    {
        public string Nome { get; set; }
        public List<int> Notas { get; set; }
        public Banda(string nome)
        {
            Nome = nome;
            Notas = new List<int>();
        }
        public override string ToString()//retorna o nome da banda quando for imprimir a lista de bandas
        {
            return Nome;
        }

        //um get para calcular a media das notas, lembrar de usar o 0 para a condicao do null na funcao ExibirMediaBanda
        public double Media => Notas.Count > 0 ? Notas.Average() : 0;
    }
}
