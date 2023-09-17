using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    internal class Emprestimo
    {
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;

        public DateTime DtDevolucao { get => dtDevolucao; set => dtDevolucao = value; }
        public DateTime DtEmprestimo { get => dtEmprestimo; set => dtEmprestimo = value; }

        public Emprestimo(DateTime dtEmp) 
        { 
            this.dtEmprestimo = dtEmp;
            this.dtDevolucao = new DateTime();
        }

        public override string ToString()
        {
            return String.Format("Emprestado: {0}, Devolvido: {1}\n", this.DtEmprestimo.ToString(new CultureInfo("pt-BR")), this.DtDevolucao.ToString(new CultureInfo("pt-BR")));
        }
    }
}
