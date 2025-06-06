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
    public class VGCOBSUH : VarBasis
    {
        /*"01  DCLVG-COBER-SUBG-HIST.*/
        public VGCOBSUH_DCLVG_COBER_SUBG_HIST DCLVG_COBER_SUBG_HIST { get; set; } = new VGCOBSUH_DCLVG_COBER_SUBG_HIST();

    }
}