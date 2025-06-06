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
    public class SINIITEM : VarBasis
    {
        /*"01  DCLSINISTRO-ITEM.*/
        public SINIITEM_DCLSINISTRO_ITEM DCLSINISTRO_ITEM { get; set; } = new SINIITEM_DCLSINISTRO_ITEM();

    }
}