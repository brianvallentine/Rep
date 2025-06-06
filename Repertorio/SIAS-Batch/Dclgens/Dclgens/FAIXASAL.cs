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
    public class FAIXASAL : VarBasis
    {
        /*"01  DCLFAIXA-SALARIAL.*/
        public FAIXASAL_DCLFAIXA_SALARIAL DCLFAIXA_SALARIAL { get; set; } = new FAIXASAL_DCLFAIXA_SALARIAL();

    }
}