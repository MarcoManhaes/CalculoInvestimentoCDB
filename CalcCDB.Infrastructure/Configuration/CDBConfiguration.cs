using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcCDB.Infrastructure.Configuration
{
    public class CdbConfiguration
    {
        private static readonly Lazy<CdbConfiguration> _instance = new();
        public static CdbConfiguration Instance => _instance.Value;
        public decimal TaxaTb { get; } = 1.08m;
        public decimal TaxaCdi { get; } = 0.009m;

        public Dictionary<int, decimal> TabelaImposto { get; } = new()
        {
            [6] = 0.225m,
            [12] = 0.20m,
            [24] = 0.175m,
            [int.MaxValue] = 0.15m
        };
    }
    
}