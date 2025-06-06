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
    public class SIHABIT2 : VarBasis
    {
        /*"01  DCLSINISTRO-HABIT2.*/
        public SIHABIT2_DCLSINISTRO_HABIT2 DCLSINISTRO_HABIT2 { get; set; } = new SIHABIT2_DCLSINISTRO_HABIT2();

    }
}