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
    public class VG101 : VarBasis
    {
        /*"01  DCLVG-RELAC-STATUS-ALCADA.*/
        public VG101_DCLVG_RELAC_STATUS_ALCADA DCLVG_RELAC_STATUS_ALCADA { get; set; } = new VG101_DCLVG_RELAC_STATUS_ALCADA();

    }
}