using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10
{
    internal class Equipamento
    {
        private int id;
        private TipoEquip tipo;
        private bool avariado;

        public int Id { get => id; }
        public TipoEquip Tipo { get => tipo; }
        public bool Avariado { get => avariado; set => avariado = value; }

        public Equipamento(int id, TipoEquip tipo, bool avariado) 
        { 
            this.id = id;
            this.tipo = tipo;
            this.avariado = avariado;
        }

        public override bool Equals(object obj)
        {
            return this.id.Equals(((Equipamento)obj).Id);
        }
    }
}
