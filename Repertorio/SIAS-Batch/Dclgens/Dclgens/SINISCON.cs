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
    public class SINISCON : VarBasis
    {
        /*"01  DCLSINISTRO-CONTROLE.*/
        public SINISCON_DCLSINISTRO_CONTROLE DCLSINISTRO_CONTROLE { get; set; } = new SINISCON_DCLSINISTRO_CONTROLE();

    }
}