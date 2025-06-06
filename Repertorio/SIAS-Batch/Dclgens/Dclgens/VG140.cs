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
    public class VG140 : VarBasis
    {
        /*"01  DCLVG-ACOPLADO-TITULO-HIST.*/
        public VG140_DCLVG_ACOPLADO_TITULO_HIST DCLVG_ACOPLADO_TITULO_HIST { get; set; } = new VG140_DCLVG_ACOPLADO_TITULO_HIST();

    }
}