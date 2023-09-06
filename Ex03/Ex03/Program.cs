using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    internal class Program
    {

        static Contato criaContato()
        {
            string email, nome;
            int dia, mes, ano;

            Console.WriteLine("Digite o email do contato:");
            email = Console.ReadLine();
            Console.WriteLine("Digite o nome do contato:");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o dia de nascimento:");
            dia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o mes de nascimento:");
            mes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o ano de nascimento:");
            ano = Convert.ToInt32(Console.ReadLine());

            return new Contato(email, nome, new Data(dia, mes, ano));
        }

        static Contato criaContatoSearch()
        {
            string email;
            Console.WriteLine("Digite o email do contato:");
            email = Console.ReadLine();
            return new Contato(email);
        }

        static Telefone criaTelefone()
        {
            string tipo, numero;
            char mei;
            Console.WriteLine("Digite o tipo de telefone:");
            tipo = Console.ReadLine();
            Console.WriteLine("Digite o numero de telefone:");
            numero = Console.ReadLine();
            Console.WriteLine("é o telefone principal?s/n");
            mei = Convert.ToChar(Console.ReadLine());
            return new Telefone(tipo, numero, mei == 's');
        }
        static void Main(string[] args)
        {
            int sel = 1;
            Contatos conts = new Contatos();

            while (sel != 0) 
            {
                Console.WriteLine("0. Sair\n1. Adicionar contato\n2. Adicionar telefone no contato\n3. Pesquisar contato\n4. Alterar contato\n5. Remover contato\n6. Listar contatos ");
                sel = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (sel)
                {
                    case 1: Console.WriteLine(conts.adicionar(criaContato()) ? "Contato adicionado!" : "Falha ao adicionar contato!"); 
                        break;

                    case 2: Contato c1 = criaContatoSearch();
                            conts.pesquisar(c1).adicionarTelefone(criaTelefone());
                            Console.WriteLine(conts.pesquisar(c1).Equals(new Contato()) ? "Contato não encontrado!" : "Telefone adicionado!");
                            break;

                    case 3: Console.WriteLine(conts.pesquisar(criaContatoSearch()).ToString());
                        break;

                    case 4: Console.WriteLine(conts.alterar(criaContato()) ? "Contato Alterado" : "Contato não encontrado");
                        break;

                    case 5: Console.WriteLine(conts.remover(criaContatoSearch()) ? "Contato removido!" : "Contato não encontrado!");
                        break;

                    case 6: foreach(Contato con in conts.Agenda)
                        {
                            Console.WriteLine(con.ToString());
                        }
                        break;
                }
                Console.WriteLine("aperte enter para prosseguir...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
