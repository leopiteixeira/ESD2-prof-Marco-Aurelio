using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07
{
    internal class Medicamentos
    {
        private List<Medicamento> listaMed;

        public Medicamentos() { this.listaMed = new List<Medicamento>(); }

        internal List<Medicamento> ListaMed { get => listaMed; set => listaMed = value; }

        public void adicionar(Medicamento med)
        {
            if(pesquisar(med).Equals(new Medicamento()))
            {
                listaMed.Add(med);
            }
        }

        public bool deletar(Medicamento med)
        {
            int i = -1;
            foreach(Medicamento rem in listaMed)
            {
                if (rem.Equals(med))
                {
                    i = listaMed.IndexOf(rem);
                }
            }
            bool podeDel = med.qtdeDisp() == 0 && i != -1;
            if (podeDel)
            {
                listaMed.RemoveAt(i);
            }
            return podeDel;
        }

        public Medicamento pesquisar(Medicamento med)
        {
            int i = -1;
            foreach (Medicamento rem in listaMed)
            {
                if (rem.Equals(med))
                {
                    i = listaMed.IndexOf(rem);
                }
            }
            if (i == -1)
            {
                return new Medicamento();
            }
            return listaMed[i];
        }
    }
}
