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

        private List<String> resultadoLexico = new List<String>();

        //Constructor vacio de la clase de componentes linguisticos
        public ComponentesLinguisticos()
        {
            String proye1ct0 = "";

        }

        public void verificacionExprecion(List<String> cadenas)
        {
            foreach (String subcadena in cadenas)
            {
                coincidendiaPrimitiva(subcadena);
            }
        }
        
        private Boolean coincidendiaPrimitiva(String Cadena)
        {

            return false;
        }
        
    }

}
