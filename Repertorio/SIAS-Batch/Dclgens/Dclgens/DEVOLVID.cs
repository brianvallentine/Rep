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
    public class DEVOLVID : VarBasis
    {
        /*"01  DCLDEVOLUCAO-VIDAZUL.*/
        public DEVOLVID_DCLDEVOLUCAO_VIDAZUL DCLDEVOLUCAO_VIDAZUL { get; set; } = new DEVOLVID_DCLDEVOLUCAO_VIDAZUL();

    }
}