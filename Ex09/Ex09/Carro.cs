using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09
{
    internal class Carro
    {
        static int preId = 1;
        private int id;
        private int lotMax;

        public Carro(int lotMax)
        {
            this.lotMax = lotMax;
            this.id = preId++;
        }

        public int Id { get => id; }
        public int LotMax { get => lotMax; set => lotMax = value; }

        public override bool Equals(object obj)
        {
            return this.id.Equals(((Carro)obj).Id);
        }


    }
}
