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
    public class SINIHAB1 : VarBasis
    {
        /*"01  DCLSINISTRO-HABIT01.*/
        public SINIHAB1_DCLSINISTRO_HABIT01 DCLSINISTRO_HABIT01 { get; set; } = new SINIHAB1_DCLSINISTRO_HABIT01();

    }
}