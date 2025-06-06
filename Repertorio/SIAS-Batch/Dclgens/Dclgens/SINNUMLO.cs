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
    public class SINNUMLO : VarBasis
    {
        /*"01  DCLSINISTRO-NUM-LOTE.*/
        public SINNUMLO_DCLSINISTRO_NUM_LOTE DCLSINISTRO_NUM_LOTE { get; set; } = new SINNUMLO_DCLSINISTRO_NUM_LOTE();

    }
}