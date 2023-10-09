using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07
{
    internal class Medicamento
    {
        private int id;
        private string nome;
        private string lab;
        private Queue<Lote> lotes;

        public int Id { get => id; }
        public string Nome { get => nome; set => nome = value; }
        public string Lab { get => lab; set => lab = value; }
        internal Queue<Lote> Lotes { get => lotes; set => lotes = value; }

        public Medicamento(int id, string nome, string lab)
        {
            this.id = id;
            this.nome = nome;
            this.lab = lab;
            this.lotes = new Queue<Lote>();
        }

        public Medicamento() : this(-1, " ", " ") { }

        public int qtdeDisp()
        {
            int res = 0;
            foreach (Lote lote in lotes)
            {
                res += lote.Qtde;
            }
            return res;
        }

        public void comprar(Lote lote)
        {
            lotes.Enqueue(lote);
        }

        public bool vender(int qtde)
        {
            bool podeVender = this.qtdeDisp() >= qtde;
            int dec = qtde;
            if(podeVender)
            {
                while(dec != 0)
                {
                    if(dec >= lotes.First().Qtde)
                    {
                        dec -= lotes.First().Qtde;
                        lotes.Dequeue();
                    }
                    else
                    {
                        lotes.First().Qtde -= dec;
                        dec = 0;
                    }
                }
            }
            return podeVender;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2} - {3}", this.id, this.nome, this.lab, this.qtdeDisp());
        }

        public override bool Equals(object obj)
        {
            return this.id.Equals(((Medicamento)obj).Id);
        }
    }
}
