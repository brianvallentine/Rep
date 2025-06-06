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
    public class PLANOFAI : VarBasis
    {
        /*"01  DCLPLANOS-FAIXAETA.*/
        public PLANOFAI_DCLPLANOS_FAIXAETA DCLPLANOS_FAIXAETA { get; set; } = new PLANOFAI_DCLPLANOS_FAIXAETA();

    }
}