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
    public class LBGE0355_LK_GE355_OUT_MENSAGEM : VarBasis
    {
        /*"       20 LK-GE355-OUT-SQLCODE         PIC  -ZZ9*/
        public IntBasis LK_GE355_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9"));
        /*"       20 FILLER                       PIC  X(001)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"       20 LK-GE355-OUT-MSG-RETORNO     PIC  X(075)*/
        public StringBasis LK_GE355_OUT_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"");
    }
}