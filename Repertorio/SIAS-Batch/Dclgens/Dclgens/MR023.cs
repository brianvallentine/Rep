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
    public class MR023 : VarBasis
    {
        /*"01  DCLMR-PROP-ITEM-COND.*/
        public MR023_DCLMR_PROP_ITEM_COND DCLMR_PROP_ITEM_COND { get; set; } = new MR023_DCLMR_PROP_ITEM_COND();

    }
}