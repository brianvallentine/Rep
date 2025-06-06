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
    public class LOTISG01 : VarBasis
    {
        /*"01  DCLLOTIMPSEG01.*/
        public LOTISG01_DCLLOTIMPSEG01 DCLLOTIMPSEG01 { get; set; } = new LOTISG01_DCLLOTIMPSEG01();

    }
}