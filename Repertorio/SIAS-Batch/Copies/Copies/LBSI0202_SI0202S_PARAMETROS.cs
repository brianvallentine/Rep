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
    public class LBSI0202_SI0202S_PARAMETROS : VarBasis
    {
        /*"   03 SI0202S-ENTRADA*/
        public LBSI0202_SI0202S_ENTRADA SI0202S_ENTRADA { get; set; } = new LBSI0202_SI0202S_ENTRADA();

        public LBSI0202_SI0202S_SAIDA SI0202S_SAIDA { get; set; } = new LBSI0202_SI0202S_SAIDA();

    }
}