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
    public class LOTTAX01 : VarBasis
    {
        /*"01  DCLLOTTAXA01.*/
        public LOTTAX01_DCLLOTTAXA01 DCLLOTTAXA01 { get; set; } = new LOTTAX01_DCLLOTTAXA01();

    }
}