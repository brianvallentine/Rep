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
    public class VG093 : VarBasis
    {
        /*"01  DCLVG-REPRES-LEGAL.*/
        public VG093_DCLVG_REPRES_LEGAL DCLVG_REPRES_LEGAL { get; set; } = new VG093_DCLVG_REPRES_LEGAL();

    }
}