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
    public class MR021 : VarBasis
    {
        /*"01  DCLMR-APOL-ITEM-COND.*/
        public MR021_DCLMR_APOL_ITEM_COND DCLMR_APOL_ITEM_COND { get; set; } = new MR021_DCLMR_APOL_ITEM_COND();

    }
}