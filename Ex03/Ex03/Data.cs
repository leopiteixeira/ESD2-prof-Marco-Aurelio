using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    internal class Data
    {
        private int dia;
        private int mes;
        private int ano;

        public Data(int dia, int mes, int ano) 
        { 
            this.dia = dia;
            this.mes = mes; 
            this.ano = ano;
        }

        public Data() : this(1, 1, 0) { }

        public int Dia { get => dia; set => dia = value; }
        public int Mes { get => mes; set => mes = value; }
        public int Ano { get => ano; set => ano = value; }

        public void setData(int dia, int mes, int ano) {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}/{2}", Dia, Mes, Ano);
        }
    }
}
