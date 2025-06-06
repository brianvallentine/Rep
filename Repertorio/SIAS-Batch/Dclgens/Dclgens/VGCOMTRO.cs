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
    public class VGCOMTRO : VarBasis
    {
        /*"01  DCLVG-COMPL-TERMO.*/
        public VGCOMTRO_DCLVG_COMPL_TERMO DCLVG_COMPL_TERMO { get; set; } = new VGCOMTRO_DCLVG_COMPL_TERMO();

    }
}