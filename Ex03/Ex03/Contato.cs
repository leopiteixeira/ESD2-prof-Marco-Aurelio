using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    internal class Contato
    {
        private string email;
        private string nome;
        private Data dtnasc;
        private List<Telefone> telefones;

        public string Email { get => email; set => email = value; }
        public string Nome { get => nome; set => nome = value; }
        internal Data Dtnasc { get => dtnasc; set => dtnasc = value; }
        internal List<Telefone> Telefones { get => telefones; set => telefones = value; }

        public Contato(string email, string nome, Data dtnasc, List<Telefone> telefones)
        {
            this.email = email;
            this.nome = nome;
            this.dtnasc = dtnasc;
            this.telefones = telefones;
        }

        public Contato() : this(" ", " ", new Data(), new List<Telefone>()) { }

        public Contato(string email) : this(email, " ", new Data(), new List<Telefone>()) { }

        public Contato(string email, string nome, Data dtnasc) : this(email, nome, dtnasc, new List<Telefone>()) { }

        public int getIdade()
        {
            return DateTime.Now.Year - this.Dtnasc.Ano;
        }

        public void adicionarTelefone(Telefone telefone)
        {
            this.telefones.Add(telefone);
        }

        public Telefone getPrincipal()
        {
            int i = 0;
            bool achou = false;
            foreach(Telefone t in this.telefones)
            {
                if (t.Principal)
                {
                    achou = true;
                    break;
                }
                i++;
            }
            if (achou)
            {
                return this.telefones[i];
            }
            return new Telefone();
            
        }

        public override string ToString()
        {
            return String.Format("Nome: {0}, Email: {1}, Data nascimento: {2}, Telefone: {3}\n", Nome, Email, Dtnasc.ToString(), getPrincipal().Numero);
        }

        public override bool Equals(object obj)
        {
            return Email.Equals(((Contato)obj).Email);
        }
    }
}
