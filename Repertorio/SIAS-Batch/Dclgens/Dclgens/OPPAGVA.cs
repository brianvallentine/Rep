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
    public class OPPAGVA : VarBasis
    {
        /*"01  DCLOPCAO-PAG-VIDAZUL.*/
        public OPPAGVA_DCLOPCAO_PAG_VIDAZUL DCLOPCAO_PAG_VIDAZUL { get; set; } = new OPPAGVA_DCLOPCAO_PAG_VIDAZUL();

    }
}