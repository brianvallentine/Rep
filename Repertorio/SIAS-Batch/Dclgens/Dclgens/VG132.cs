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
    public class VG132 : VarBasis
    {
        /*"01  DCLVG-PESSOA-PEPS-CRUZADO.*/
        public VG132_DCLVG_PESSOA_PEPS_CRUZADO DCLVG_PESSOA_PEPS_CRUZADO { get; set; } = new VG132_DCLVG_PESSOA_PEPS_CRUZADO();

    }
}