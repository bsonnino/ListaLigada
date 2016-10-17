using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaLigada
{
    class NoPilha
    {
        public NoPilha()
        {
            Proximo = null;
        }

        public object Objeto { get; set; }
        public NoPilha Proximo { get; set; }
    }

    class Pilha
    {
        private NoPilha topo = null;
        private int numItens = 0;

        public void Push(object obj)
        {
            NoPilha noPilha = new NoPilha() { Objeto = obj };
            noPilha.Proximo = topo;
            topo = noPilha;
            numItens++;
        }

        public object Peek()
        {
            if (topo != null)
                return topo.Objeto;
            else
                return null;
        }

        public object Pop()
        {
            if (topo != null)
            {
                NoPilha result = topo;
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
            numItens = 0;
        }
    }
}
