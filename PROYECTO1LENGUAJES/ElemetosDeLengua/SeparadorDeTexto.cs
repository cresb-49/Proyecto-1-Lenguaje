using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1LENGUAJES.ElemetosDeLengua
{
    class SeparadorDeTexto
    {
        private int tamanoMax=0;
        //Constructor vacio de la separacion de texto
        public SeparadorDeTexto()
        {

        }
        public List<String> lineasTexto(String textoAnalizar)
        {
            List<String> resultados = new List<String>();
            resultados = palabrasEncontadas(textoAnalizar);
            return resultados;
        }
        public String cadenaReortada(String lineaAProcesar)
        {
            String respuesta = "";
            
            return respuesta;
        }
        private String extraerTexto(String cadena, int inicio, int fin)
        {
            String temporal = "";
            for (int i = inicio; i <= fin; i++)
            {
                temporal = temporal + cadena.Substring(i, 1);
            }
            return temporal;
        }
        private int contadorEspacios(String cadenaProcesar)
        {
            int inicio = 0;
            int cantidadEspacios = 0;
            while (cadenaProcesar.IndexOf(" ", inicio) != -1)
            {
                if (cadenaProcesar.IndexOf(" ", inicio) > -1)
                {
                    cantidadEspacios++;
                    inicio = cadenaProcesar.IndexOf(" ", inicio) + 1;
                }
            }
            return cantidadEspacios;
        }
        public List<String> palabrasEncontadas(String arreglo)
        {
            List<String> palabras = new List<String>();
            List<String> subProcesadopalabras = new List<String>();
            int inicio = 0;
            int fin = 0;
            fin = arreglo.IndexOf(" ") - 1;
            for (int i = 0; i < contadorEspacios(arreglo); i++)
            {
                palabras.Add(extraerTexto(arreglo, inicio, fin));
                inicio = fin + 2;
                fin = arreglo.IndexOf(" ", inicio) - 1;
            }
            fin = (arreglo.Length) - 1;
            String textoEncontrado = extraerTexto(arreglo, inicio, fin);
            palabras.Add(textoEncontrado);
            foreach (String cadena in palabras)
            {
                if(!cadena.Equals(""))
                {
                    subProcesadopalabras.Add(cadena);
                }
            }
            return subProcesadopalabras;
        }
        public void ContadorCaracteres(String cadena)
        {

        }
        public int getTamanoMax()
        {
            return this.tamanoMax;
        }

    }
}
