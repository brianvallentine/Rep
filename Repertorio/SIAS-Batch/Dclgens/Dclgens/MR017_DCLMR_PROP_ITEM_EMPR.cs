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
    public class MR017_DCLMR_PROP_ITEM_EMPR : VarBasis
    {
        /*"    10 MR017-COD-FONTE      PIC S9(4) USAGE COMP.*/
        public IntBasis MR017_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR017-NUM-PROPOSTA   PIC S9(9) USAGE COMP.*/
        public IntBasis MR017_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR017-NUM-ITEM       PIC S9(9) USAGE COMP.*/
        public IntBasis MR017_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR017-NUM-SUB-ITEM   PIC S9(4) USAGE COMP.*/
        public IntBasis MR017_NUM_SUB_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR017-COD-RUBRICA    PIC S9(9) USAGE COMP.*/
        public IntBasis MR017_COD_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR017-COD-SUB-RUBRICA  PIC S9(9) USAGE COMP.*/
        public IntBasis MR017_COD_SUB_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR017-PCT-DESC-COBERTURA  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MR017_PCT_DESC_COBERTURA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MR017-PCT-DESC-CORRETOR  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MR017_PCT_DESC_CORRETOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MR017-PCT-BONUS-RENOV  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MR017_PCT_BONUS_RENOV { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MR017-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis MR017_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MR017-COD-BENEFICIARIO  PIC S9(9) USAGE COMP.*/
        public IntBasis MR017_COD_BENEFICIARIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR017-DES-CLAUSULA-BENEF.*/
        public MR017_MR017_DES_CLAUSULA_BENEF MR017_DES_CLAUSULA_BENEF { get; set; } = new MR017_MR017_DES_CLAUSULA_BENEF();

    }
}