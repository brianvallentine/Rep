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
    public class CONVEVG : VarBasis
    {
        /*"01  DCLCONVENIOS-VG.*/
        public CONVEVG_DCLCONVENIOS_VG DCLCONVENIOS_VG { get; set; } = new CONVEVG_DCLCONVENIOS_VG();

    }
}