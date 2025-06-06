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
    public class SIPROACO : VarBasis
    {
        /*"01  DCLSI-PROTOCOLO-ACOMP.*/
        public SIPROACO_DCLSI_PROTOCOLO_ACOMP DCLSI_PROTOCOLO_ACOMP { get; set; } = new SIPROACO_DCLSI_PROTOCOLO_ACOMP();

    }
}