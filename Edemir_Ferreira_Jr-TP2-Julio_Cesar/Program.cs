using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GerenciadorEntidades
{
    class Program
    {
        private const string pressioneQualquerTecla = "Pressione qualquer tecla para exibir o menu principal ...";
        private static Dictionary<string, DateTime> listaEntidades = new Dictionary<string, DateTime>();

        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("*** Gerenciador de Mercadorias *** ");
                Console.WriteLine("1 - Pesquisar Produto:");
                Console.WriteLine("2 - Adicionar Produto:");
                Console.WriteLine("3 - Sair:");
                Console.WriteLine("\nEscolha uma das opções acima: ");

                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    Console.WriteLine("Informe nome do produto ou parte do nome do produto que deseja pesquisar:");
                    var termoDePesquisa = Console.ReadLine();
                    var entidadesEncontradas = listaEntidades.Where(x => x.Key.ToLower().Contains(termoDePesquisa.ToLower()))
                                                             .ToList();

                    if (entidadesEncontradas.Count > 0)
                    {
                        Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados do Produto encontrado:");
                        for (var index = 0; index < entidadesEncontradas.Count; index++)
                            Console.WriteLine($"{index} - {entidadesEncontradas[index].Key}");

                        if (!ushort.TryParse(Console.ReadLine(), out var indexAExibir) || indexAExibir >= entidadesEncontradas.Count)
                        {
                            Console.WriteLine($"Opção inválida! {pressioneQualquerTecla}");
                            Console.ReadKey();
                            continue;
                        }

                        if (indexAExibir < entidadesEncontradas.Count)
                        {
                            var entidade = entidadesEncontradas[indexAExibir];

                            Console.WriteLine("Dados do produto");
                            Console.WriteLine($"Nome: {entidade.Key}");
                            Console.WriteLine($"Data de fabricação: {entidade.Value:dd/MM/yyyy}");

                            //realizar algum calculo com o campo DateTime da entidade e exibir o resultado do cálculo
                            //exemplos:
                            //data aniversario: quantidade de dias que faltam para o proximo aniversário do médico (em relação a data atual)
                            //data compra carro: há quantos anos o carro foi comprado (em relação a data atual)
                            //data de nomeação do prefeito: Quantidade de dias de gestão do prefeito até a data atual

                            // ADICIONAR A VALIDADE DE 2 ANOS PARA OS PRODUTOS QUÍMICOS.
                            var validade = Convert.ToDateTime(entidade.Value);
                            validade = validade.AddYears(2);

                            // MOSTRA A QUANTOS DIAS VENCEU O PRODUTO QUÍMICO OU QUANTOS DIAS FALTA PARA VENCER.
                            var dataAtual = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            int comparaData = DateTime.Compare(dataAtual, validade);
                            var diferencaTempo = validade.Subtract(DateTime.Now);

                            Console.WriteLine("------------------------------------------------------");
                            Console.WriteLine($" Garantia do {entidade.Key} é: {validade.ToShortDateString()}");
                            Console.WriteLine("");

                            if (comparaData < 0)
                            {
                                Console.WriteLine($"O Produto está dentro do prazo de garantia!");
                                Console.WriteLine($"Faltam {diferencaTempo.Days} para expirar a garantia do produto!");
                            }
                            else if (comparaData == 0)
                            {
                                Console.WriteLine($"A garantia do produto expira hoje!");
                            }
                            else
                            {
                                Console.WriteLine($"Garantia do produto expirada!");
                                Console.WriteLine($"A Garantia do Produto expirou a {System.Math.Abs(diferencaTempo.Days)} dias!");
                            }
                            Console.WriteLine("------------------------------------------------------");

                            Console.Write(pressioneQualquerTecla);
                            Console.ReadKey();


                            Console.Write(pressioneQualquerTecla);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Não foi encontrado nenhum produto! {pressioneQualquerTecla}");
                        Console.ReadKey();
                    }
                }
                else if (opcao == "2")
                {
                    Console.WriteLine("Informe nome do produto que deseja adicionar:"); //ex: uma informação do tipo string: nome medico, nome carro, nome prefeito
                    var campoDoTipoStringDaEntidade = Console.ReadLine();

                    Console.WriteLine("Informe data de fabricação (formato dd/MM/yyyy):"); //uma informação do tipo DateTime: data de aniversário do médico, data de compra do carro, data de nomeação do prefeito
                    if (!DateTime.TryParse(Console.ReadLine(), out var campoDoTipoDateTimeDaEntidade))
                    {
                        Console.WriteLine($"Data inválida! Dados descartados! {pressioneQualquerTecla}");
                        Console.ReadKey();
                        continue;
                    }

                    Console.WriteLine("Os dados estão corretos?");
                    Console.WriteLine($"[Campo string da entidade]: {campoDoTipoStringDaEntidade}");
                    Console.WriteLine($"[Campo DateTime da entidade]: {campoDoTipoDateTimeDaEntidade:dd/MM/yyyy}");
                    Console.WriteLine("1 - Sim \n2 - Não");

                    var opcaoParaAdicionar = Console.ReadLine();

                    if (opcaoParaAdicionar == "1")
                    {
                        listaEntidades.Add(campoDoTipoStringDaEntidade, campoDoTipoDateTimeDaEntidade);
                        Console.WriteLine($"Dados adicionados com sucesso! {pressioneQualquerTecla}");
                        Console.ReadKey();
                    }
                    else if (opcaoParaAdicionar == "2")
                    {
                        Console.WriteLine($"Dados descartados! {pressioneQualquerTecla}");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Opção inválida! {pressioneQualquerTecla}");
                        Console.ReadKey();
                    }
                }
                else if (opcao == "3")
                {
                    Console.Write("Saindo do programa... ");
                }
                else if (opcao != "3")
                {
                    Console.Write($"Opcao inválida! Escolha uma opção válida. {pressioneQualquerTecla}");
                    Console.ReadKey();
                }

            } while (opcao != "3");
        }
    }
}
