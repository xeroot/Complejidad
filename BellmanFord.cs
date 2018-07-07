using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplejidadTest
{
    class BellmanFord
    {
        public class Nodo
        {
            public string valor;
            public int peso_acumulado;
            public Nodo padre;
            public Nodo(string v)
            {
                valor = v;
                peso_acumulado = int.MaxValue;
                padre = null;
            }
        }
        public class Arista
        {
            public Nodo inicio;
            public Nodo fin;
            public int peso;
            public Arista(Nodo i, Nodo f, int p)
            {
                inicio = i;
                fin = f;
                peso = p;
            }
        }
        public void Algoritmo(List<Arista> aristas, List<Nodo> nodos, Nodo inicio)
        {
            //foreach (var a in aristas) if (a.inicio == inicio) { a.inicio.peso_acumulado = 0; break; }
            inicio.peso_acumulado = 0;
            for (int i = 0; i < aristas.Count - 1; i++)
            {
                bool denuevo = false;
                foreach (var a in aristas)
                {
                    Nodo ini = a.inicio;
                    Nodo fin = a.fin;
                    if(ini.peso_acumulado != int.MaxValue)
                        if (ini.peso_acumulado + a.peso < fin.peso_acumulado)
                        {
                            fin.peso_acumulado = ini.peso_acumulado + a.peso;
                            fin.padre = ini;
                            denuevo = true;
                        }
                }
                if (!denuevo) break;
            }

            // armando lista
            List<List<Nodo>> rutas_cortas = new List<List<Nodo>>();
            foreach (var n in nodos)
            {
                Nodo p = n;
                List<Nodo> camino = new List<Nodo>();
                while (p != null)
                {
                    camino.Add(p);
                    p = p.padre;
                }
                camino.Reverse();
                rutas_cortas.Add(camino);
            }

            string resultado = "";
            foreach (var n in nodos)
                resultado += n.valor + ": " + n.peso_acumulado + "\n";
            //Console.WriteLine(resultado);

            foreach (var c in rutas_cortas)
            {
                string r = "";
                foreach (var n in c) { r += "->" + n.valor; }
                Console.WriteLine(c[c.Count - 1].valor + ": " + r);
            }
        }

        public BellmanFord() //main
        {
            // Ejemplo:
            Nodo a = new Nodo("1");
            Nodo b = new Nodo("2");
            Nodo c = new Nodo("3");
            Nodo d = new Nodo("4");
            Nodo e = new Nodo("5");
            Nodo f = new Nodo("6");
            Nodo g = new Nodo("7");
            List<Nodo> nodos = new List<Nodo>() { a, b, c, d, e, f, g };

            Arista ar1 = new Arista(a, b, 6);
            Arista ar2 = new Arista(a, c, 5);
            Arista ar3 = new Arista(a, d, 5);
            Arista ar4 = new Arista(b, e, -1);
            Arista ar5 = new Arista(c, b, -2);
            Arista ar6 = new Arista(c, e, -2);
            Arista ar7 = new Arista(d, c, -2);
            Arista ar8 = new Arista(d, f, -1);
            Arista ar9 = new Arista(e, g, 3);
            Arista ar10 = new Arista(f, g, 3);
            List<Arista> aristas = new List<Arista>() { ar1, ar2, ar3, ar4, ar5, ar6, ar7, ar8, ar9, ar10 };

            Algoritmo(aristas, nodos, nodos[0]);
        }

    }
}
