using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex07
{
    
    internal class Program
    {
        static Medicamento criaMed(bool sel = false)
        {
            int id;
            string nome, lab;

            Console.WriteLine("Digite o id do medicamento: ");
            id = Convert.ToInt32(Console.ReadLine());

            if (sel) { return new Medicamento(id, "", ""); }

            Console.WriteLine("Digite o nome do medicamento: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite o laboratorio do medicamento: ");
            lab = Console.ReadLine();

            return new Medicamento(id, nome, lab);
        }

        static Lote criaLote()
        {
            int id, qtde, dia, mes, ano;

            Console.WriteLine("Digite o id do lote: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a quantidade do lote: ");
            qtde = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o dia do vencimento do lote: ");
            dia = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o mes do vencimento do lote: ");
            mes = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o ano do vencimento do lote: ");
            ano = Convert.ToInt32(Console.ReadLine());

            return new Lote(id, qtde, new DateTime(ano, mes, dia));
        }
        static void Main(string[] args)
        {
            Medicamentos estoque = new Medicamentos();
            int sel = 1;
            while (sel != 0)
            {
                Console.WriteLine("0. Finalizar Processo\n1. Cadastrar Medicamento\n2. Consultar medicamento (sintético: informar dados)\n3. Consultar medicamento (analítico: informar dados + lotes)\n4. Comprar medicamento (cadastrar lote)\n5. Vender medicamento (abater do lote mais antigo)\n6. Listar medicamentos");
                sel = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (sel)
                {
                    case 1:
                        estoque.adicionar(criaMed());
                        break;

                    case 2:
                        Console.WriteLine(estoque.pesquisar(criaMed(true)).ToString());
                        break;

                    case 3:
                        Medicamento medx = estoque.pesquisar(criaMed(true));
                        Console.WriteLine(medx.ToString());
                        foreach (Lote lote in medx.Lotes)
                        {
                            Console.WriteLine(lote.ToString());
                        }
                        break;

                    case 4:
                        estoque.pesquisar(criaMed(true)).comprar(criaLote());
                        Console.WriteLine("Lote adicionado");
                        break;

                    case 5:
                        int qtde;
                        Console.WriteLine("Quantos serão vendidos?");
                        qtde = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(estoque.pesquisar(criaMed(true)).vender(qtde) ? "Venda realizada!" : "Indisponível!");
                        break;

                    case 6:
                        foreach(Medicamento med in estoque.ListaMed)
                        {
                            Console.WriteLine(med.ToString());
                        }
                        break;
                }

                Console.WriteLine("digite enter para prosseguir...");
                Console.ReadLine();
                Console.Clear();

            }
        }
    }
}
