using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10
{
    internal class TipoEquip
    {
        private int id;
        private string nome;
        private double val;
        private Queue<Equipamento> equipamentos;

        public int Id { get => id; }
        public string Nome { get => nome; set => nome = value; }
        public double Val { get => val; set => val = value; }
        internal Queue<Equipamento> Equipamentos { get => equipamentos; set => equipamentos = value; }

        public TipoEquip(int id, string nome, double val) 
        { 
            this.id = id;
            this.nome = nome;
            this.val = val;
            this.equipamentos = new Queue<Equipamento>();

        }

        public TipoEquip(int id) : this(id, "", 0) { }

        public bool AdicionaEquip(Equipamento equip)
        {
            bool adicionou = true;
            foreach (Equipamento equipamento in equipamentos)
            {
                if (equipamento.Id.Equals(equip)){ adicionou = false; }
            }
            if (adicionou)
            {
                equipamentos.Enqueue(equip);
            }
            return adicionou;
        }

        public Equipamento RetiraEquip()
        {
            return equipamentos.Dequeue();
        }

        public string consultaEquip()
        {
            string ret = String.Format("{0}. Nome: {1} | Valor Diaria: {2} | Itens Cadastrados:\n", this.id, this.nome, this.val);
            foreach(Equipamento equip in equipamentos)
            {
                ret += String.Format("{0}. Avariado: {1}\n", equip.Id, equip.Avariado ? "Sim" : "Não");
            }
            return ret;
        }

        public override bool Equals(object obj)
        {
            return this.id.Equals(((TipoEquip)obj).Id);
        }
    }
}
