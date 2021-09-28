using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematicaDiscreta.Entidades
{
    public class ItemEntrega
    {
        public ItemEntrega()
        {
        }

        public ItemEntrega(string identificador, string nome)
        {
            Identificador = identificador;
            Nome = nome;
        }

        public string Identificador { get; set; }
        public string Nome { get; set; }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"NOME : {Nome}");
            sb.Append("\n");
            sb.Append($"IDENTIFICADOR : {Identificador}");
            sb.Append("\n");
            sb.Append("_________________________________");

            return sb.ToString();
        }
    }
}
