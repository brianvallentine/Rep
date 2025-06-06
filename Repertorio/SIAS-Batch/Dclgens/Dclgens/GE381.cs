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
    public class GE381 : VarBasis
    {
        /*"01  DCLGE-CLI-DADOS-FINANC.*/
        public GE381_DCLGE_CLI_DADOS_FINANC DCLGE_CLI_DADOS_FINANC { get; set; } = new GE381_DCLGE_CLI_DADOS_FINANC();

    }
}