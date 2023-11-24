using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Ex09
{
    internal class Program
    {
        static void iniciaJornada(Garagens garagens, List<Carro> carros)
        {
            int qntdGar = garagens.Dados.Count;
            int cont = 0;
            for (int i = 0; i < carros.Count; i++)
            {
                if (cont == qntdGar)
                {
                    cont = 0;
                }
                garagens.Dados[cont].colocaCarro(carros[i]);
                cont++;
            }
        }

        static void encerraJornada(Garagens garagens, List<Carro> carros, Viagens vias)
        {
            foreach(Garagem gar in garagens.Dados)
            {
                gar.Carros.Clear();
            }

            foreach (Carro car in carros)
            {
                Console.WriteLine("Carro: {0} | Passageiros transportados: {1}", car.Id, vias.passageirosTransportados(car));
            }
            Console.WriteLine("Jornada encerrada!");
        }

        static Viagem achaViagem(Viagens vias, Garagens garagens, List<Carro> carros)
        {
            Garagem origem;
            Garagem destino;
            Carro carro;
            int idOrigem, idDestino, idCarro;
            Console.WriteLine("Qual o id da origem:");
            idOrigem = int.Parse(Console.ReadLine());
            origem = garagens.Dados.FirstOrDefault(gar => gar.Id == idOrigem);
            Console.WriteLine("Qual o id do destino:");
            idDestino = int.Parse(Console.ReadLine());
            destino = garagens.Dados.FirstOrDefault(gar => gar.Id == idDestino);
            Console.WriteLine("Qual o id do carro:");
            idCarro = int.Parse(Console.ReadLine());
            carro = carros.FirstOrDefault(car => car.Id == idCarro);
            return vias.Dados.FirstOrDefault(via => via.Origem.Equals(origem) && via.Destino.Equals(destino) && via.Carro.Equals(carro) && !via.Concluida);
        }

        static Garagem achaGaragem(Garagens garagens)
        {
            int id;
            Console.WriteLine("Digite o id da garagem");
            id = int.Parse(Console.ReadLine());
            return garagens.Dados.FirstOrDefault(gar => gar.Id == id);
            
        }

        static Garagem achaOrigem(Garagens garagens)
        {
            int id;
            Console.WriteLine("Digite o id da origem");
            id = int.Parse(Console.ReadLine());
            return garagens.Dados.FirstOrDefault(gar => gar.Id == id);

        }

        static Garagem achaDestino(Garagens garagens)
        {
            int id;
            Console.WriteLine("Digite o id do destino");
            id = int.Parse(Console.ReadLine());
            return garagens.Dados.FirstOrDefault(gar => gar.Id == id);

        }

        static Viagem criaViagem(Garagens garagens)
        {
            Garagem origem;
            Garagem destino;
            int idOrigem, idDestino;
            Console.WriteLine("Qual o id da origem:");
            idOrigem = int.Parse(Console.ReadLine());
            origem = garagens.Dados.FirstOrDefault(gar => gar.Id == idOrigem);
            if (!origem.Carros.Any()) { return null; }
            Console.WriteLine("Qual o id do destino:");
            idDestino = int.Parse(Console.ReadLine());
            destino = garagens.Dados.FirstOrDefault(gar => gar.Id == idDestino);
            return new Viagem(origem, destino);
        }

        static Carro criaVeiculo()
        {
            int lotMax;
            Console.WriteLine("Qual a lotacão máxima do veículo:");
            lotMax = int.Parse(Console.ReadLine());
            return new Carro(lotMax);
        }

        static Garagem criaGaragem()
        {
            string nome;
            Console.WriteLine("Qual o nome da garagem:");
            nome = Console.ReadLine();
            return new Garagem(nome);
        }

        static void Main(string[] args)
        {
            Viagens vias = new Viagens();
            Garagens garagens = new Garagens();
            garagens.adiciona(new Garagem("Congonhas"));
            garagens.adiciona(new Garagem("Guarulhos"));
            List<Carro> carros = new List<Carro>();
            bool jorIni = false;
            for (int i = 0; i < 8; i++)
            {
                carros.Add(new Carro(20));
            }
            int sel = 1;

            while (sel != 0)
            {
                Console.WriteLine("0. Finalizar");
                Console.WriteLine("1. Cadastrar veículo");
                Console.WriteLine("2. Cadastrar garagem");
                Console.WriteLine("3. Iniciar jornada");
                Console.WriteLine("4. Encerrar jornada");
                Console.WriteLine("5. Liberar viagem de uma determinada origem para um determinado destino");
                Console.WriteLine("6. Concluir viagem de uma determinada origem para um determindao destino");
                Console.WriteLine("7. Listar veículos em determinada garagem (informando a quantidade de veículos e seu potencial de transporte)");
                Console.WriteLine("8. Informar quantidade de viagens efetuadas de uma determinada origem para um determinado destino");
                Console.WriteLine("9. Listar viagens efetuadas de uma determinada origem para um determinado destino");
                Console.WriteLine("10. Informar quantidade de passageiros transportados de uma determinada origem para um determinado destino");

                sel = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (sel)
                {
                    case 0: Console.WriteLine("Finalizando...");
                        break;

                    case 1:
                        if (!jorIni)
                        {
                            carros.Add(criaVeiculo());
                            Console.WriteLine("Veículo cadastrado!");
                        }
                        else
                        {
                            Console.WriteLine("Encerre a jornada para cadastrar veículos!");
                        }
                        break;

                    case 2:if (!jorIni)
                        {
                            garagens.adiciona(criaGaragem());
                            Console.WriteLine("Garagem cadastrada!");
                        }
                        else
                        {
                            Console.WriteLine("Encerre a jornada para cadastrar garagens!");
                        }
                        break;

                    case 3: if (!jorIni) { 
                            iniciaJornada(garagens, carros);
                            jorIni = true;
                            Console.WriteLine("Jornada iniciada!");
                        }
                        else { Console.WriteLine("A jornada já havia sido iniciada!"); }
                        break;

                    case 4: if (!vias.concluiuTodas())
                        {
                            Console.WriteLine("Para encerrar a jornada é necessario concluir todas as viagens!");
                        }else if(jorIni)
                        {
                            encerraJornada(garagens, carros, vias);
                        }
                        else { Console.WriteLine("A jornada já foi encerrada!"); }
                        break;

                    case 5: if (jorIni)
                        {
                            Viagem via = criaViagem(garagens);
                            if (via == null)
                            {
                                Console.WriteLine("Origem sem nenhum carro");
                            }
                            else
                            {
                                vias.adiciona(via);
                                Console.WriteLine("Viagem Liberada!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("primeiro inicie a jornada para poder liberar viagens!");
                        }
                        break;


                    case 6: Viagem viaFind = achaViagem(vias, garagens, carros);
                        if (viaFind != null)
                        {
                            viaFind.concluirViagem();
                            Console.WriteLine("Viagem concluida!");
                        }
                        else { Console.WriteLine("Viagem não Encontrada ou ja concluida!"); }
                        break;

                    case 7: Garagem garFind = achaGaragem(garagens);
                        if (garFind != null)
                        {
                            Console.WriteLine(garFind.mostraCarros());
                        }
                        else { Console.WriteLine("Garagem não Encontrada!"); }
                        break;

                    case 8:Garagem origem = achaOrigem(garagens);
                        Garagem destino = achaDestino(garagens);
                        if(origem != null &&  destino != null)
                            Console.WriteLine("Quantidade de viagens: " + vias.quantidadeViagens(origem, destino));
                        else { Console.WriteLine("alguma das garagens não existem");  }
                        break;

                    case 9:origem = achaOrigem(garagens);
                        destino = achaDestino(garagens);
                        if(origem != null &&  destino != null)
                            Console.WriteLine(vias.listarViagens(origem, destino));
                        else { Console.WriteLine("alguma das garagens não existem");  }
                        break;

                    case 10:origem = achaOrigem(garagens);
                        destino = achaDestino(garagens);
                        if(origem != null &&  destino != null)
                            Console.WriteLine(vias.passageirosTransportados(origem, destino));
                        else { Console.WriteLine("alguma das garagens não existem");  }
                        break;
                }

                Console.WriteLine("Aperte enter para prosseguir...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
