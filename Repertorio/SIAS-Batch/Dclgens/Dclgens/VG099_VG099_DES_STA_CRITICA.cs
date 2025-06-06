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
    public class VG099_VG099_DES_STA_CRITICA : VarBasis
    {
        /*"       49 VG099-DES-STA-CRITICA-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis VG099_DES_STA_CRITICA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 VG099-DES-STA-CRITICA-TEXT          PIC X(255).*/
        public StringBasis VG099_DES_STA_CRITICA_TEXT { get; set; } = new StringBasis(new PIC("X", "255", "X(255)."), @"");
        /*"    10 VG099-COD-USUARIO    PIC X(8).*/
    }
}