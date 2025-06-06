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
    public class PARAGEEM : VarBasis
    {
        /*"01  DCLPARM-AGENCI-EMP.*/
        public PARAGEEM_DCLPARM_AGENCI_EMP DCLPARM_AGENCI_EMP { get; set; } = new PARAGEEM_DCLPARM_AGENCI_EMP();

    }
}