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
    public class SI239 : VarBasis
    {
        /*"01  DCLSI-OPERACAO-EVENTO.*/
        public SI239_DCLSI_OPERACAO_EVENTO DCLSI_OPERACAO_EVENTO { get; set; } = new SI239_DCLSI_OPERACAO_EVENTO();

    }
}