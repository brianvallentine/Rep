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
    public class VG102_VG102_DES_MSG_CRITICA : VarBasis
    {
        /*"       49 VG102-DES-MSG-CRITICA-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis VG102_DES_MSG_CRITICA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 VG102-DES-MSG-CRITICA-TEXT          PIC X(255).*/
        public StringBasis VG102_DES_MSG_CRITICA_TEXT { get; set; } = new StringBasis(new PIC("X", "255", "X(255)."), @"");
        /*"    10 VG102-DES-ABREV-MSG-CRITICA       PIC X(100).*/
    }
}