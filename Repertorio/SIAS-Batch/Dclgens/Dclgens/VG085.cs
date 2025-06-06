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
    public class VG085 : VarBasis
    {
        /*"01  DCLVG-FAIXA-ETARIA.*/
        public VG085_DCLVG_FAIXA_ETARIA DCLVG_FAIXA_ETARIA { get; set; } = new VG085_DCLVG_FAIXA_ETARIA();

    }
}