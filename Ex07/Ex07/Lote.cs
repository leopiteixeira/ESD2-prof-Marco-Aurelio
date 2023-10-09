﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07
{
    internal class Lote
    {
        private int id;
        private int qtde;
        private DateTime venc;

        public int Id { get => id; }
        public int Qtde { get => qtde; set => qtde = value; }
        public DateTime Venc { get => venc; set => venc = value; }

        public Lote(int id, int qtde, DateTime venc)
        {
            this.id = id;
            this.qtde = qtde;
            this. venc = venc;

        }

        public Lote() : this(-1, -1, new DateTime()) { }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2}", this.id, this.qtde, this.venc.ToString("d"));
        }


    }
}
