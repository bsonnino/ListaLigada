using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaLigada
{
    class NoFila
    {
        public NoFila()
        {
            Proximo = null;
        }

        public object Objeto { get; set; }
        public NoFila Proximo { get; set; }
    }

    class Fila
    {
        private NoFila topo = null;
        private NoFila ultimo = null;
        private int numItens = 0;

        public void Enqueue(object obj)
        {
            NoFila noFila = new NoFila() { Objeto = obj };
            ultimo.Proximo = noFila;
            ultimo = noFila;
            if (topo == null)
                topo = ultimo;
            numItens++;
        }

        public object Dequeue()
        {
            if (topo != null)
            {
                NoFila result = topo;
                topo = topo.Proximo;
                numItens--;
                return result.Objeto;
            }
            return null;
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
