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
    public class VG077 : VarBasis
    {
        /*"01  DCLVG-INDICES.*/
        public VG077_DCLVG_INDICES DCLVG_INDICES { get; set; } = new VG077_DCLVG_INDICES();

    }
}