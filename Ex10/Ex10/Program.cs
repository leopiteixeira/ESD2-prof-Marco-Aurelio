using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10
{
    internal class Program
    {
        static TipoEquip criaTipo()
        {
            int id;
            double val;
            string nome;
            Console.WriteLine("Digite o id do Tipo:");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do Tipo:");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o valor diário de locação do Tipo:");
            val = double.Parse(Console.ReadLine());

            return new TipoEquip(id, nome, val);
        }

        static TipoEquip consultaTipo(List<TipoEquip> tipos)
        {
            int id;
            Console.WriteLine("Digite o id do Tipo:");
            id = int.Parse(Console.ReadLine());
            TipoEquip cons = new TipoEquip(id);
            foreach (TipoEquip tipo in tipos)
            {
                if (cons.Equals(tipo))
                {
                    return tipo;
                }
            }
            return null;
        }

        static bool criaEquip(List<TipoEquip> tipos)
        {
            bool ret = false;
            int id;
            bool avar;
            Console.WriteLine("Digite o id do Tipo:");
            id = int.Parse(Console.ReadLine());
            TipoEquip cons = new TipoEquip(id);
            TipoEquip tipo = null;
            foreach (TipoEquip tip in tipos)
            {
                if (cons.Equals(tip))
                {
                    tipo = tip;
                    ret = true;
                    break;
                }
            }
            if (ret)
            {
                Console.WriteLine("Digite o id do Equipamento:");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("O equipamento está avariado?s/n");
                avar = Console.ReadLine().ToLower() == "s" ? true : false;

                return tipo.AdicionaEquip(new Equipamento(id, tipo, avar));
            }
            return ret;
        }

        static bool criaContrato(List<TipoEquip> tipos, List<Contrato> contratos)
        {
            int idTipo, qtde;
            Contrato contrato= new Contrato();
            while(true)
            {
                Console.WriteLine("Qual tipo de equipamento necessario:\nPara sair aperte 0.");
                idTipo = int.Parse(Console.ReadLine());
                if (idTipo == 0) { break; }
                TipoEquip cons = new TipoEquip(idTipo);
                TipoEquip tipo = null;
                foreach (TipoEquip tip in tipos)
                {
                    if (cons.Equals(tip))
                    {
                        tipo = tip;
                        break;
                    }
                }
                if (tipo == null) { return false; }
                Console.WriteLine("Quantos serão necessários:");
                qtde = int.Parse(Console.ReadLine());

                if (!contrato.adicionaEquips(qtde, tipo))
                {
                    Console.WriteLine("Sem equipamentos suficientes para este tipo!");
                }
            }

            contratos.Add(contrato);
            return true;
        }

        static Contrato pesquisaContrato(List<Contrato> contratos)
        {
            Console.WriteLine("Digite o Id do contrato a ser devolvido:");
            int idContrato = int.Parse(Console.ReadLine());
            Contrato contrato = null;
            foreach (Contrato contr in contratos)
            {
                if(contr.Id == idContrato)
                {
                    contrato = contr;
                    break;
                }
            }
            return contrato;
        }

        static void Main(string[] args)
        {
            int sel = 1;
            List<Contrato> contratos = new List<Contrato>();
            List<Contrato> liberados = new List<Contrato>();
            List<TipoEquip> tipos = new List<TipoEquip>();
            Contrato contrato;

            while (sel != 0)
            {
                Console.WriteLine("0. Finalizar");
                Console.WriteLine("1. Cadastrar tipo de equipamento");
                Console.WriteLine("2. Consultar tipo de equipamento (com os respectivos itens cadastrados)");
                Console.WriteLine("3. Cadastrar equipamento (item em um determinado tipo)");
                Console.WriteLine("4. Registrar Contrato de Locação");
                Console.WriteLine("5. Consultar Contratos de Locação (com os respectivos itens contratados)");
                Console.WriteLine("6. Liberar de Contrato de Locação");
                Console.WriteLine("7. Consultar Contratos de Locação liberados (com os respectivos itens)");
                Console.WriteLine("8. Devolver equipamentos de Contrato de Locação liberado");

                sel = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (sel)
                {
                    case 0:
                        Console.WriteLine("Finalizando...");
                        break;

                    case 1:
                        tipos.Add(criaTipo());
                        Console.WriteLine("Tipo adicionado!");
                        break;

                    case 2:
                        TipoEquip tipo = consultaTipo(tipos);
                        Console.WriteLine(tipo == null ? "Tipo não encontrado!" : tipo.consultaEquip());
                        break;

                    case 3:
                        Console.WriteLine(criaEquip(tipos) ? "Equipamento adicionado!" : "Erro ao adicionar!");
                        break;

                    case 4:
                        Console.WriteLine(criaContrato(tipos, contratos) ? "Contrato criado!" : "Erro ao criar contrato!");
                        break;

                    case 5:
                        foreach(Contrato contr in contratos)
                        {
                            Console.WriteLine(contr.consultaContrato());
                            Console.WriteLine("-----------------------------------------------------");
                        }
                        break;

                    case 6: contrato = pesquisaContrato(contratos);
                        if (contrato != null)
                        {
                            contrato.liberaContrato();
                            liberados.Add(contrato);
                            Console.WriteLine("Contrato Liberado!");
                            break;
                        }
                        Console.WriteLine("Contrato não encontrado!");
                        break;

                    case 7:
                        foreach (Contrato contr in liberados)
                        {
                            Console.WriteLine(contr.consultaContrato());
                            Console.WriteLine("-----------------------------------------------------");
                        }
                        break;

                    case 8: contrato = pesquisaContrato(liberados);
                        if (contrato != null)
                        {
                            contrato.devolveEquipamentos();
                            Console.WriteLine("Valor devido: " + contrato.valorContrato());
                            Console.WriteLine("Contrato Devolvido!");
                            break;
                        }
                        Console.WriteLine("Contrato não encontrado ou não liberado!");
                        break;


                }

                Console.WriteLine("Aperte enter para prosseguir...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
