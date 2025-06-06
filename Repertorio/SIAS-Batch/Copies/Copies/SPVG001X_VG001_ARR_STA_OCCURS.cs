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
    public class SPVG001X_VG001_ARR_STA_OCCURS : VarBasis
    {
        /*"   15 VG001-ARR-STA-STATUS-DE        PIC  X(001)*/
        public StringBasis VG001_ARR_STA_STATUS_DE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"   15 VG001-ARR-STA-PARA*/
        public SPVG001X_VG001_ARR_STA_PARA VG001_ARR_STA_PARA { get; set; } = new SPVG001X_VG001_ARR_STA_PARA();


        public SPVG001X_VG001_ARR_STA_OCCURS()
        {
            VG001_ARR_STA_STATUS_DE.ValueChanged += OnValueChanged;
            VG001_ARR_STA_PARA.ValueChanged += OnValueChanged;
        }

    }
}