using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09
{
    internal class Garagens
    {
        private List<Garagem> dados;

        public Garagens()
        {
            this.dados = new List<Garagem>();
        }

        internal List<Garagem> Dados { get => dados; set => dados = value; }

        public void adiciona(Garagem garagem)
        {
            this.dados.Add(garagem);
        }

    }
}
