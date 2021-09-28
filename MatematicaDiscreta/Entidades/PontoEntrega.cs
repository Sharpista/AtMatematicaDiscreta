using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematicaDiscreta.Entidades
{
    public class PontoEntrega
    {
        public string Identificador { get; set; }
        public string Nome { get; set; }
        public Caminhao Caminhao { get; set; }
        public Dictionary<string, ItemEntrega> Items { get; set; }

        public PontoEntrega()
        {
            Items = new Dictionary<string, ItemEntrega>();
        }
        public void  AddItem(ItemEntrega itemEntrega)
        {


            if (!Items.ContainsKey(itemEntrega.Identificador))
            {
                Items.Add(itemEntrega.Identificador, itemEntrega);
            }
            else
            {
                Console.WriteLine($"O {itemEntrega.Nome} que você está tentando associar ja está associado a este PontoEntrega: {Nome}");

            }


        }

       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"IDENTIFICADOR : {Identificador}");
            sb.Append("\n");
            sb.Append($"NOME : {Nome}");
            sb.Append("\n");
            sb.Append("__________________________________");
            return sb.ToString();


        }
        
    }
}
