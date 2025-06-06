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
    public class GE612 : VarBasis
    {
        /*"01  DCLGE-TP-SERVICO-INSS.*/
        public GE612_DCLGE_TP_SERVICO_INSS DCLGE_TP_SERVICO_INSS { get; set; } = new GE612_DCLGE_TP_SERVICO_INSS();

    }
}