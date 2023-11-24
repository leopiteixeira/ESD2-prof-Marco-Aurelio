using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09
{
    internal class Viagem
    {
        static int preId = 0;
        private int id;
        private Garagem destino;
        private Garagem origem;
        private Carro carro;
        private int passageiros;
        private bool concluida;

        public Viagem(Garagem origem, Garagem destino)
        {
            this.id = preId++;
            this.destino = destino;
            this.origem = origem;
            this.carro = origem.liberaCarro();
            this.passageiros = this.carro.LotMax;
            this.concluida = false;
        }


        public int Id { get => id; }
        public int Passageiros { get => passageiros; }
        public bool Concluida { get => concluida; }
        internal Garagem Destino { get => destino; }
        internal Garagem Origem { get => origem; }
        internal Carro Carro { get => carro; }

        public void concluirViagem()
        {
            this.concluida = true;
            this.destino.colocaCarro(carro);
        }

        public string info()
        {
            return String.Format("{0}. De: {1} | Até: {2} | Passageiros: {3} | Concluida: {4}\n", this.id, this.origem.Nome, 
                                                                                                this.destino.Nome, this.passageiros, 
                                                                                                this.concluida?"sim":"não");
        }

    }
}
