using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    internal class Vendedor
    {

        private int id;
        private string nome;
        private double percComissao;
        private bool vendeu;
        private Venda[] asVendas;

        public int Id { get => id; }
        public string Nome { get => nome; set => nome = value; }
        public double PercComissao { get => percComissao; set => percComissao = value; }
        internal Venda[] AsVendas { get => asVendas; }
        public bool Vendeu { get => vendeu; }

        public Vendedor(int id, string nome, double percComissao)
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao/100;
            this.asVendas = new Venda[31];
            this.vendeu = false;
        }

        public Vendedor(int id): this(id, "null", 0)
        {
        }

        public Vendedor(): this(-1, "null", 0)
        { 
        }

        public void registrarVenda(int dia, Venda venda)
        {
            if (!this.vendeu)
            {
                this.vendeu=true;
            }
            this.asVendas[dia-1] = venda;
        }

        public double valorVendas()
        {
            double sum = 0;
            foreach(Venda venda in this.asVendas)
            {
                if(venda != null)
                {
                    sum += venda.Valor;
                }
                
            }
            return sum;
        }

        public double valorComissao()
        {
            double sum = 0;
            foreach (Venda venda in this.asVendas)
            {
                if (venda != null)
                {
                    sum += venda.Valor;
                }

            }

            return sum * this.percComissao;
        }

        public override string ToString()
        {
            if(this.id != -1)
            {
                return "id: " + this.id.ToString() +
                        " Nome: " + this.nome +
                        " | ";
            }
            return "Sem dados desse vendedor!!";
        }

        public override bool Equals(object obj)
        {
            return this.Id.Equals(((Vendedor)obj).Id);
        }
    }
}
