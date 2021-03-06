﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Layout;

namespace PROYECTO1LENGUAJES.ElemetosDeLengua
{
    class SeparadorDeTexto
    {

        private String[] operadoresAritmeticos = new String[] { "+", "-", "*", "/", "++", "--" };
        private String[] operadoresRelacionales = new String[] { ">", "<", ">=", "<=", "==", "!=" };
        private String[] operadoresLogicos = new String[] { "||", "&&", "!" };
        private String[] signoAgrupacion = new string[] {"(",")"};
        private String asignacionDeSentencia = "=";
        private String finalizacionSentencia = ";";
        private String comillas = "\"";

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
        public List<String> abstraccionTexto(String arreglo)
        {
            //agrega el caracter de finalizacion de lectura
            arreglo = arreglo + " "+"\n";
            List<String> palabras = new List<String>();

            int inicio = 0;
            int fin = 0;
            int legth = arreglo.Length;
            String apuntador1;
            String apuntador2;
            int i = 0;

            for (i = 0; i < (legth - 1); i++)
            {
                apuntador1 = arreglo.Substring(i, 1);
                apuntador2 = arreglo.Substring((i + 1), 1);

                if (!(apuntador1.Equals(" ")) && apuntador2.Equals(" "))
                {
                    fin = i;
                    String extraccion = extraerTexto(arreglo, inicio, fin);
                    //Console.WriteLine("Apuntador1: " + apuntador1);
                    //Console.WriteLine("Apuntador2: " + apuntador2);
                    //Console.WriteLine("Aqui 1: " + extraccion + "---");
                    if(extraccion.Equals(comillas) || extraccion.StartsWith(comillas))
                    {
                        //inicio es el mismo de la cadena de segundo analicis
                        //Console.WriteLine("Candidato");
                        int saltoDeLinea = arreglo.IndexOf("\n", inicio);
                        //Console.WriteLine("Salto de linea: " + inicio);
                        int rango = saltoDeLinea - inicio;
                        int segundaComilla = arreglo.IndexOf(comillas,  inicio + 1,rango);
                        //Console.WriteLine("inicio: "+inicio);
                        //Console.WriteLine("Segunda comilla: "+segundaComilla);
                        fin = segundaComilla;
                        extraccion = extraerTexto(arreglo, inicio, fin);
                        palabras.Add(extraccion);
                        inicio = fin + 1;
                        i = fin - 1;
                    }
                    else
                    {
                        palabras.Add(extraccion);
                        inicio = fin + 1;
                    }
                }
                if (apuntador1.Equals(" ") && !(apuntador2.Equals(" ")))
                {
                    inicio = i + 1;
                }
                if (!(saltoPorSignoEspecial(apuntador1)) && saltoPorSignoEspecial(apuntador2))
                {
                    if(apuntador1.Equals(" "))
                    {
                        inicio = i + 1;
                    }
                    else
                    {
                        fin = i;
                        String extraccion = extraerTexto(arreglo, inicio, fin);
                        //Console.WriteLine("Apuntador1: " + apuntador1);
                        //Console.WriteLine("Apuntador2: " + apuntador2);
                        //Console.WriteLine("Aqui 2: " + extraccion + "---");
                        if (extraccion.Equals(comillas) || extraccion.StartsWith(comillas))
                        {
                            //inicio es el mismo de la cadena de segundo analicis
                            //Console.WriteLine("Candidato");
                            int saltoDeLinea = arreglo.IndexOf("\n", inicio);
                            //Console.WriteLine("Salto de linea: " + inicio);
                            int rango = saltoDeLinea - inicio;
                            int segundaComilla = arreglo.IndexOf(comillas, inicio + 1, rango);
                            //Console.WriteLine("inicio: " + inicio);
                            //Console.WriteLine("Segunda comilla: " + segundaComilla);
                            fin = segundaComilla;
                            extraccion = extraerTexto(arreglo, inicio, fin);
                            palabras.Add(extraccion);
                            inicio = fin + 1;
                            i = fin - 1;
                        }
                        else
                        {
                            palabras.Add(extraccion);
                            inicio = fin + 1;
                        }
                    }
                }
                if (saltoPorSignoEspecial(apuntador1) && !(saltoPorSignoEspecial(apuntador2)))
                {
                    if (apuntador2.Equals(" "))
                    {
                        inicio = i + 1;
                    }
                    else
                    {
                        
                        fin = i;
                        inicio = i;
                        String extraccion = extraerTexto(arreglo, inicio, fin);
                        //Console.WriteLine("Aqui 3: " + extraccion +"---");
                        palabras.Add(extraccion);
                        inicio = fin + 1;
                        
                    }
                }
                if (igualdadesAceptadas(apuntador1, apuntador2))
                {
                    if (apuntador1.Equals("/") && apuntador2.Equals("/"))
                    {
                        inicio = i;
                        fin = i + 1;
                        String extraccion = extraerTexto(arreglo, inicio,fin);
                        //Console.WriteLine("aqui 6: " + extraccion + "---");
                        palabras.Add(extraccion);

                        inicio = fin + 1;
                        fin = arreglo.IndexOf("\n", i);

                        extraccion = extraerTexto(arreglo, inicio, fin);
                        //Console.WriteLine("aqui 7: " + extraccion + "---");
                        palabras.Add(extraccion);

                        i = fin - 1;
                        inicio = fin+1;
                    }
                    else
                    {
                        inicio = i;
                        fin = i + 1;
                        String extraccion = extraerTexto(arreglo, inicio, fin);
                        //Console.WriteLine("aqui 4: " + extraccion + "---");
                        palabras.Add(extraccion);
                        inicio = i + 2;
                        i = i + 1;
                        
                    }
                }
                else
                {
                    if (saltoPorSignoEspecial(apuntador1) && saltoPorSignoEspecial(apuntador2))
                    {
                        inicio = i;
                        fin = inicio;
                        String extraccion = extraerTexto(arreglo, inicio, fin);
                        //Console.WriteLine("aqui 5: " + extraccion + "---");
                        palabras.Add(extraccion);
                        inicio = i + 1;
                    }
                }
            }

            return palabras;

        }
        
        private Boolean igualdadesAceptadas(String apuntador1,String apuntador2)
        {
            
            if (apuntador1.Equals("+") && apuntador2.Equals("+"))
            {
                return true;
            }
            if (apuntador1.Equals("-") && apuntador2.Equals("-"))
            {
                return true;
            }
            if (apuntador1.Equals("=") && apuntador2.Equals("="))
            {
                return true;
            }
            if (apuntador1.Equals("|") && apuntador2.Equals("|"))
            {
                return true;
            }
            if (apuntador1.Equals("&") && apuntador2.Equals("&"))
            {
                return true;
            }
            if (apuntador1.Equals(">") && apuntador2.Equals("="))
            {
                return true;
            }
            if (apuntador1.Equals("<") && apuntador2.Equals("="))
            {
                return true;
            }
            if (apuntador1.Equals("!") && apuntador2.Equals("="))
            {
                return true;
            }
            if (apuntador1.Equals("/") && apuntador2.Equals("*"))
            {
                return true;
            }
            if (apuntador1.Equals("*") && apuntador2.Equals("/"))
            {
                return true;
            }
            if (apuntador1.Equals("/") && apuntador2.Equals("/"))
            {
                return true;
            }
            return false;
        }
        private Boolean saltoPorSignoEspecial(String cadena)
        {
            foreach(String valor in operadoresAritmeticos)
            {
                if (cadena.Equals(valor))
                {
                    return true;
                }
            }
            foreach (String valor in operadoresAritmeticos)
            {
                if (cadena.Equals(valor))
                {
                    return true;
                }
            }
            foreach (String valor in operadoresRelacionales)
            {
                if (cadena.Equals(valor))
                {
                    return true;
                }
            }
            foreach (String valor in operadoresLogicos)
            {
                if (cadena.Equals(valor))
                {
                    return true;
                }
            }
            foreach (String valor in signoAgrupacion)
            {
                if (cadena.Equals(valor))
                {
                    return true;
                }
            }
            if (cadena.Equals(asignacionDeSentencia))
            {
                return true;
            }
            if (cadena.Equals(finalizacionSentencia))
            {
                return true;
            }
            return false;
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
            int tam = 0;
            tam = cadena.Length;
            if (tamanoMax <= tam)
            {
                this.tamanoMax = tam;
            }
        }
        public int getTamanoMax()
        {
            return this.tamanoMax;
        }

    }
}
