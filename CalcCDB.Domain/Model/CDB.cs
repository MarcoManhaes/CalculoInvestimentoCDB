using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcCDB.Domain.Model
{
    public class Cdb
    {
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }

        public decimal ValorDesconto { get; set; }
    }
}
