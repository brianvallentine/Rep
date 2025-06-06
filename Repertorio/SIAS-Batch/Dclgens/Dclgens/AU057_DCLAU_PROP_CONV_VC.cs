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
    public class AU057_DCLAU_PROP_CONV_VC : VarBasis
    {
        /*"    10 AU057-NUM-PROPOSTA-VC       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis AU057_NUM_PROPOSTA_VC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 AU057-COD-FONTE      PIC S9(4) USAGE COMP.*/
        public IntBasis AU057_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU057-NUM-PROPOSTA   PIC S9(9) USAGE COMP.*/
        public IntBasis AU057_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU057-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis AU057_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 AU057-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis AU057_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU057-COD-TIPO-ENDOSSO       PIC X(1).*/
        public StringBasis AU057_COD_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AU057-NUM-RCAP       PIC S9(9) USAGE COMP.*/
        public IntBasis AU057_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU057-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis AU057_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 AU057-IND-OPERACAO   PIC X(3).*/
        public StringBasis AU057_IND_OPERACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 AU057-NUM-APOLICE-VC       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis AU057_NUM_APOLICE_VC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 AU057-NUM-ENDOSSO-VC       PIC S9(9) USAGE COMP.*/
        public IntBasis AU057_NUM_ENDOSSO_VC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU057-NUM-FCA-VC     PIC S9(17)V USAGE COMP-3.*/
        public DoubleBasis AU057_NUM_FCA_VC { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V"), 0);
        /*"    10 AU057-COD-CLIENTE    PIC S9(9) USAGE COMP.*/
        public IntBasis AU057_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU057-DTH-INI-VIGENCIA       PIC X(10).*/
        public StringBasis AU057_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AU057-DTH-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis AU057_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AU057-DTH-ANO-FABRICACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis AU057_DTH_ANO_FABRICACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU057-DTH-ANO-MODELO       PIC S9(4) USAGE COMP.*/
        public IntBasis AU057_DTH_ANO_MODELO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU057-DES-VEICULO    PIC X(40).*/
        public StringBasis AU057_DES_VEICULO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 AU057-COD-CONGENERE  PIC S9(4) USAGE COMP.*/
        public IntBasis AU057_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}