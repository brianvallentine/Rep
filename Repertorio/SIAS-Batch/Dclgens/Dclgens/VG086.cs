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
    public class VG086 : VarBasis
    {
        /*"01  DCLVG-FAIXA-CAP-SEGUR.*/
        public VG086_DCLVG_FAIXA_CAP_SEGUR DCLVG_FAIXA_CAP_SEGUR { get; set; } = new VG086_DCLVG_FAIXA_CAP_SEGUR();

    }
}