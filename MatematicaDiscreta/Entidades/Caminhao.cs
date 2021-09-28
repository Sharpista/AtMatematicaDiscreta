using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematicaDiscreta.Entidades
{
    public class Caminhao
    {
        public string Placa { get; set; }
        public Dictionary<string, PontoEntrega> Locais { get; set; }
        public List<ItemEntrega> Items { get; set; }

        public Caminhao()
        {
            Locais = new Dictionary<string, PontoEntrega>();
        }

        public void AddLocal(PontoEntrega local)
        {
            if (!Locais.ContainsKey(local.Identificador))
            {
                Locais.Add(local.Identificador, local);
            }
            else
            {
                Console.WriteLine($"{local.Nome} que você está tentando associar ja está associado a este caminhão com a placa : {Placa} ");

            }
     
        }
       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"PLACA : {Placa}");
            sb.Append("\n");
            sb.Append("_____________________");

            return sb.ToString();
        }
    }
}
