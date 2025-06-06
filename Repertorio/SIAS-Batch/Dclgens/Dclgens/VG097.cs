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
    public class VG097 : VarBasis
    {
        /*"01  DCLVG-ACOPLADO-PRESTAMISTA.*/
        public VG097_DCLVG_ACOPLADO_PRESTAMISTA DCLVG_ACOPLADO_PRESTAMISTA { get; set; } = new VG097_DCLVG_ACOPLADO_PRESTAMISTA();

    }
}