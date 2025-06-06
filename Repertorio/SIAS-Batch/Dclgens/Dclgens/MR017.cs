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
    public class MR017 : VarBasis
    {
        /*"01  DCLMR-PROP-ITEM-EMPR.*/
        public MR017_DCLMR_PROP_ITEM_EMPR DCLMR_PROP_ITEM_EMPR { get; set; } = new MR017_DCLMR_PROP_ITEM_EMPR();

    }
}