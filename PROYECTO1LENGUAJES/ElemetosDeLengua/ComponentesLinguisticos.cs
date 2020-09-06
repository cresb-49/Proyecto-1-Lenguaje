using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1LENGUAJES.ElemetosDeLengua
{
    class ComponentesLinguisticos
    {
        private String[] datosPrimitivos = new String[] { "entero", "decimal", "cadena", "booleano", "caracter" };
        private String[] operadoresAritmeticos = new String[] { "+", "-", "*", "/", "++", "--" };
        private String[] operadoresRelacionales = new String[] { ">", "<", ">=", "<=", "==", "!=" };
        private String[] operadoresLogicos = new String[] { "||", "&&", "!" };
        private String inicioSignoAgrupacion = "(";
        private String FinAgrupacionignoAgrupacion = ")";
        private String asignacionDeSentencia = "=";
        private String finalizacionSentencia = ";";
        private String[] palabrasRecervadas = new String[] { "SI", "SINO", "SINO_SI", "MENTRAS", "HACER", "DESDE", "HASTA", "INCREMENTO" };
        private String[] comentarios = new String[] {"//","/*","*/"};
        //Constructor vacio de la clase de componentes linguisticos
        public ComponentesLinguisticos()
        {

        }
        public Boolean AnalicisPalabrasRecervadas(String cadenaAnalizar)
        {
            for(int i = 0; i < palabrasRecervadas.Length; i++)
            {
                if (cadenaAnalizar.Equals(palabrasRecervadas.GetValue(i)))
                {
                    return true;
                }
            }
            return false;
        }
        public Boolean AnilicisTiposPrimitivos(String cadenaAnalizar)
        {
            for (int i = 0; i < palabrasRecervadas.Length; i++)
            {
                if (cadenaAnalizar.Equals(datosPrimitivos.GetValue(i)))
                {
                    return true;
                }
            }
            return false;
        }
    }

}
