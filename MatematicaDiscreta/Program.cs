using MatematicaDiscreta.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MatematicaDiscreta
{
    
    public class Program
    {
        public static List<Caminhao> caminhoes = new List<Caminhao>();
        public static List<ItemEntrega> items = new List<ItemEntrega>();
        public static List<PontoEntrega> locais = new List<PontoEntrega>();

        static void Main(string[] args)
        {
            

            Console.WriteLine("Escolha o Algoritmo que deseja iniciar:");
            Console.WriteLine("1 - Logistica de Entregas");
            Console.WriteLine("2 - Ocorrencias de D em V Recursivamente");
            Console.WriteLine("3 - Ocorrencias de D em V Não Recursivo ");

            var opcao = int.Parse(Console.ReadLine());
            
            if (opcao == 1)
            {
                Menu();
            }

            if(opcao == 2)
            {
                AlgoritmoRecursivoNVezes(3);
            }

            if(opcao == 3)
            {
                AlgoritmoNaoRecursivoNVezes();
            }

           
        }
        static void Menu()
        {


             Caminhao caminhao = new Caminhao();
             ItemEntrega item = new ItemEntrega();
             PontoEntrega local = new PontoEntrega();

            

            Console.WriteLine();
            Console.WriteLine("######### BEM VINDO #################");
            Console.WriteLine("SELECIONE UMA DAS OPÇÕES ABAIXO");



            Console.WriteLine("1 - INSERIR PONTO DE ENTREGA");
            Console.WriteLine("2 - INSERIR ITEM DE ENTREGA");
            Console.WriteLine("3 - INSERIR CAMINHÃO");
            Console.WriteLine("4 - ASSOCIAR ITEM  A PONTO DE ENTREGA");
            Console.WriteLine("5 - ASSOCIAR PONTO DE ENTREGA A CAMINHÃO");
            Console.WriteLine("6 - REALIZAR ENTREGA");
            Console.WriteLine("0 - SAIR.");
            Console.WriteLine();

       





            var opcao = int.Parse(Console.ReadLine());


            if (opcao == 1)
            {
                Console.WriteLine("DIGITE O IDENTIFICADOR  DO PONTO DE ENTREGA");
                local.Identificador = Console.ReadLine();
                Console.WriteLine("DIGITE O NOME DO PONTO DE ENTREGA");
                local.Nome = Console.ReadLine();
                locais.Add(local);
                Console.WriteLine();
                Menu();
            }

            else if (opcao == 2)
            {
                Console.WriteLine("DIGITE O IDENTIFICADOR  DO ITEM");
                item.Identificador = Console.ReadLine();
                Console.WriteLine("DIGITE O NOME ITEM");
                item.Nome = Console.ReadLine();
                items.Add(item);
                Console.WriteLine();
                Menu();
            }

            else if (opcao == 3)
            {
                Console.WriteLine("DIGITE O PLACA  DO CAMINHÃO ");
                caminhao.Placa = Console.ReadLine();
                caminhoes.Add(caminhao);
                Console.WriteLine();
                Menu();
            }

            else if (opcao == 4)
            {
                var identificadorItem = "";
                var identificadorLocal = "";
                Console.WriteLine("ITENS CADASTRADOS:");
                items.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("PONTOS DE ENTREGAS CADASTRADOS:");
                locais.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("DIGITE O IDENTIFICADOR DE UM DOS ITENS ACIMA QUE DESEJA ASSOCIAR");
                identificadorItem = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("DIGITE O IDENTIFICADOR DE UM DOS PONTO DE ENTREGA ACIMA QUE DESEJA ASSOCIAR");
                identificadorLocal = Console.ReadLine();

               item =  items.Where(x => x.Identificador == identificadorItem).FirstOrDefault();
               local =  locais.Where(x => x.Identificador == identificadorLocal).FirstOrDefault();

               local.AddItem(item);
               Console.WriteLine();
               Menu();

            }

            else if (opcao == 5)
            {
                var identificadorCaminhao = "";
                var identificadorDoLocal = "";
                Console.WriteLine("PONTO DE ENTREGA CADASTRADOS:");
                locais.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("CAMINHÕES DE ENTREGAS CADASTRADOS:");
                caminhoes.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("DIGITE O IDENTIFICADOR DE UM DOS PONTO DE ENTREGA ACIMA QUE DESEJA ASSOCIAR");
                identificadorDoLocal = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("DIGITE A PLACA DE UM DOS CAMINHOES ACIMA QUE DESEJA ASSOCIAR");
                identificadorCaminhao = Console.ReadLine();

                caminhao = caminhoes.Where(x => x.Placa == identificadorCaminhao).SingleOrDefault();
                local = locais.Where(x => x.Identificador == identificadorDoLocal).SingleOrDefault();
                caminhao.AddLocal(local);

                Menu();

            }
            else if(opcao == 6)
            {

                foreach (var c in caminhoes)
                {
                    Console.WriteLine($"Percurso do caminhão {c.Placa}:");
                    foreach (var (x, y) in c.Locais)
                    {
                        Console.WriteLine($"Visitado ponto de entrega {y.Nome}. Foram entregues os itens: ");

                        foreach (var (a, b) in y.Items)
                        {
                            Console.WriteLine(b);
                        }

                        Console.WriteLine($"Total de pontos de entrega: {c.Locais.Count}");
                        Console.WriteLine($"Total de itens entregues: {y.Items.Count}");
                       
                    }
                }

                locais.Clear(); 
                items.Clear();
                caminhoes.Clear();

                //foreach (var l in locais)
                //{
                //    Console.WriteLine($"Percurso do caminhão {l.Caminhao.Placa}:");
                //    Console.WriteLine($"Visitado ponto de entrega {l.Nome}. Foram entregues os itens: ");
                //    foreach (var (a, b) in l.Items)
                //    {
                //        Console.WriteLine(b);

                //    }

                //    Console.WriteLine($"Total de pontos de entrega: {l.Caminhao.Items.Count} ");
                //    Console.WriteLine($"Total de itens entregues: {l.Items.Count}");

                //}
                Menu();
            }
            else if (opcao == 0)
            {
                Console.WriteLine("SAINDO.......");
            }

        }
        
        static void  AlgoritmoRecursivoNVezes(int n)
        {
            var arr = new List<int>();
            Console.WriteLine("Entre com valor : ");
            int nm = int.Parse(Console.ReadLine());
            int nVezes = 0;

            for (int i = 0; i < 5; i++)
            {
                arr.Add(new Random().Next(1, 10));
            }

            FuncaoRecursiva(arr, nm);

            void FuncaoRecursiva(List<int> v, int p)
            {
                if(v.Count > 0)
                {
                    if(v[0] == p)
                    {
                        
                        nVezes++;
                        v.RemoveAt(0);

                    }
                    else
                    {
                        v.RemoveAt(0);
                        FuncaoRecursiva(v,p);
                    }
                }
            }

            Console.WriteLine($"O Numero de vezes foi {nVezes}");
            Main(null);

        }
        
        static void AlgoritmoNaoRecursivoNVezes()
        {
            var count = 0; 
            Console.WriteLine("Entre com o valor do dado D: ");
            var dadoD = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Entre com o tamanho do Vetor V: ");
            var valorVetorV = int.Parse(Console.ReadLine());

            var arr = new int[valorVetorV];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Random().Next(1, 10);
            }

            foreach (var dado in arr)
            {
                if(dado == dadoD)
                {
                    count++;
                }
            }

            Console.WriteLine($"O numero de ocorrências de {dadoD} no Vetor V foi de {count} vezes !! ");
        }
       
    }
}
