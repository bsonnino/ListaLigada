using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListaLigada
{
    /// <summary>
    /// Interaction logic for ElementoArvore.xaml
    /// </summary>
    public partial class ElementoArvore : UserControl
    {
        public ElementoArvore()
        {
            InitializeComponent();
        }

        public string Conteudo
        {
            get { return (string)GetValue(ConteudoProperty); }
            set { SetValue(ConteudoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Conteudo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConteudoProperty =
            DependencyProperty.Register("Conteudo", typeof(string), typeof(ElementoArvore), new UIPropertyMetadata(null));





        public ImageSource Imagem
        {
            get { return (ImageSource)GetValue(ImagemProperty); }
            set { SetValue(ImagemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Imagem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagemProperty =
            DependencyProperty.Register("Imagem", typeof(ImageSource), typeof(ElementoArvore), new UIPropertyMetadata(null));


        public Line Conector { get; set; }

    }
}
