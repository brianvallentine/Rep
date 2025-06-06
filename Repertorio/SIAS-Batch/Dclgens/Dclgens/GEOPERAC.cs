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
    public class GEOPERAC : VarBasis
    {
        /*"01  DCLGE-OPERACAO.*/
        public GEOPERAC_DCLGE_OPERACAO DCLGE_OPERACAO { get; set; } = new GEOPERAC_DCLGE_OPERACAO();

    }
}