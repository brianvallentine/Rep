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
    public class MR028_DCLMR_PROP_RENOVACAO : VarBasis
    {
        /*"    10 MR028-COD-FONTE      PIC S9(4) USAGE COMP.*/
        public IntBasis MR028_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR028-NUM-PROPOSTA   PIC S9(9) USAGE COMP.*/
        public IntBasis MR028_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR028-NUM-ITEM       PIC S9(9) USAGE COMP.*/
        public IntBasis MR028_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR028-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MR028_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MR028-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis MR028_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR028-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis MR028_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR028-DTH-RENOVACAO  PIC X(10).*/
        public StringBasis MR028_DTH_RENOVACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MR028-NUM-TITULO     PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MR028_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MR028-VLR-PREMIO-TOTAL  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MR028_VLR_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MR028-VLR-ENTRADA    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MR028_VLR_ENTRADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MR028-VLR-PARCELA    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MR028_VLR_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MR028-DTH-CADASTRAMENTO  PIC X(10).*/
        public StringBasis MR028_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MR028-IND-RENOVACAO-AUT  PIC X(1).*/
        public StringBasis MR028_IND_RENOVACAO_AUT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MR028-IND-IMPRESSAO  PIC S9(4) USAGE COMP.*/
        public IntBasis MR028_IND_IMPRESSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}