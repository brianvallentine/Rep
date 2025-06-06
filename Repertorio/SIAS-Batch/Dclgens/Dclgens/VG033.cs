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
    public class VG033 : VarBasis
    {
        /*"01  DCLVG-ACESSORIO.*/
        public VG033_DCLVG_ACESSORIO DCLVG_ACESSORIO { get; set; } = new VG033_DCLVG_ACESSORIO();

    }
}