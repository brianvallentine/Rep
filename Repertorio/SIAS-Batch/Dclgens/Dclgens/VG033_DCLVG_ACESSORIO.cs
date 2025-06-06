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
    public class VG033_DCLVG_ACESSORIO : VarBasis
    {
        /*"    10 VG033-NUM-ACESSORIO  PIC S9(4) USAGE COMP.*/
        public IntBasis VG033_NUM_ACESSORIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG033-COD-SIGLA-ACESS       PIC X(10).*/
        public StringBasis VG033_COD_SIGLA_ACESS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG033-DES-ACESSORIO  PIC X(40).*/
        public StringBasis VG033_DES_ACESSORIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 VG033-COD-USUARIO    PIC X(8).*/
        public StringBasis VG033_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG033-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis VG033_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VG033-IND-TP-ACESSORIO       PIC X(1).*/
        public StringBasis VG033_IND_TP_ACESSORIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}