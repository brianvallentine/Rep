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
    public class VG133 : VarBasis
    {
        /*"01  DCLVG-ESTIPULANTE-VINCULO.*/
        public VG133_DCLVG_ESTIPULANTE_VINCULO DCLVG_ESTIPULANTE_VINCULO { get; set; } = new VG133_DCLVG_ESTIPULANTE_VINCULO();

    }
}