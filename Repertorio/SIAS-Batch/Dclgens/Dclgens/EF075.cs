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
    public class EF075 : VarBasis
    {
        /*"01  DCLEF-OBJ-CONTR-SEGUR.*/
        public EF075_DCLEF_OBJ_CONTR_SEGUR DCLEF_OBJ_CONTR_SEGUR { get; set; } = new EF075_DCLEF_OBJ_CONTR_SEGUR();

    }
}