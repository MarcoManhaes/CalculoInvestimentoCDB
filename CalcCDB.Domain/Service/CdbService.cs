using CalcCDB.Domain.Interfaces;
using CalcCDB.Domain.Model;
using CalcCDB.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcCDB.Domain.Services
{
    public class CdbService : ICdbService
    {
        private readonly ICdbConfigurationRepository _cdbConfigurationRepository;

        public CdbService(ICdbConfigurationRepository cdbConfigurationRepository)
        {
            _cdbConfigurationRepository = cdbConfigurationRepository;
        }

        /// <summary>
        /// Calcula o valor do CDB por mês de rendimento
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="meses"></param>
        /// <returns>valorFinal</returns>
        public async Task<decimal> CalcularValorCDBAsync(decimal valorInicial, int meses)
        {
            return await Task.Run(() =>
            {
                decimal taxaTB = _cdbConfigurationRepository.ObterTaxaTB();
                decimal taxaCDI = _cdbConfigurationRepository.ObterTaxaCDI();
                decimal valorFinal = valorInicial;

                for (int i = 0; i < meses; i++, valorInicial = valorFinal)
                {
                    valorFinal = valorInicial * (1 + (taxaCDI * taxaTB));
                }

                return Math.Round(valorFinal, 2);
            });
        }

        /// <summary>
        /// Aplica desconto ao valor bruto ==> vl = vb - (vb * pi)
        /// </summary>
        /// <param name="valorBruto"></param>
        /// <param name="meses"></param>
        /// <returns>valorLiquido</returns>
        public async Task<decimal> AplicarDescontoImpostoAsync(decimal valorBruto, int meses)
        {
            decimal percentualImposto = _cdbConfigurationRepository.ObterImpostoPeriodo(meses);
            decimal valorLiquido = valorBruto - (valorBruto * percentualImposto);

            return await Task.FromResult(Math.Round(valorLiquido, 2));
        }

        /// <summary>
        /// Obtem desconto Inposto
        /// </summary>
        /// <param name="valorBruto"></param>
        /// <param name="meses"></param>
        /// <returns>valorImposto</returns>
        public async Task<decimal> ObterDescontoImpostoAsync(decimal valorBruto, int meses)
        {
            decimal percentualImposto = _cdbConfigurationRepository.ObterImpostoPeriodo(meses);
            decimal valorDesconto = valorBruto * percentualImposto;

            return await Task.FromResult(Math.Round(valorDesconto, 2));
        }
    }
}
