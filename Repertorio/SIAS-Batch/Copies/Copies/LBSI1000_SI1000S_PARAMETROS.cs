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
    public class LBSI1000_SI1000S_PARAMETROS : VarBasis
    {
        /*"  05      SI1000S-ENTRADA*/
        public LBSI1000_SI1000S_ENTRADA SI1000S_ENTRADA { get; set; } = new LBSI1000_SI1000S_ENTRADA();

        public LBSI1000_SI1000S_SAIDA SI1000S_SAIDA { get; set; } = new LBSI1000_SI1000S_SAIDA();

    }
}