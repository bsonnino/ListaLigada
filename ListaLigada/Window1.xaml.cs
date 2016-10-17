using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ListaLigada
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Variáveis privadas com estruturas de dados

        private readonly Arvore arvore = new Arvore();
        private readonly Fila<string> fila = new Fila<string>();
        private readonly Lista<string> lista = new Lista<string>();
        private readonly Pilha<string> pilha = new Pilha<string>();

        #endregion

        public Window1()
        {
            InitializeComponent();
        }

        #region Funções de lista

        private void CriaElementoLista(int numElemento)
        {
            var el = new ElementoUI();
            el.Conteudo = lista[numElemento];
            Canvas.SetLeft(el, -60);
            canvas1.Children.Add(el);
            var duration = new Duration(TimeSpan.FromSeconds(0.1*numElemento));
            var da1 = new DoubleAnimation(numElemento*58, duration);
            da1.DecelerationRatio = 0.5;
            el.BeginAnimation(Canvas.LeftProperty, da1);
        }

        private void RemoveElementoLista(int numElemento)
        {
            canvas1.Children.RemoveAt(numElemento);

            for (int i = numElemento; i < canvas1.Children.Count; i++)
            {
                var duration = new Duration(TimeSpan.FromSeconds(0.2));
                var da1 = new DoubleAnimation();
                da1.Duration = duration;
                da1.By = -58;
                canvas1.Children[i].BeginAnimation(Canvas.LeftProperty, da1);
            }
        }

        private void btnInsere_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                int numElemento = lista.Insere(textBox1.Text);
                AtualizaLista();
                CriaElementoLista(numElemento - 1);
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }

        private void AtualizaLista()
        {
            LimpaPesquisa();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                int numRemove = lista.Remove(textBox1.Text);
                if (numRemove >= 0)
                    RemoveElementoLista(numRemove);
                AtualizaLista();
            }
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void LimpaPesquisa()
        {
            for (int i = 0; i < canvas1.Children.Count; i++)
                ((ElementoUI) canvas1.Children[i]).Preenchimento = Brushes.LightSalmon;
        }

        private void btnPesquisa_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                int numProcura = lista.Procura(textBox1.Text);
                if (numProcura >= 0)
                {
                    for (int i = 0; i < lista.NumItens; i++)
                    {
                        if (i == numProcura)
                            ((ElementoUI) canvas1.Children[i]).Preenchimento = Brushes.Red;
                        else
                            ((ElementoUI) canvas1.Children[i]).Preenchimento = Brushes.LightSalmon;
                    }
                }
                else
                {
                    LimpaPesquisa();
                    MessageBox.Show("Não encontrado");
                }
            }
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void btnLimpa_Click(object sender, RoutedEventArgs e)
        {
            lista.Limpa();
            LimpaCanvas(canvas1);
            textBox1.Focus();
            textBox1.SelectAll();
        }

        #endregion

        #region Funções de pilha

        private void CriaElementoPilha(int numElemento)
        {
            var el = new ElementoPilha();
            el.Conteudo = textBox2.Text;
            Canvas.SetTop(el, 0);
            Canvas.SetLeft(el, canvas2.ActualWidth/2 - 40);
            canvas2.Children.Add(el);
            var duration = new Duration(TimeSpan.FromSeconds(0.2));
            var da1 = new DoubleAnimation(canvas2.ActualHeight - 20*numElemento - 50, duration);
            da1.DecelerationRatio = 1;
            el.BeginAnimation(Canvas.TopProperty, da1);
        }

        private void RemoveElementoPilha(int numElemento)
        {
            var duration = new Duration(TimeSpan.FromSeconds(0.2));
            var da1 = new DoubleAnimation(0, duration);
            da1.AccelerationRatio = 0.5;
            da1.Completed += da1_Completed;
            canvas2.Children[numElemento].BeginAnimation(Canvas.TopProperty, da1);
        }

        private void da1_Completed(object sender, EventArgs e)
        {
            canvas2.Children.RemoveAt(canvas2.Children.Count - 1);
        }

        private void btnPush_Click(object sender, RoutedEventArgs e)
        {
            if (textBox2.Text != "")
            {
                pilha.Push(textBox2.Text);
                int numItens = pilha.NumItens;
                CriaElementoPilha(numItens - 1);
            }
            textBox2.Focus();
            textBox2.SelectAll();
        }

        private void btnPop_Click(object sender, RoutedEventArgs e)
        {
            if (pilha.NumItens > 0)
            {
                pilha.Pop();
                RemoveElementoPilha(pilha.NumItens);
            }
            else
                MessageBox.Show("Não há itens na pilha");
            textBox2.Focus();
            textBox2.SelectAll();
        }

        private void btnPeek_Click(object sender, RoutedEventArgs e)
        {
            if (pilha.NumItens > 0)
            {
                string item = pilha.Peek();
                MessageBox.Show(string.Format("{0} no topo da pilha\nNúmero de itens na pilha: {1}", item,
                                              pilha.NumItens));
            }
            else
                MessageBox.Show("Não há itens na pilha");
            textBox2.Focus();
            textBox2.SelectAll();
        }

        private void btnLimpaPilha_Click(object sender, RoutedEventArgs e)
        {
            pilha.Limpa();
            LimpaCanvas(canvas2);
            textBox2.Focus();
            textBox2.SelectAll();
        }

        #endregion

        #region Funções de fila

        private void CriaElementoFila(int numElemento)
        {
            var el = new ElementoFila();
            el.Conteudo = textBox3.Text;
            Canvas.SetLeft(el, canvas3.ActualWidth + 60);
            canvas3.Children.Add(el);
            var duration = new Duration(TimeSpan.FromSeconds(0.2));
            var da1 = new DoubleAnimation(numElemento*58, duration);
            da1.DecelerationRatio = 1;
            el.BeginAnimation(Canvas.LeftProperty, da1);
        }

        private void RemoveElementoFila()
        {
            var duration = new Duration(TimeSpan.FromSeconds(0.2));
            canvas3.Children.RemoveAt(0);
            for (int i = 0; i < canvas3.Children.Count; i++)
            {
                var da1 = new DoubleAnimation();
                da1.Duration = duration;
                da1.By = -58;
                canvas3.Children[i].BeginAnimation(Canvas.LeftProperty, da1);
            }
        }

        private void btnEnqueue_Click(object sender, RoutedEventArgs e)
        {
            if (textBox3.Text != "")
            {
                fila.Enqueue(textBox3.Text);
                CriaElementoFila(fila.NumItens - 1);
            }
            textBox3.Focus();
            textBox3.SelectAll();
        }

        private void btnDequeue_Click(object sender, RoutedEventArgs e)
        {
            if (fila.NumItens > 0)
            {
                fila.Dequeue();
                RemoveElementoFila();
            }
            else
                MessageBox.Show("Não há itens na fila");
            textBox3.Focus();
            textBox3.SelectAll();
        }

        private void btnLimpaFila_Click(object sender, RoutedEventArgs e)
        {
            fila.Limpa();
            LimpaCanvas(canvas3);
            textBox3.Focus();
            textBox3.SelectAll();
        }

        #endregion

        #region Funções de árvore

        private string caminhoAtual;
        private NoArvore noAtual;

        private BitmapImage CriaImagem(string nomeImagem)
        {
            return new BitmapImage(new Uri("imagens\\" + nomeImagem, UriKind.Relative));
        }

        private void btnAdiciona_Click(object sender, RoutedEventArgs e)
        {
            double x;
            double y;
            double tamanhoAtual = canvas4.ActualWidth/2;

            if (textBox4.Text != "")
            {
                try
                {
                    LimpaAtual();
                    NoArvore noInsere = arvore.Insere(textBox4.Text);
                    string caminho = arvore.CaminhoNo(textBox4.Text);
                    y = (caminho.Length*40) + 10;
                    x = tamanhoAtual;
                    for (int i = 0; i < caminho.Length; i++)
                    {
                        tamanhoAtual /= 2;
                        if (caminho[i] == '1')
                            x -= tamanhoAtual;
                        else
                            x += tamanhoAtual;
                    }
                    var el = new ElementoArvore();
                    el.Imagem = CriaImagem("Folha1Arvore.png");
                    el.Conteudo = textBox4.Text;
                    Canvas.SetLeft(el, x - 15);
                    Canvas.SetTop(el, y);
                    canvas4.Children.Add(el);
                    noInsere.ElementoGrafico = el;
                    if (noInsere.NoPai != null)
                    {
                        InsereLinha(noInsere);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            textBox4.Focus();
            textBox4.SelectAll();
        }

        private void InsereLinha(NoArvore noArvore)
        {
            var l = new Line();
            l.X1 = Canvas.GetLeft(noArvore.NoPai.ElementoGrafico) + 15;
            l.Y1 = Canvas.GetTop(noArvore.NoPai.ElementoGrafico) + 15;
            l.X2 = Canvas.GetLeft(noArvore.ElementoGrafico) + 15;
            l.Y2 = Canvas.GetTop(noArvore.ElementoGrafico) + 15;
            l.StrokeThickness = 1;
            Panel.SetZIndex(l, -1);
            l.Stroke = Brushes.Black;
            canvas4.Children.Add(l);
            noArvore.ElementoGrafico.Conector = l;
        }

        private void btnDeleta_Click(object sender, RoutedEventArgs e)
        {
            if (textBox4.Text != "")
            {
                arvore.Exclui(textBox4.Text);
                RedesenhaArvore();
            }
            textBox4.Focus();
            textBox4.SelectAll();
        }

        private void DesenhaNoArvore(NoArvore noArvore, double x, double y, double tamanhoAtual)
        {
            ElementoArvore el = noArvore.ElementoGrafico;

            Canvas.SetLeft(el, x - 15);
            Canvas.SetTop(el, y);
            tamanhoAtual /= 2;
            canvas4.Children.Add(el);
            if (noArvore.NoDireito != null)
                DesenhaNoArvore(noArvore.NoDireito, x + tamanhoAtual, y + 40, tamanhoAtual);
            if (noArvore.NoEsquerdo != null)
                DesenhaNoArvore(noArvore.NoEsquerdo, x - tamanhoAtual, y + 40, tamanhoAtual);
            if (noArvore.NoPai != null)
            {
                el.Conector.X1 = Canvas.GetLeft(noArvore.NoPai.ElementoGrafico) + 15;
                el.Conector.Y1 = Canvas.GetTop(noArvore.NoPai.ElementoGrafico) + 15;
                el.Conector.X2 = Canvas.GetLeft(noArvore.ElementoGrafico) + 15;
                el.Conector.Y2 = Canvas.GetTop(noArvore.ElementoGrafico) + 15;
                Panel.SetZIndex(el.Conector, -1);
                canvas4.Children.Add(el.Conector);
            }
        }

        private void LimpaCanvas(Canvas canvas)
        {
            for (int i = canvas.Children.Count - 1; i >= 0; i--)
            {
                canvas.Children.RemoveAt(i);
            }
        }

        private void RedesenhaArvore()
        {
            LimpaCanvas(canvas4);
            if (arvore.Raiz != null)
                DesenhaNoArvore(arvore.Raiz, canvas4.ActualWidth/2, 10, canvas4.ActualWidth/2);
        }

        private void btnProcura_Click(object sender, RoutedEventArgs e)
        {
            if (textBox4.Text != "")
                try
                {
                    caminhoAtual = arvore.CaminhoNo(textBox4.Text);
                    LimpaAtual();
                    noAtual = arvore.Raiz;
                    noAtual.ElementoGrafico.Imagem = CriaImagem("Folha2Arvore.png");
                    var timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(500);
                    timer.Tick += timer_Tick;
                    timer.IsEnabled = true;
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            textBox4.Focus();
            textBox4.SelectAll();
        }

        private void LimpaAtual()
        {
            if (noAtual != null)
                noAtual.ElementoGrafico.Imagem = CriaImagem("Folha1Arvore.png");
            noAtual = null;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (caminhoAtual == "")
            {
                ((DispatcherTimer) sender).IsEnabled = false;
                return;
            }
            if (noAtual != null)
                noAtual.ElementoGrafico.Imagem = CriaImagem("Folha1Arvore.png");
            if (noAtual != null)
            {
                if (caminhoAtual[0] == '1')
                    noAtual = noAtual.NoEsquerdo;
                else
                    noAtual = noAtual.NoDireito;
            }
            caminhoAtual = caminhoAtual.Substring(1);
            if (noAtual != null)
                noAtual.ElementoGrafico.Imagem = CriaImagem("Folha2Arvore.png");
        }

        private void btnLimpaArvore_Click(object sender, RoutedEventArgs e)
        {
            arvore.Limpa();
            RedesenhaArvore();
            textBox4.Focus();
            textBox4.SelectAll();
        }

        #endregion
    }
}