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
    public class VG103 : VarBasis
    {
        /*"01  DCLVG-CRITICA-PROPOSTA.*/
        public VG103_DCLVG_CRITICA_PROPOSTA DCLVG_CRITICA_PROPOSTA { get; set; } = new VG103_DCLVG_CRITICA_PROPOSTA();

    }
}