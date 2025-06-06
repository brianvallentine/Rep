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
    public class VG132_VG132_NOM_ORGAO : VarBasis
    {
        /*"       49 VG132-NOM-ORGAO-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis VG132_NOM_ORGAO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 VG132-NOM-ORGAO-TEXT          PIC X(100).*/
        public StringBasis VG132_NOM_ORGAO_TEXT { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 VG132-IND-TP-PESSOA-RELAC       PIC X(1).*/
    }
}