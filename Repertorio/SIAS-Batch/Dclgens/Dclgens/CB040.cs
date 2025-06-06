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
    public class CB040 : VarBasis
    {
        /*"01  DCLCB-PESS-REC-ANT.*/
        public CB040_DCLCB_PESS_REC_ANT DCLCB_PESS_REC_ANT { get; set; } = new CB040_DCLCB_PESS_REC_ANT();

    }
}