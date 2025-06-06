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
    public class MR017_MR017_DES_CLAUSULA_BENEF : VarBasis
    {
        /*"       49 MR017-DES-CLAUSULA-BENEF-LEN  PIC S9(4) USAGE COMP.*/
        public IntBasis MR017_DES_CLAUSULA_BENEF_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 MR017-DES-CLAUSULA-BENEF-TEXT  PIC X(350).*/
        public StringBasis MR017_DES_CLAUSULA_BENEF_TEXT { get; set; } = new StringBasis(new PIC("X", "350", "X(350)."), @"");
        /*"*/
    }
}