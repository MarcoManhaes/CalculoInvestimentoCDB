using CalcCDB.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcCDB.Infrastructure.Interfaces
{
    public interface ICdbConfigurationRepository
    {
        Task<CdbConfiguration> ObterConstantesAsync();
        decimal ObterTaxaTB();
        decimal ObterTaxaCDI();
        decimal ObterImpostoPeriodo(int meses);
    }
}
