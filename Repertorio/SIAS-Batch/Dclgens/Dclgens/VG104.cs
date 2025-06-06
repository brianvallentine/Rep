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
    public class VG104 : VarBasis
    {
        /*"01  DCLVG-CRITICA-PROPOSTA-HIST.*/
        public VG104_DCLVG_CRITICA_PROPOSTA_HIST DCLVG_CRITICA_PROPOSTA_HIST { get; set; } = new VG104_DCLVG_CRITICA_PROPOSTA_HIST();

    }
}