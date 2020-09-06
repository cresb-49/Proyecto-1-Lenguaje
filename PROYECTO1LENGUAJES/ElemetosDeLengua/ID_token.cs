using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1LENGUAJES.ElemetosDeLengua
{
    class ID_token
    {
        private String nombre;
        private String tipo;
        private String valor;
        public ID_token(String nombre, String tipo,String valor)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.valor = valor;
        }
        public String getNombre()
        {
            return this.nombre;
        }
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }
        public String getTipo()
        {
            return this.tipo;
        }
        public void setTipo(String tipo)
        {
            this.tipo = tipo;
        }
        
        public String getValor()
        {
            return this.valor;
        }
        public void setValor(String valor)
        {
            this.valor = valor;
        }
    }
}
