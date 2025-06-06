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
    public class ABEND : VarBasis
    {
        /*"01  DCLABEND.*/
        public ABEND_DCLABEND DCLABEND { get; set; } = new ABEND_DCLABEND();

    }
}