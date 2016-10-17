using System;
using System.Text;
using System.Windows;

namespace ListaLigada
{
    class NoArvore
    {
        public NoArvore NoPai { get; set; }
        public NoArvore NoDireito { get; set; }
        public NoArvore NoEsquerdo { get; set; }
        public ElementoArvore ElementoGrafico { get; set; }
        public string Objeto { get; set; }
    }

    class Arvore
    {
        public NoArvore Raiz { get; set; }

        public NoArvore Insere(string obj)
        {
            NoArvore noInsere = new NoArvore() { Objeto = obj };
            NoArvore noAtual = Raiz;
            Boolean inseriu = false;

            if (Raiz == null)
            {
                Raiz = noInsere;
                return noInsere;
            }

            while (!inseriu)
            {
                if (string.Compare(obj, noAtual.Objeto) < 0)
                {
                    if (noAtual.NoEsquerdo != null)
                        noAtual = noAtual.NoEsquerdo;
                    else
                    {
                        noInsere.NoPai = noAtual;
                        noAtual.NoEsquerdo = noInsere;
                        inseriu = true;
                    }
                }
                else if (string.Compare(obj, noAtual.Objeto) > 0)
                {
                    if (noAtual.NoDireito != null)
                        noAtual = noAtual.NoDireito;
                    else
                    {
                        noInsere.NoPai = noAtual;
                        noAtual.NoDireito = noInsere;
                        inseriu = true;
                    }
                }
                else
                    throw new InvalidOperationException("Objeto já está na árvore");
            }
            return noInsere;
        }

        private NoArvore PesquisaNo(string obj)
        {
            NoArvore noAtual = Raiz;
            try
            {
                while (true)
                {
                    int compara = string.Compare(obj, noAtual.Objeto);
                    if (compara < 0)
                    {
                        if (noAtual.NoEsquerdo != null)
                            noAtual = noAtual.NoEsquerdo;
                        else
                            throw new InvalidOperationException("Objeto não encontrado");
                    }
                    else if (compara > 0)
                    {
                        if (noAtual.NoDireito != null)
                            noAtual = noAtual.NoDireito;
                        else
                            throw new InvalidOperationException("Objeto não encontrado");
                    }
                    else
                        return noAtual;
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;

        }

        public string CaminhoNo(string obj)
        {
            NoArvore noAtual = Raiz;
            StringBuilder caminho = new StringBuilder("");

            while (true)
            {
                int compara = string.Compare(obj, noAtual.Objeto);
                if (compara < 0)
                {
                    caminho.Append("1");
                    if (noAtual.NoEsquerdo != null)
                        noAtual = noAtual.NoEsquerdo;
                    else
                        throw new InvalidOperationException("Objeto não encontrado");
                }
                else if (compara > 0)
                {
                    caminho.Append("2");
                    if (noAtual.NoDireito != null)
                        noAtual = noAtual.NoDireito;
                    else
                        throw new InvalidOperationException("Objeto não encontrado");
                }
                else
                    return caminho.ToString();
            }
        }

        private NoArvore ProcuraSucessor(NoArvore noInicial)
        {
            noInicial = noInicial.NoDireito;
            while (noInicial.NoEsquerdo != null)
            {
                noInicial = noInicial.NoEsquerdo;
            }
            return noInicial;
        }

        public NoArvore Exclui(string obj)
        {
            NoArvore noAtual = PesquisaNo(obj);

            if (noAtual.NoDireito == null && noAtual.NoEsquerdo == null)
            {
                if (noAtual.NoPai == null)
                {
                    Raiz = null;
                    return noAtual;
                }

                if (noAtual.NoPai.NoEsquerdo == noAtual)
                    noAtual.NoPai.NoEsquerdo = null;
                else
                    noAtual.NoPai.NoDireito = null;
                return noAtual;
            }

            if (noAtual.NoEsquerdo == null)
            {
                if (noAtual.NoPai == null)
                {
                    Raiz = noAtual.NoDireito;
                    return noAtual;
                }

                if (noAtual.NoPai.NoEsquerdo == noAtual)
                    noAtual.NoPai.NoEsquerdo = noAtual.NoDireito;
                else
                    noAtual.NoPai.NoDireito = noAtual.NoDireito;
                noAtual.NoDireito.NoPai = noAtual.NoPai;
                return noAtual;
            }

            if (noAtual.NoDireito == null)
            {
                if (noAtual.NoPai == null)
                {
                    Raiz = noAtual.NoEsquerdo;
                    return noAtual;
                }

                if (noAtual.NoPai.NoEsquerdo == noAtual)
                    noAtual.NoPai.NoEsquerdo = noAtual.NoEsquerdo;
                else
                    noAtual.NoPai.NoDireito = noAtual.NoEsquerdo;
                noAtual.NoEsquerdo.NoPai = noAtual.NoPai;
                return noAtual;
            }

            NoArvore sucessor = ProcuraSucessor(noAtual);

            noAtual.Objeto = sucessor.Objeto;
            if (noAtual.ElementoGrafico != null && sucessor.ElementoGrafico != null)
                noAtual.ElementoGrafico.Conteudo = sucessor.ElementoGrafico.Conteudo;
            else
                noAtual.ElementoGrafico = sucessor.ElementoGrafico;

            if (sucessor.NoPai.NoEsquerdo == sucessor)
                sucessor.NoPai.NoEsquerdo = null;
            else
            {
                sucessor.NoPai.NoDireito = sucessor.NoDireito;
                sucessor.NoDireito.NoPai = sucessor.NoPai;
            }
            return sucessor;
        }

        public void Limpa()
        {
            Raiz = null;
        }
    }
}
