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
    public class USUFILSE : VarBasis
    {
        /*"01  DCLUSU-FIL-SENHA.*/
        public USUFILSE_DCLUSU_FIL_SENHA DCLUSU_FIL_SENHA { get; set; } = new USUFILSE_DCLUSU_FIL_SENHA();

    }
}