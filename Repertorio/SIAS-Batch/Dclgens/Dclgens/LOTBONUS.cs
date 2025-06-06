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
    public class LOTBONUS : VarBasis
    {
        /*"01  DCLLOTBONUS01.*/
        public LOTBONUS_DCLLOTBONUS01 DCLLOTBONUS01 { get; set; } = new LOTBONUS_DCLLOTBONUS01();

    }
}