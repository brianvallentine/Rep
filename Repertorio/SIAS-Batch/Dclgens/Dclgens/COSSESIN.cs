using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class COSSESIN : VarBasis
    {
        /*"01  DCLCOSSEGURO-SINISTRO.*/
        public COSSESIN_DCLCOSSEGURO_SINISTRO DCLCOSSEGURO_SINISTRO { get; set; } = new COSSESIN_DCLCOSSEGURO_SINISTRO();

    }
}