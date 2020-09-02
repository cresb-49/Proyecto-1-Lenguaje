using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROYECTO1LENGUAJES
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            propiedadesGraficas();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void propiedadesGraficas()
        {
            Color colorBarra = (Color)ColorConverter.ConvertFromString("#061826");
            Color colorContenedorPrincipal = (Color)ColorConverter.ConvertFromString("#30343F");
            Color colorCamposDeTexto = (Color)ColorConverter.ConvertFromString("#364652");
            BarraID.Background = new SolidColorBrush(colorBarra);
            contenedorPrincipal.Background = new SolidColorBrush(colorContenedorPrincipal);
            tituloApartadoCompilador.Background = new SolidColorBrush(colorBarra);
            CampoDeEscritura.Background = new SolidColorBrush(colorCamposDeTexto);
            CompilerLog.Background = new SolidColorBrush(colorCamposDeTexto);
            CampoDeEscritura.Document.PageWidth = 2000;
        }

    }
}
