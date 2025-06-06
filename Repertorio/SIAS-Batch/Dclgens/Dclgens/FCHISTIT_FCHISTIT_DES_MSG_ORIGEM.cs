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
    public class FCHISTIT_FCHISTIT_DES_MSG_ORIGEM : VarBasis
    {
        /*"       49 FCHISTIT-DES-MSG-ORIGEM-LEN  PIC S9(4) USAGE COMP.*/
        public IntBasis FCHISTIT_DES_MSG_ORIGEM_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 FCHISTIT-DES-MSG-ORIGEM-TEXT  PIC X(256).*/
        public StringBasis FCHISTIT_DES_MSG_ORIGEM_TEXT { get; set; } = new StringBasis(new PIC("X", "256", "X(256)."), @"");
        /*"    10 FCHISTIT-DES-MSG-DESTINO.*/
    }
}