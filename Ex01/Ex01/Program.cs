using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    internal class Program
    {
        static Vendedor criaVendedor(int sel=0)
        {
            string n;
            int id;
            double pc;
            Vendedor v;
            Console.Write("Digite o id do vendedor: ");
            id = Convert.ToInt32(Console.ReadLine());
            if (sel == 1)
            {
                v = new Vendedor(id);
                return v;
            }
            Console.Write("Digite o nome do vendedor: ");
            n = Console.ReadLine();
            Console.Write("Digite o percentual de comissao do vendedor: ");
            pc = Convert.ToDouble(Console.ReadLine());
            v = new Vendedor(id, n, pc);

            return v;
        }

        static Venda criaVenda()
        {
            Venda v;
            int qtde;
            double val;

            Console.Write("Digite a quantidade da venda: ");
            qtde = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o valor total da venda: ");
            val = Convert.ToDouble(Console.ReadLine());
            v = new Venda(qtde, val);
            return v;
        }

        static int perguntaDia()
        {
            int dia;
            do
            {
                Console.Write("Digite o dia da venda: ");
                dia = Convert.ToInt32(Console.ReadLine());
            } while (dia < 1 || dia > 31);
            return dia;
        }

        static void consulta(Vendedores v)
        {
            int i = 1;
            Vendedor vend = v.searchVendedor(criaVendedor(1));
            if (vend.Id != -1)
            {
                Console.WriteLine(vend.ToString() +
                          "valor vendas: " + vend.valorVendas().ToString() +
                          " | valor comissão: " + vend.valorComissao().ToString() + "\n");

                foreach(Venda venda in vend.AsVendas)
                {
                    Console.WriteLine(venda != null ? i.ToString() + ". " + venda.valorMedio().ToString() : i.ToString() + ". -");
                    i++;
                }
            }
            else
            {
                Console.WriteLine(vend.ToString());
            }
            
        }

        static void Main(string[] args)
        {
            int sel = 1;
            Vendedores listaVendedores = new Vendedores(10);
            Vendedor vendAux = new Vendedor();

            while (sel != 0) 
            { 
                Console.WriteLine("0.Sair \n" +
                                  "1. Cadastrar vendedor \n" +
                                  "2. Consultar vendedor \n" +
                                  "3. Excluir vendedor   \n" +
                                  "4. Registrar venda    \n" +
                                  "5. Listar vendedores    ");
                sel = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch(sel)
                {
                    case 1:
                        Console.WriteLine(listaVendedores.addVendedor(criaVendedor())? "Vendedor cadastrado!" : "Erro ao cadastrar!");
                        break;
                    case 2:
                        consulta(listaVendedores);
                        break;
                    case 3:
                        Console.WriteLine(listaVendedores.delVendedor(criaVendedor(1)) ? "Vendedor removido!" : "Erro ao remover!");
                        break;
                    case 4:
                        listaVendedores.searchVendedor(criaVendedor(1)).registrarVenda(perguntaDia(), criaVenda());
                        break;
                    case 5:
                        Console.WriteLine(listaVendedores.mostrar());
                        break;
                }
                Console.WriteLine("Aperte enter para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
