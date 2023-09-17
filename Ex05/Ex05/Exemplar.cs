using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    internal class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos;

        public int Tombo { get => tombo; set => tombo = value; }
        internal List<Emprestimo> Emprestimos { get => emprestimos; set => emprestimos = value; }

        public Exemplar(int t) { 
            
            this.tombo = t;
            this.emprestimos = new List<Emprestimo>();
        }

        public Exemplar() : this(-1) { }

        public bool disponivel()
        {
            if(this.emprestimos.Count > 0) {

                return this.emprestimos.Last().DtDevolucao != new DateTime();
            }
            return true;
        }

        public bool emprestar()
        {
            if(this.disponivel())
            {
                this.emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }
            return false;
        }

        public bool devolver()
        {
            if (!this.disponivel())
            {
                this.emprestimos.Last().DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }

        public int qtdeEmprestimos()
        {
            return this.emprestimos.Count;
        }

        public override bool Equals(object obj)
        {
            return this.tombo.Equals(((Exemplar)obj).Tombo);
        }

        public override string ToString()
        {
            string ret = String.Format("exemplar: {0}\n ", this.tombo);
            foreach (Emprestimo emp in this.emprestimos)
            {
                ret += emp.ToString();
            }
            return ret;
        }
    }
}
