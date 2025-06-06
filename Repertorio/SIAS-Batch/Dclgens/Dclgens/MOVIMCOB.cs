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
    public class MOVIMCOB : VarBasis
    {
        /*"01  DCLMOVIMENTO-COBRANCA.*/
        public MOVIMCOB_DCLMOVIMENTO_COBRANCA DCLMOVIMENTO_COBRANCA { get; set; } = new MOVIMCOB_DCLMOVIMENTO_COBRANCA();

    }
}