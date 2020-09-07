using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security.Permissions;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PROYECTO1LENGUAJES.Automatas
{
    class AFD__Numero_Entero
    {
        private Boolean aceptacion = false;
        private int transicion = 1;
        private Boolean invalid_token = false;
        public AFD__Numero_Entero()
        {

        }
        public void tranciciones(String cadena)
        {
            for(int i = 0; i < cadena.Length; i++)
            {
                if (!invalid_token)
                {
                    char caracter = Convert.ToChar(cadena.Substring(i, 1));
                    if(transicion == 1)
                    {
                        Estado1(caracter);
                    }
                    if(transicion == 2)
                    {
                        Estado2(caracter);
                    }
                }
                else
                {
                    break;
                }
            }
        }
        
        private void Estado1(char caracter)
        {
            if (numeros(caracter))
            {
                transicion = 2;
            }
            else
            {
                invalid_token = true;
            }
        }
        private void Estado2(char caracter)
        {
            if (numeros(caracter)){
                transicion = 2;
                aceptacion = true;
            }
            else
            {
                aceptacion = false;
                invalid_token = true;
            }
        }
        private Boolean letraMayuscula(char caracter)
        {
            int acii = System.Convert.ToInt32(caracter);
            if ((acii >= 65 && acii <= 90))
            {
                return true;
            }
            return false;
        }
        private Boolean letraMinuscula(char caracter)
        {
            int acii = System.Convert.ToInt32(caracter);
            if (((acii >= 97 && acii <= 122)))
            {
                return true;
            }
            return false;
        }
        private Boolean numeros(char caracter)
        {
            int acii = System.Convert.ToInt32(caracter);
            if ((acii >= 48 && acii <= 57))
            {
                return true;
            }
            return false;
        }
    }
}
