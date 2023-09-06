using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    internal class Contatos
    {
        private List<Contato> agenda;

        internal List<Contato> Agenda { get => agenda; set => agenda = value; }

        public Contatos()
        { 
            Agenda = new List<Contato>();
        }

        public bool adicionar(Contato contato) 
        {
            bool podeAdd = pesquisar(contato).Equals(new Contato());
            if (podeAdd)
            {
                Agenda.Add(contato);
            }
            return podeAdd;
        }

        public Contato pesquisar(Contato contato)
        {
            foreach (Contato cont in Agenda)
            {
                if (cont.Equals(contato))
                {
                    return cont;
                }
            }

            return new Contato();
        }

        public bool alterar(Contato contato) 
        { 
            bool podeAlt = !pesquisar(contato).Equals(new Contato());
            bool achou = false;
            if (podeAlt)
            {
                int i = 0;
                foreach (Contato cont in Agenda)
                {
                    if (cont.Equals(contato))
                    {
                        achou = true;  
                        break;
                    }
                    i++;
                }
                if (achou)
                {
                    Agenda[i].Email = contato.Email;
                    Agenda[i].Nome = contato.Nome;
                    Agenda[i].Dtnasc = contato.Dtnasc;
                }  
            }
            return podeAlt;
        }

        public bool remover(Contato contato)
        {
            return Agenda.Remove(contato);
        }
    }
}
