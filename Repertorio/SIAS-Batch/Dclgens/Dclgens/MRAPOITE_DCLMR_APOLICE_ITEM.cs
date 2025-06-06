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
    public class MRAPOITE_DCLMR_APOLICE_ITEM : VarBasis
    {
        /*"    10 MRAPOITE-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MRAPOITE_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MRAPOITE-NUM-ENDOSSO       PIC S9(9) USAGE COMP.*/
        public IntBasis MRAPOITE_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRAPOITE-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis MRAPOITE_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRAPOITE-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis MRAPOITE_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRAPOITE-NUM-VERSAO  PIC S9(4) USAGE COMP.*/
        public IntBasis MRAPOITE_NUM_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRAPOITE-DTH-INI-VIG-ITEM       PIC X(10).*/
        public StringBasis MRAPOITE_DTH_INI_VIG_ITEM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MRAPOITE-DTH-FIM-VIG-ITEM       PIC X(10).*/
        public StringBasis MRAPOITE_DTH_FIM_VIG_ITEM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MRAPOITE-NUM-TP-MORA-IMOVEL       PIC S9(4) USAGE COMP.*/
        public IntBasis MRAPOITE_NUM_TP_MORA_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRAPOITE-NUM-TP-OCUP-IMOVEL       PIC S9(4) USAGE COMP.*/
        public IntBasis MRAPOITE_NUM_TP_OCUP_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRAPOITE-QTD-RENOVACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis MRAPOITE_QTD_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRAPOITE-OCORR-ENDERECO       PIC S9(4) USAGE COMP.*/
        public IntBasis MRAPOITE_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRAPOITE-STA-PROP-ITEM       PIC X(1).*/
        public StringBasis MRAPOITE_STA_PROP_ITEM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MRAPOITE-PCT-DESC-FIDEL       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MRAPOITE_PCT_DESC_FIDEL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MRAPOITE-PCT-DESC-AGRUP       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MRAPOITE_PCT_DESC_AGRUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MRAPOITE-PCT-DESC-EXPER       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MRAPOITE_PCT_DESC_EXPER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MRAPOITE-DTH-TIMESTAMP       PIC X(26).*/
        public StringBasis MRAPOITE_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MRAPOITE-COD-CLIENTE       PIC S9(9) USAGE COMP.*/
        public IntBasis MRAPOITE_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRAPOITE-COD-BENEFICIARIO       PIC S9(9) USAGE COMP.*/
        public IntBasis MRAPOITE_COD_BENEFICIARIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRAPOITE-IND-RENOVACAO-AUT       PIC X(1).*/
        public StringBasis MRAPOITE_IND_RENOVACAO_AUT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MRAPOITE-NUM-PROPOSTA-SIMU       PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis MRAPOITE_NUM_PROPOSTA_SIMU { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 MRAPOITE-PCT-DESC-FUNC-PUBL       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MRAPOITE_PCT_DESC_FUNC_PUBL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MRAPOITE-PCT-DESC-COMERCIAL       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MRAPOITE_PCT_DESC_COMERCIAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"*/
    }
}