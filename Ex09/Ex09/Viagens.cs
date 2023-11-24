using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex09
{
    internal class Viagens
    {
        private List<Viagem> dados;

        public Viagens()
        {
            dados = new List<Viagem>();
        }

        internal List<Viagem> Dados { get => dados; set => dados = value; }

        public void adiciona(Viagem viagem)
        {
            this.dados.Add(viagem);
        }

        public void esvaziar()
        {
            this.dados.Clear();
        }

        public int quantidadeViagens(Garagem origem, Garagem destino)
        {
            int count = 0;
            foreach(Viagem via in this.dados)
            {
                if(via.Origem.Equals(origem) && via.Destino.Equals(destino))
                {
                    count++;
                }
            }
            return count;
        }

        public string listarViagens(Garagem origem, Garagem destino)
        {
            string ret = "";
            foreach (Viagem via in this.dados)
            {
                if (via.Origem.Equals(origem) && via.Destino.Equals(destino))
                {
                    ret += via.info();
                }
            }
            return ret;
        }

        public int passageirosTransportados(Garagem origem, Garagem destino)
        {
            int count = 0;
            foreach (Viagem via in this.dados)
            {
                if (via.Origem.Equals(origem) && via.Destino.Equals(destino))
                {
                    count += via.Passageiros;
                }
            }
            return count;
        }

        public int passageirosTransportados(Carro carro)
        {
            int count = 0;
            foreach (Viagem via in this.dados)
            {
                if (via.Carro.Equals(carro))
                {
                    count += via.Passageiros;
                }
            }
            return count;
        }

        public bool concluiuTodas()
        {
            List<Viagem> vias= new List<Viagem>(); 
            foreach(Viagem via in this.dados)
            {
                if (!via.Concluida)
                {
                    vias.Add(via);
                    break;
                }
            }
            return vias.Count == 0;
        }
    }
}
