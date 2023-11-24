using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09
{
    internal class Garagem
    {
        static int preId = 1;
        private int id;
        private string nome;
        private Stack<Carro> carros;

        public Garagem(string nome)
        {
            this.id = preId++;
            this.nome = nome;
            this.carros = new Stack<Carro>();
        }

        public Garagem(int id)
        {
            this.id=id;
            this.nome = "";
            this.carros = new Stack<Carro>();
        }

        public int Id { get => id; }
        public string Nome { get => nome; set => nome = value; }
        internal Stack<Carro> Carros { get => carros; set => carros = value; }

        public void colocaCarro(Carro carro)
        {
            this.carros.Push(carro);
        }

        public Carro liberaCarro()
        {
            return this.carros.Pop();
        }

        public string mostraCarros()
        {
            string ret = "Quantidade Total: " + this.carros.Count + "\n-----------------------------------------\n";

            foreach(Carro carro in this.carros)
            {
                ret += carro.Id + ". Lotacão máxima: " + carro.LotMax + "\n";
            }
            return ret;
        }

        public override bool Equals(object obj)
        {
            return this.id.Equals(((Garagem)obj).Id);
        }
    }
}
