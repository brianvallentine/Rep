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
    public class VGACOTER : VarBasis
    {
        /*"01  DCLVG-ACOMP-TERMO.*/
        public VGACOTER_DCLVG_ACOMP_TERMO DCLVG_ACOMP_TERMO { get; set; } = new VGACOTER_DCLVG_ACOMP_TERMO();

    }
}