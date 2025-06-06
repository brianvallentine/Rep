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
    public class VG130 : VarBasis
    {
        /*"01  DCLVG-PLANO-SUBGRUPO.*/
        public VG130_DCLVG_PLANO_SUBGRUPO DCLVG_PLANO_SUBGRUPO { get; set; } = new VG130_DCLVG_PLANO_SUBGRUPO();

    }
}