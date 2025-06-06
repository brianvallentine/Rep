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
    public class CB039 : VarBasis
    {
        /*"01  DCLCB-PESS-PENDENCIA.*/
        public CB039_DCLCB_PESS_PENDENCIA DCLCB_PESS_PENDENCIA { get; set; } = new CB039_DCLCB_PESS_PENDENCIA();

        public CB039_ICB_PESS_PENDENCIA ICB_PESS_PENDENCIA { get; set; } = new CB039_ICB_PESS_PENDENCIA();

    }
}