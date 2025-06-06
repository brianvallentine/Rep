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
    public class GE366 : VarBasis
    {
        /*"01  DCLGE-MOVIMENTO.*/
        public GE366_DCLGE_MOVIMENTO DCLGE_MOVIMENTO { get; set; } = new GE366_DCLGE_MOVIMENTO();

        public GE366_IGE_MOVIMENTO IGE_MOVIMENTO { get; set; } = new GE366_IGE_MOVIMENTO();

    }
}