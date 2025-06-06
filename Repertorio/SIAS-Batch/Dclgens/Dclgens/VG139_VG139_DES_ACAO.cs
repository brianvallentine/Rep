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
    public class VG139_VG139_DES_ACAO : VarBasis
    {
        /*"       49 VG139-DES-ACAO-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis VG139_DES_ACAO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 VG139-DES-ACAO-TEXT          PIC X(255).*/
        public StringBasis VG139_DES_ACAO_TEXT { get; set; } = new StringBasis(new PIC("X", "255", "X(255)."), @"");
        /*"    10 VG139-COD-USUARIO    PIC X(8).*/
    }
}