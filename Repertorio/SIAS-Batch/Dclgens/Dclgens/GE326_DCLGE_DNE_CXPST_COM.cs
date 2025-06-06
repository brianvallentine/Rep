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
    public class GE326_DCLGE_DNE_CXPST_COM : VarBasis
    {
        /*"    10 GE326-NUM-CX-POSTAL  PIC S9(9) USAGE COMP.*/
        public IntBasis GE326_NUM_CX_POSTAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE326-COD-UF         PIC X(2).*/
        public StringBasis GE326_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE326-NUM-LOCALIDADE  PIC S9(9) USAGE COMP.*/
        public IntBasis GE326_NUM_LOCALIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE326-NOM-CX-POSTAL  PIC X(72).*/
        public StringBasis GE326_NOM_CX_POSTAL { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE326-DES-ENDERECO   PIC X(100).*/
        public StringBasis GE326_DES_ENDERECO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 GE326-COD-CEP        PIC X(8).*/
        public StringBasis GE326_COD_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}