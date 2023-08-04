using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    internal class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public int Max
        {
            get => max;
        }
        public int Qtde
        {
            get => qtde;
        }
        internal Vendedor[] OsVendedores
        {
            get => osVendedores;
        }

        public Vendedores(int max)
        {
            this.max = max;
            this.qtde = 0;
            this.osVendedores = new Vendedor[this.max];
            for (int i = 0; i < this.max; i++)
            {
                this.osVendedores[i] = new Vendedor();
            }
        }

        public string mostrar()
        {
            string s = "";
            double totalVenda = 0;
            double totalComiss = 0;
            foreach (Vendedor v in this.osVendedores)
            {
                if (v.Id != -1)
                {
                    s += v.ToString() + 
                        "valor vendas: " + v.valorVendas().ToString() +
                         " | valor comissão: " + v.valorComissao().ToString() + "\n";
                }
                totalVenda += v.valorVendas();
                totalComiss += v.valorComissao();
            }
            s = s + "TOTAL DE VENDAS: " + totalVenda.ToString() + " TOTAL DE COMISSAO: " + totalComiss.ToString();
            return s;
        }

        public bool addVendedor(Vendedor v)
        {
            bool podeAdicionar = (this.qtde < this.max);
            if (podeAdicionar)
            {
                this.osVendedores[this.qtde++] = v;
            }
            return podeAdicionar;
        }

        public Vendedor searchVendedor(Vendedor v)
        {
            Vendedor vendedorAchado = new Vendedor();
            foreach (Vendedor ven in this.osVendedores)
            {
                if (ven.Equals(v))
                {
                    vendedorAchado = ven;
                    break;
                }
            }
            return vendedorAchado;
        }

        public bool delVendedor(Vendedor v)
        {
            bool podeRemover;

            int i = 0;
            while (i < this.max && !this.osVendedores[i].Equals(v))
            {
                i++;
            }
            podeRemover = i < this.max && !this.osVendedores[i].Vendeu;

            if (podeRemover)
            {
                while (i < this.max - 1)
                {
                    this.osVendedores[i] = this.osVendedores[i + 1];
                    i++;
                }
                this.osVendedores[i] = new Vendedor();
                this.qtde--;
            }
            return podeRemover;
        }
    }
}
