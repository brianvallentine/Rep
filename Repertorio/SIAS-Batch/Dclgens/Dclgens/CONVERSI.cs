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
    public class CONVERSI : VarBasis
    {
        /*"01  DCLCONVERSAO-SICOB.*/
        public CONVERSI_DCLCONVERSAO_SICOB DCLCONVERSAO_SICOB { get; set; } = new CONVERSI_DCLCONVERSAO_SICOB();

    }
}