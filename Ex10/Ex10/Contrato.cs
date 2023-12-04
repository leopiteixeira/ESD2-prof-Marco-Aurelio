using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ex10
{
    internal class Contrato
    {
        private static int idCont = 1;
        private int id;
        private DateTime saida;
        private DateTime retorno;
        private Stack<Equipamento> equipamentos;
        private bool liberado = false;
        private bool devolvido = false;

        public Contrato()
        {
            this.equipamentos = new Stack<Equipamento>();
        }

        public int Id { get => id; }
        public DateTime Saida { get => saida; }
        public DateTime Retorno { get => retorno; }
        public bool Liberado { get => liberado; }
        internal Stack<Equipamento> Equipamentos { get => equipamentos; }
        public bool Devolvido { get => devolvido; }

        public void liberaContrato()
        {
            if (!liberado)
            {
                this.liberado = true;
                this.saida = DateTime.Now;
            }
        }

        public void devolveEquipamentos()
        {
            if (liberado && !devolvido)
            {
                this.devolvido = true;
                this.retorno = DateTime.Now;
            }
        }

        public bool adicionaEquips(int cont, TipoEquip tipo)
        {
            bool ret = tipo.Equipamentos.Count >= cont;
            if (ret)
            {
                for(int i = 0; i < cont; i++)
                {
                    this.equipamentos.Push(tipo.Equipamentos.Dequeue());
                }
            }
            if (equipamentos.Count == 1 && ret)
            {
                this.id = idCont++;
            }
            return ret;
        }

        public string consultaContrato()
        {
            string ret = String.Format("{0}. Horário Liberação: {1} / Horário Devolução: {2} / Liberado: {3} / Devolvido: {4}\nEquipamentos:\n",
                                        this.id, this.saida, this.retorno, this.liberado ? "Sim" : "Não", this.devolvido ? "Sim" : "Não");
            foreach(Equipamento equip in this.equipamentos)
            {
                ret += String.Format("{0}. Tipo: {1} / Avariado: {2}\n", equip.Id, equip.Tipo.Nome, equip.Avariado ? "Sim" : "Não");
            }
            return ret;
        }

        public double valorContrato()
        {
            double ret = 0;
            int dias = (int)this.retorno.Subtract(this.saida).TotalDays;
            dias++;
            if (this.devolvido)
            {
                foreach(Equipamento equip in this.equipamentos)
                {
                    ret += equip.Tipo.Val * dias;

                }
            }
            return ret;
        }

    }
}
