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
    public class GE324_DCLGE_DNE_LOCALIDADE : VarBasis
    {
        /*"    10 GE324-NUM-LOCALIDADE       PIC S9(9) USAGE COMP.*/
        public IntBasis GE324_NUM_LOCALIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE324-COD-UF         PIC X(2).*/
        public StringBasis GE324_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE324-NOM-LOCALIDADE       PIC X(72).*/
        public StringBasis GE324_NOM_LOCALIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE324-COD-CEP        PIC X(8).*/
        public StringBasis GE324_COD_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE324-IND-SIT-LOCALIDADE       PIC X(1).*/
        public StringBasis GE324_IND_SIT_LOCALIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE324-IND-TP-LOCALIDADE       PIC X(1).*/
        public StringBasis GE324_IND_TP_LOCALIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE324-NUM-SUB-LOCALIDADE       PIC S9(9) USAGE COMP.*/
        public IntBasis GE324_NUM_SUB_LOCALIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE324-NOM-ABREV-LOCALID       PIC X(36).*/
        public StringBasis GE324_NOM_ABREV_LOCALID { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"    10 GE324-COD-IBGE-MUNICIPIO       PIC S9(9) USAGE COMP.*/
        public IntBasis GE324_COD_IBGE_MUNICIPIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}