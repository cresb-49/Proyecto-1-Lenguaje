﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace PROYECTO1LENGUAJES
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean archivoCargado =false;
        private String src="";
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
            CampoDeEscritura.Document.PageWidth = 2000;
            this.MenuItemGuardar.IsEnabled = false;
            this.CampoDeEscritura.IsEnabled = false;
        }

        private void ButtonMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            CampoDeEscritura.Document.Blocks.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Source code (*.gt)|*.gt";
            if (openFileDialog.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                src = openFileDialog.FileName;
                String textoLeido = File.ReadAllText(openFileDialog.FileName);
                CampoDeEscritura.AppendText(textoLeido);
                archivoCargado = true;
                this.CampoDeEscritura.IsEnabled = true;
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (archivoCargado == true)
            { 
                File.Delete(src);
                StreamWriter escritura = new StreamWriter(src);
                TextRange rango = new TextRange(CampoDeEscritura.Document.ContentStart, CampoDeEscritura.Document.ContentEnd);
                String linea = rango.Text;
                Console.WriteLine(linea);
                escritura.WriteLine(linea);
                escritura.Close();
            }
            else
            {
                SaveFileDialog guardado = new SaveFileDialog();
                guardado.Filter = "Source code(*.gt) | *.gt";
                guardado.Title = "Guardar Sorce Code";
                guardado.FileName = "Sin titulo 1";
                var resultado = guardado.ShowDialog();
                if (resultado == System.Windows.Forms.DialogResult.OK)
                {
                    //StreamWriter escritura = new StreamWriter(guardado.FileName);
                }
            }
            
        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            CampoDeEscritura.IsEnabled = true;
        }
        
        private void CampoDeEscritura_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextRange textoContenido = new TextRange(CampoDeEscritura.Document.ContentStart, CampoDeEscritura.Document.ContentEnd);
        }
        
    }
}
