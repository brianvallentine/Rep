using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class _REDEF_SPVG001X_FILLER : VarBasis
    {
        /*"  10 VG001-ARR-STA-OCCURS     OCCURS 12 TIMES*/
        public ListBasis<SPVG001X_VG001_ARR_STA_OCCURS> VG001_ARR_STA_OCCURS { get; set; } = new ListBasis<SPVG001X_VG001_ARR_STA_OCCURS>(12);


        public _REDEF_SPVG001X_FILLER()
        {
            VG001_ARR_STA_OCCURS.ValueChanged += OnValueChanged;
        }

    }
}