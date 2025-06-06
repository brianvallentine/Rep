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
    public class LBWCT001 : VarBasis
    {
        /*"01        PROTOCOLO-RECEBIDO.*/
        public LBWCT001_PROTOCOLO_RECEBIDO PROTOCOLO_RECEBIDO { get; set; } = new LBWCT001_PROTOCOLO_RECEBIDO();

    }
}