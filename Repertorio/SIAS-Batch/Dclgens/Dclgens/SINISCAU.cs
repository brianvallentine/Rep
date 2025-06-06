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
    public class SINISCAU : VarBasis
    {
        /*"01  DCLSINISTRO-CAUSA.*/
        public SINISCAU_DCLSINISTRO_CAUSA DCLSINISTRO_CAUSA { get; set; } = new SINISCAU_DCLSINISTRO_CAUSA();

    }
}