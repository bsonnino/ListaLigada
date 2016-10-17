using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaLigada
{
    class NoLista
    {
        public NoLista()
        {
            Proximo = null;
        }

        public object Objeto { get; set; }
        public NoLista Proximo { get; set; }
    }

    class Lista
    {
        private int numItens = 0;
        private NoLista topo = null;
        private NoLista ultimo = null;

        public int Insere(object obj)
        {
            NoLista noLista = new NoLista() { Objeto = obj };
            if (topo == null)
            {
                topo = noLista;
                ultimo = noLista;
            }
            else
            {
                ultimo.Proximo = noLista;
                ultimo = noLista;
            }
            numItens++;
            return numItens;
        }

        public int InsereEm(object obj, int posicao)
        {
            NoLista atual;
            NoLista noInsere = new NoLista() { Objeto = obj};
            int numAtual = 0;

            if (posicao < 0 || posicao >= numItens)
                throw (new IndexOutOfRangeException());
            
            if (posicao == 0)
            {
                noInsere.Proximo = topo;
                topo = noInsere;
                return 0;
            }

            atual = topo;
            numAtual = 0;
            while (numAtual < posicao-1)
            {
                atual = atual.Proximo;
                numAtual++;
            }
            noInsere.Proximo = atual.Proximo;
            atual.Proximo = noInsere;
            return numAtual;
        }

        public int NumItens
        {
            get
            {
                return numItens;
            }
        }

        public int Procura(object obj)
        {
            NoLista atual;
            int numAtual;

            atual = topo;
            numAtual = 0;
            while (atual.Proximo != null)
            {
                if (atual.Objeto.ToString() == obj.ToString())
                {
                    return numAtual;
                }
                atual = atual.Proximo;
                numAtual++;
            }
            return (-1);
        }

        private object GetItem(int indice)
        {
            NoLista atual;
            int numAtual;

            atual = topo;
            numAtual = 0;
            while (atual != null)
            {
                if (numAtual == indice)
                {
                    return atual.Objeto;
                }
                atual = atual.Proximo;
                numAtual++;
            }

            throw (new IndexOutOfRangeException());
        }

        public object this[int indice]
        {
            get
            {
                return GetItem(indice);
            }
        }

        public int Remove(object obj)
        {
            NoLista atual;
            int numAtual = 0;

            if (topo == null)
                return -1;
            if (topo.Objeto.ToString() == obj.ToString())
            {
                topo = topo.Proximo;
                if (ultimo == topo)
                    ultimo = null;
                numItens--;
                return 0;
            }

            atual = topo;
            while (atual.Proximo != null)
            {
                if (atual.Proximo.Objeto.ToString() == obj.ToString())
                {
                    if (ultimo == atual.Proximo)
                        ultimo = atual;
                    atual.Proximo = atual.Proximo.Proximo;
                    numItens--;
                    return numAtual;
                }
                atual = atual.Proximo;
                numAtual++;
            }
            return -1;
        }

        public void Limpa()
        {
            topo = null;
            numItens = 0;
        }
    }
}
