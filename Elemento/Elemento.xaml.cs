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

namespace Elemento
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ElementoUI : UserControl
    {
        public ElementoUI()
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
            DependencyProperty.Register("Conteudo", typeof(string), typeof(ElementoUI), new UIPropertyMetadata(null));



        public Brush Preenchimento
        {
            get { return (Brush)GetValue(PreenchimentoProperty); }
            set { SetValue(PreenchimentoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Preenchimento.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PreenchimentoProperty =
            DependencyProperty.Register("Preenchimento", typeof(Brush), typeof(ElementoUI), new UIPropertyMetadata(Brushes.LightSalmon));

    }
}
