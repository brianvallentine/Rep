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
    public class VG137 : VarBasis
    {
        /*"01  DCLVG-ACOPLADO-HIST.*/
        public VG137_DCLVG_ACOPLADO_HIST DCLVG_ACOPLADO_HIST { get; set; } = new VG137_DCLVG_ACOPLADO_HIST();

    }
}