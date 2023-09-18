using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcCDB.Domain.Interfaces
{
    public interface ICdbService
    {
        Task<decimal> CalcularValorCDBAsync(decimal valorInicial, int meses);
        Task<decimal> AplicarDescontoImpostoAsync(decimal valorBruto, int meses);
        Task<decimal> ObterDescontoImpostoAsync(decimal valorBruto, int meses);
    }
}