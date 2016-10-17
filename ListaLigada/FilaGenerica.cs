using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaLigada
{
    class NoFila<T>
    {
        public NoFila()
        {
            Proximo = null;
        }

        public T Objeto { get; set; }
        public NoFila<T> Proximo { get; set; }
    }

    class Fila<T>
    {
        private NoFila<T> topo = null;
        private NoFila<T> ultimo = null;
        private int numItens = 0;

        public void Enqueue(T obj)
        {
            NoFila<T> noFila = new NoFila<T>() { Objeto = obj };
            numItens++;
            if (ultimo == null)
            {
                ultimo = topo = noFila;
                return;
            }
            ultimo.Proximo = noFila;
            ultimo = noFila;
        }

        public T Dequeue()
        {
            if (topo != null)
            {
                NoFila<T> result = topo;
                topo = topo.Proximo;
                numItens--;
                return result.Objeto;
            }
            throw (new InvalidOperationException("A fila está vazia"));
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
            ultimo = null;
            numItens = 0;
        }

    }
}
