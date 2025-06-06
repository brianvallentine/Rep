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
    public class LBSI1001_SI1001S_PARAMETROS : VarBasis
    {
        /*"  05      SI1001S-ENTRADA*/
        public LBSI1001_SI1001S_ENTRADA SI1001S_ENTRADA { get; set; } = new LBSI1001_SI1001S_ENTRADA();

        public LBSI1001_SI1001S_SAIDA SI1001S_SAIDA { get; set; } = new LBSI1001_SI1001S_SAIDA();

    }
}