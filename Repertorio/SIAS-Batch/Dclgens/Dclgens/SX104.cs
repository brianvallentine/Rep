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
    public class SX104 : VarBasis
    {
        /*"01  DCLSX-IOF-RAMO-COB.*/
        public SX104_DCLSX_IOF_RAMO_COB DCLSX_IOF_RAMO_COB { get; set; } = new SX104_DCLSX_IOF_RAMO_COB();

    }
}