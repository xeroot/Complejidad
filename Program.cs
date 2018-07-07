using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComplejidadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Comenzando...\n");

            //DFS dfs = new DFS();
            BellmanFord bellmanFord = new BellmanFord();
            //Prim prim = new Prim();


            Console.WriteLine("\nTermino!");
            Console.ReadLine();
        }
    }
}
