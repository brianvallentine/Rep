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
    public class RSGEWDTA : VarBasis
    {
        /*"  01        RSS-WORK-DATAS*/
        public RSGEWDTA_RSS_WORK_DATAS RSS_WORK_DATAS { get; set; } = new RSGEWDTA_RSS_WORK_DATAS();

    }
}