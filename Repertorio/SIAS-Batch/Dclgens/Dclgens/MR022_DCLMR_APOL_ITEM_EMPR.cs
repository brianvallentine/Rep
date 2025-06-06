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
    public class MR022_DCLMR_APOL_ITEM_EMPR : VarBasis
    {
        /*"    10 MR022-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MR022_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MR022-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis MR022_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR022-NUM-ITEM       PIC S9(9) USAGE COMP.*/
        public IntBasis MR022_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR022-NUM-SUB-ITEM   PIC S9(4) USAGE COMP.*/
        public IntBasis MR022_NUM_SUB_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR022-COD-RUBRICA    PIC S9(9) USAGE COMP.*/
        public IntBasis MR022_COD_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR022-COD-SUB-RUBRICA  PIC S9(9) USAGE COMP.*/
        public IntBasis MR022_COD_SUB_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR022-PCT-DESC-COBERTURA  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MR022_PCT_DESC_COBERTURA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MR022-PCT-DESC-CORRETOR  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MR022_PCT_DESC_CORRETOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MR022-PCT-BONUS-RENOVCAO  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MR022_PCT_BONUS_RENOVCAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MR022-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis MR022_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MR022-COD-BENEFICIARIO  PIC S9(9) USAGE COMP.*/
        public IntBasis MR022_COD_BENEFICIARIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR022-DES-CLAUSULA-BENEF.*/
        public MR022_MR022_DES_CLAUSULA_BENEF MR022_DES_CLAUSULA_BENEF { get; set; } = new MR022_MR022_DES_CLAUSULA_BENEF();

    }
}