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
    public class GE329_DCLGE_DNE_BAIRRO : VarBasis
    {
        /*"    10 GE329-NUM-BAIRRO     PIC S9(9) USAGE COMP.*/
        public IntBasis GE329_NUM_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE329-NUM-LOCALIDADE  PIC S9(9) USAGE COMP.*/
        public IntBasis GE329_NUM_LOCALIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE329-COD-UF         PIC X(2).*/
        public StringBasis GE329_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE329-NOM-BAIRRO     PIC X(72).*/
        public StringBasis GE329_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE329-NOM-BAIRRO-ABREV  PIC X(36).*/
        public StringBasis GE329_NOM_BAIRRO_ABREV { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"*/
    }
}