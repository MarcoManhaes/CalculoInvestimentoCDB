using CalcCDB.Infrastructure.Configuration;
using CalcCDB.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcCDB.Infrastructure.Repository
{
    public class CdbConfigurationRepository : ICdbConfigurationRepository
    {
        public async Task<CdbConfiguration> ObterConstantesAsync()
        {
            return await Task.FromResult(CdbConfiguration.Instance);
        }

        public decimal ObterImpostoPeriodo(int meses)
        {
            decimal imposto = 0m;

            foreach (var periodoTaxa in CdbConfiguration.Instance.TabelaImposto)
            {
                if (meses <= periodoTaxa.Key)
                {
                    imposto = periodoTaxa.Value;
                    break;
                }
            }

            return imposto;
        }

        public decimal ObterTaxaCDI()
        {
            return CdbConfiguration.Instance.TaxaCdi;
        }

        public decimal ObterTaxaTB()
        {
            return CdbConfiguration.Instance.TaxaTb;
        }
    }
}