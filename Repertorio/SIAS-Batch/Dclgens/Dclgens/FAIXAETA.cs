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
    public class FAIXAETA : VarBasis
    {
        /*"01  DCLFAIXA-ETARIA.*/
        public FAIXAETA_DCLFAIXA_ETARIA DCLFAIXA_ETARIA { get; set; } = new FAIXAETA_DCLFAIXA_ETARIA();

    }
}