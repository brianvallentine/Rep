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
    public class VG094 : VarBasis
    {
        /*"01  DCLVG-CARENCIA-MSG.*/
        public VG094_DCLVG_CARENCIA_MSG DCLVG_CARENCIA_MSG { get; set; } = new VG094_DCLVG_CARENCIA_MSG();

    }
}