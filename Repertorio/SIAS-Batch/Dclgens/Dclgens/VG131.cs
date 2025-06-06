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
    public class VG131 : VarBasis
    {
        /*"01  DCLVG-PESSOA-PEPS.*/
        public VG131_DCLVG_PESSOA_PEPS DCLVG_PESSOA_PEPS { get; set; } = new VG131_DCLVG_PESSOA_PEPS();

    }
}