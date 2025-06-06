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
    public class SPVG001X_VG001_ARR_STA_PARA : VarBasis
    {
        /*"    20 VG001-ARR-STA-STATUS-PARA     PIC  X(001) OCCURS 4 TIMES*/
        public ListBasis<StringBasis, string> VG001_ARR_STA_STATUS_PARA { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)"), 4);
        /*"*/

        public SPVG001X_VG001_ARR_STA_PARA()
        {
            VG001_ARR_STA_STATUS_PARA.ValueChanged += OnValueChanged;
        }

    }
}