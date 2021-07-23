using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class PetShopNegocio
    {
        public DateTime ValidarData(string input)
        {
            DateTime dataAgenda;

            if (DateTime.TryParse(input, out dataAgenda))
            {
                if (dataAgenda > DateTime.UtcNow)
                {
                    return dataAgenda;
                }
                else
                {
                    throw new Exception("Informe uma data válida");
                }

            }
            else
            {
                throw new Exception("Data Incorreta");
            }
        }

        public bool EFinalSemana(DateTime data)
        {

            DayOfWeek dayOfWeek = data.DayOfWeek;

            if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            return false;

        }

        public int ValidarQtdCaes(string input)
        {
            int qtdCaes;

            if (int.TryParse(input, out qtdCaes))
            {

                return qtdCaes;

            }
            else
            {
                throw new Exception("Digita a quantidade de cães correta");
            }
        }

        public RetornoPetShop Calcular(int qtdCaesGrande, int qtdCaesPequenos, bool eFinalSemana)
        {
            RetornoPetShop retorno = new RetornoPetShop();

            decimal valorCaninoFeliz = CalcularCaninoFeliz(qtdCaesGrande, qtdCaesPequenos, eFinalSemana);

            decimal valorVaiRex = CalcularVaiRex(qtdCaesGrande, qtdCaesPequenos, eFinalSemana);

            decimal valorChowChawgas = CalcularChowChawgas(qtdCaesGrande, qtdCaesPequenos, eFinalSemana);

            if (valorVaiRex == valorChowChawgas && valorVaiRex == valorCaninoFeliz)
            {

                retorno.ValorTotal = valorChowChawgas;
                retorno.NomePetShop = ChowChagas.Nome;
            }
            else if (valorCaninoFeliz == valorChowChawgas)
            {
                if (MeuCaninoFeliz.Distancia > ChowChagas.Distancia)
                {
                    retorno.NomePetShop = ChowChagas.Nome;
                    retorno.ValorTotal = valorChowChawgas;

                }
                else
                {
                    retorno.NomePetShop = MeuCaninoFeliz.Nome;
                    retorno.ValorTotal = valorCaninoFeliz;
                }
            }
            else if (valorCaninoFeliz == valorVaiRex)
            {
                if (MeuCaninoFeliz.Distancia > Vairex.Distancia)
                {
                    retorno.NomePetShop = Vairex.Nome;
                    retorno.ValorTotal = valorVaiRex;

                }
                else
                {
                    retorno.NomePetShop = MeuCaninoFeliz.Nome;
                    retorno.ValorTotal = valorCaninoFeliz;
                }
            }

            else if (valorVaiRex == valorChowChawgas)
            {

                if (Vairex.Distancia > ChowChagas.Distancia)
                {
                    retorno.NomePetShop = ChowChagas.Nome;
                    retorno.ValorTotal = valorChowChawgas;
                }
                else
                {
                    retorno.NomePetShop = Vairex.Nome;
                    retorno.ValorTotal = valorVaiRex;
                }
            }
            else
            {
                List<RetornoPetShop> valores = new List<RetornoPetShop>();

                valores.Add(new RetornoPetShop
                {
                    NomePetShop = Vairex.Nome,
                    ValorTotal = valorVaiRex
                }
                );

                valores.Add(new RetornoPetShop
                {
                    NomePetShop = ChowChagas.Nome,
                    ValorTotal = valorChowChawgas
                });


                valores.Add(new RetornoPetShop
                {
                    NomePetShop = MeuCaninoFeliz.Nome,
                    ValorTotal = valorCaninoFeliz
                });

                retorno.ValorTotal = valores.Min(i => i.ValorTotal);
                retorno.NomePetShop = valores.Where(a => a.ValorTotal == retorno.ValorTotal).Select(o => o.NomePetShop).FirstOrDefault();

            }
            return retorno;
        }

        private decimal CalcularCaninoFeliz(int qtdCaesGrande, int qtdCaesPequenos, bool eFinalSemana)
        {
            if (eFinalSemana)
            {
                return (qtdCaesPequenos * MeuCaninoFeliz.ValorCaoPequenoFinalSemana) + (qtdCaesGrande * MeuCaninoFeliz.ValorCaoGrandeFinalSemana);
            }
            else
            {
                return (qtdCaesPequenos * MeuCaninoFeliz.ValorCaoPequeno) + (qtdCaesGrande * MeuCaninoFeliz.ValorCaoGrande);
            }
        }

        private decimal CalcularVaiRex(int qtdCaesGrande, int qtdCaesPequenos, bool eFinalSemana)
        {
            if (eFinalSemana)
            {
                return (qtdCaesPequenos * Vairex.ValorCaoPequenoFinalSemana) + (qtdCaesGrande * Vairex.ValorCaoGrandeFinalSemana);
            }
            else
            {
                return (qtdCaesPequenos * Vairex.ValorCaoPequeno) + (qtdCaesGrande * Vairex.ValorCaoGrande);
            }
        }
        private decimal CalcularChowChawgas(int qtdCaesGrande, int qtdCaesPequenos, bool eFinalSemana)
        {

            return (qtdCaesPequenos * ChowChagas.ValorCaoPequeno) + (qtdCaesGrande * ChowChagas.ValorCaoGrande);

        }
    }

    public static class MeuCaninoFeliz
    {
        public const string Nome = "Meu Canino Feliz";

        public const decimal ValorCaoPequeno = 20;
        public const decimal ValorCaoGrande = 40;
        public const decimal ValorCaoPequenoFinalSemana = 24;
        public const decimal ValorCaoGrandeFinalSemana = 48;
        public const decimal Distancia = 1700;

    }

    public static class Vairex
    {
        public const string Nome = "Vai Rex";

        public const decimal ValorCaoPequeno = 15;
        public const decimal ValorCaoGrande = 50;
        public const decimal ValorCaoPequenoFinalSemana = 20;
        public const decimal ValorCaoGrandeFinalSemana = 55;
        public const decimal Distancia = 2000;

    }


    public static class ChowChagas
    {
        public const string Nome = "ChowChagas";

        public const decimal ValorCaoPequeno = 30;
        public const decimal ValorCaoGrande = 45;
        public const decimal Distancia = 800;


    }
}

