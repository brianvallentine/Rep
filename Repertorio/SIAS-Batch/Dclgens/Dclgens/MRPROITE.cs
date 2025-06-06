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
    public class MRPROITE : VarBasis
    {
        /*"01  DCLMR-PROPOSTA-ITEM.*/
        public MRPROITE_DCLMR_PROPOSTA_ITEM DCLMR_PROPOSTA_ITEM { get; set; } = new MRPROITE_DCLMR_PROPOSTA_ITEM();

    }
}