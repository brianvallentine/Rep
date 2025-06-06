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
    public class VG094_VG094_DES_CARENCIA_MSG : VarBasis
    {
        /*"       49 VG094-DES-CARENCIA-MSG-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis VG094_DES_CARENCIA_MSG_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 VG094-DES-CARENCIA-MSG-TEXT          PIC X(1000).*/
        public StringBasis VG094_DES_CARENCIA_MSG_TEXT { get; set; } = new StringBasis(new PIC("X", "1000", "X(1000)."), @"");
        /*"    10 VG094-COD-USUARIO    PIC X(8).*/
    }
}