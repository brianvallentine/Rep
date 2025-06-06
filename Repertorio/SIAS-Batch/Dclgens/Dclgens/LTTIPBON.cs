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
    public class LTTIPBON : VarBasis
    {
        /*"01  DCLLT-TIPO-BONUS.*/
        public LTTIPBON_DCLLT_TIPO_BONUS DCLLT_TIPO_BONUS { get; set; } = new LTTIPBON_DCLLT_TIPO_BONUS();

    }
}