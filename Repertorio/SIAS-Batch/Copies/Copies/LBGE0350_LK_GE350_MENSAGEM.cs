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
    public class LBGE0350_LK_GE350_MENSAGEM : VarBasis
    {
        /*"       20 LK-GE350-SQLCODE        PIC -ZZ9*/
        public IntBasis LK_GE350_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9"));
        /*"       20 FILLER                  PIC X(01)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"       20 LK-GE350-MSG-RETORNO    PIC X(75)*/
        public StringBasis LK_GE350_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)"), @"");
        /*"*/
    }
}