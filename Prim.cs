using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplejidadTest
{
    class Prim
    {
        public class Nodo
        {
            public string valor;
            public bool visitado;
            public List<Arista> vecinos;
            public Nodo(string v)
            {
                valor = v;
                visitado = false;
                vecinos = new List<Arista>();
            }
            public void AddVecino(Nodo n, int d)
            {
                vecinos.Add(new Arista(n, d));
                n.vecinos.Add(new Arista(this, d));
            }
        }
        public class Arista
        {
            public Nodo fin;
            public int distancia;
            public Arista(Nodo n, int d)
            {
                fin = n;
                distancia = d;
            }
        }
        public void Algoritmo(List<Nodo> nodos, Nodo inicio)
        {
            int peso_min = 0;
            inicio.visitado = true;
            List<Nodo> nodos_v = new List<Nodo>();
            nodos_v.Add(inicio);
            while (nodos_v.Count < nodos.Count)
            {
                Arista arista = new Arista(null, int.MaxValue);
                foreach (var n in nodos_v)
                {
                    foreach (var a in n.vecinos)
                        if (a.distancia < arista.distancia && !a.fin.visitado)
                            arista = a;
                }
                if (arista.fin != null)
                {
                    peso_min += arista.distancia;
                    nodos_v.Add(arista.fin);
                    arista.fin.visitado = true;
                }
            }
            Console.WriteLine(peso_min);
        }

        public Prim()
        {
            // Ejemplo:
            Nodo a = new Nodo("a");
            Nodo b = new Nodo("b");
            Nodo c = new Nodo("c");
            Nodo d = new Nodo("d");
            Nodo e = new Nodo("e");
            Nodo f = new Nodo("f");
            Nodo g = new Nodo("g");

            a.AddVecino(b, 2);
            a.AddVecino(c, 3);
            a.AddVecino(d, 3);
            b.AddVecino(c, 4);
            b.AddVecino(e, 3);
            c.AddVecino(d, 5);
            c.AddVecino(f, 6);
            c.AddVecino(e, 1);
            d.AddVecino(f, 7);
            e.AddVecino(f, 8);
            f.AddVecino(g, 9);

            List<Nodo> nodos = new List<Nodo>() { a, b, c, d, e, f, g };

            Algoritmo(nodos, a);

        }
    }
}
