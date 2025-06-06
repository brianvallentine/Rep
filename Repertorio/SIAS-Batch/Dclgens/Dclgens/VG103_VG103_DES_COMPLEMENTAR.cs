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
    public class VG103_VG103_DES_COMPLEMENTAR : VarBasis
    {
        /*"       49 VG103-DES-COMPLEMENTAR-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis VG103_DES_COMPLEMENTAR_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 VG103-DES-COMPLEMENTAR-TEXT          PIC X(1000).*/
        public StringBasis VG103_DES_COMPLEMENTAR_TEXT { get; set; } = new StringBasis(new PIC("X", "1000", "X(1000)."), @"");
        /*"    10 VG103-COD-USUARIO    PIC X(8).*/
    }
}