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
    public class VG135 : VarBasis
    {
        /*"01  DCLVG-ACOPLADO.*/
        public VG135_DCLVG_ACOPLADO DCLVG_ACOPLADO { get; set; } = new VG135_DCLVG_ACOPLADO();

    }
}