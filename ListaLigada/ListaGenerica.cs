using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaLigada
{
    class NoLista<T>
    {
        public NoLista()
        {
            Proximo = null;
        }

        public T Objeto { get; set; }
        public NoLista<T> Proximo { get; set; }
    }

    class Lista<T>
    {
        private int numItens = 0;
        private NoLista<T> topo = null;
        private NoLista<T> ultimo = null;

        public int Insere(T obj)
        {
            NoLista<T> noLista = new NoLista<T>() { Objeto = obj };
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

        public int InsereEm(T obj, int posicao)
        {
            NoLista<T> atual;
            NoLista<T> noInsere = new NoLista<T>() { Objeto = obj };
            int numAtual = 0;

            if (posicao == 0)
            {
                noInsere.Proximo = topo;
                topo = noInsere;
                numItens++;
                return 0;
            }

            if (posicao < 0 || posicao >= numItens)
                throw (new IndexOutOfRangeException());

            atual = topo;
            numAtual = 0;
            while (numAtual < posicao - 1)
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

        public int Procura(T obj)
        {
            NoLista<T> atual;
            int numAtual;

            atual = topo;
            numAtual = 0;
            while (atual != null)
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

        private T GetItem(int indice)
        {
            NoLista<T> atual;
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

        public T this[int indice]
        {
            get
            {
                return GetItem(indice);
            }
        }

        public int Remove(T obj)
        {
            NoLista<T> atual;
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

            numAtual = 1;
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
