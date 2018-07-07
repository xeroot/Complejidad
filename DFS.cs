using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplejidadTest
{
    class DFS
    {
        public class Nodo
        {
            public string valor;
            public bool visitado;
            public List<Nodo> vecinos;
            public Nodo(string v)
            {
                valor = v;
                visitado = false;
                vecinos = new List<Nodo>();
            }
            public void Agregar(Nodo n)
            {
                vecinos.Add(n);
                n.vecinos.Add(this);
            }
        }
        public bool Algoritmo(Nodo n, Nodo f)
        {
            Console.WriteLine(n.valor);
            n.visitado = true;
            if (n.valor == f.valor) return true;
            foreach (Nodo x in n.vecinos)
                if (!x.visitado)
                    if (Algoritmo(x,f))
                        return true;
            return false;
        }

        public DFS()
        {
            // Ejemplo:
            Nodo a = new Nodo("a");
            Nodo b = new Nodo("b");
            Nodo c = new Nodo("c");
            Nodo d = new Nodo("d");
            Nodo e = new Nodo("e");
            Nodo f = new Nodo("f");
            Nodo g = new Nodo("g");
            Nodo h = new Nodo("h");
            Nodo i = new Nodo("i");
            Nodo j = new Nodo("j");
            Nodo k = new Nodo("k");
            Nodo l = new Nodo("l");

            a.Agregar(b);
            a.Agregar(c);
            c.Agregar(d);
            b.Agregar(g);
            b.Agregar(h);
            g.Agregar(k);
            g.Agregar(i);
            g.Agregar(j);
            j.Agregar(l);
            d.Agregar(e);
            d.Agregar(f);

            Console.WriteLine("Lo encontro?: "+Algoritmo(a,h));
        }

    }
}


/*
private bool BFS(Nodo n)
{
    foreach (Nodo x in n.vecinos)
    {

    }
    n.visitado = true;

    return false;
}
*/
