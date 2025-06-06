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
    public class VG036 : VarBasis
    {
        /*"01  DCLVG-PLANO-ACESSORIO.*/
        public VG036_DCLVG_PLANO_ACESSORIO DCLVG_PLANO_ACESSORIO { get; set; } = new VG036_DCLVG_PLANO_ACESSORIO();

    }
}