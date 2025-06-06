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
    public class PLANFSAL : VarBasis
    {
        /*"01  DCLPLANOS-FAIXASAL.*/
        public PLANFSAL_DCLPLANOS_FAIXASAL DCLPLANOS_FAIXASAL { get; set; } = new PLANFSAL_DCLPLANOS_FAIXASAL();

    }
}