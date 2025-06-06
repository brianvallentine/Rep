using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBSI505B_SI0505B_PARAMETROS : VarBasis
    {
        /*"   03  SI0505B-ENTRADA*/
        public LBSI505B_SI0505B_ENTRADA SI0505B_ENTRADA { get; set; } = new LBSI505B_SI0505B_ENTRADA();

        public LBSI505B_SI0505B_SAIDA SI0505B_SAIDA { get; set; } = new LBSI505B_SI0505B_SAIDA();

    }
}