using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaLigada
{
    class NoPilha<T>
    {
        public NoPilha()
        {
            Proximo = null;
        }

        public T Objeto { get; set; }
        public NoPilha<T> Proximo { get; set; }
    }

    class Pilha<T>
    {
        private NoPilha<T> topo = null;
        private int numItens = 0;

        public void Push(T obj)
        {
            NoPilha<T> noPilha = new NoPilha<T>() { Objeto = obj };
            noPilha.Proximo = topo;
            topo = noPilha;
            numItens++;
        }

        public T Peek()
        {
            if (topo != null)
                return topo.Objeto;
            throw (new InvalidOperationException("A pilha está vazia"));
        }

        public T Pop()
        {
            if (topo != null)
            {
                NoPilha<T> result = topo;
                topo = topo.Proximo;
                numItens--;
                return result.Objeto;
            }
            throw (new InvalidOperationException("A pilha está vazia"));
        }

        public int NumItens
        {
            get
            {
                return numItens;
            }
        }

        public void Limpa()
        {
            topo = null;
            numItens = 0;
        }

    }
}
