using Negocio;
using SharedModels;
using System;

namespace Petshop
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                RetornoPetShop retornoPetShop = new RetornoPetShop();

                Console.WriteLine("Bem-vindo ao sistema de agendamento PetShop.");
                Console.WriteLine("Informe a data que deseja agendar. \"Exemplo 12/08/2021\"");

                PetShopNegocio petShopNegocio = new PetShopNegocio();
                DateTime dataAgendamento;

                try
                {
                    dataAgendamento = petShopNegocio.ValidarData(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Digite uma data válida.");
                    dataAgendamento = petShopNegocio.ValidarData(Console.ReadLine());
                }
                Console.WriteLine("Digite o número de cães grandes.");

                int qtdCaesGrande;
                int qtdCaesPequenos;

                try
                {
                    qtdCaesGrande = petShopNegocio.ValidarQtdCaes(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Digite uma quantidade válida");
                    qtdCaesGrande = petShopNegocio.ValidarQtdCaes(Console.ReadLine());

                }

                Console.WriteLine("Digite o número de cães pequenos.");
                try
                {
                    qtdCaesPequenos = petShopNegocio.ValidarQtdCaes(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Digite uma quantidade válida");
                    qtdCaesPequenos = petShopNegocio.ValidarQtdCaes(Console.ReadLine());

                }
                bool eFinalSemana = petShopNegocio.EFinalSemana(dataAgendamento);

                retornoPetShop = petShopNegocio.Calcular(qtdCaesGrande, qtdCaesPequenos, eFinalSemana);

                Console.Write($"O PetShop mais indicado é o {retornoPetShop.NomePetShop} e o valor total ficou em {retornoPetShop.ValorTotal}");

                Console.ReadLine();
                return;
            }
        }
    }
}
