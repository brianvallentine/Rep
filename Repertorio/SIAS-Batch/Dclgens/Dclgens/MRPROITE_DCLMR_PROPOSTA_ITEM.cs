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
    public class MRPROITE_DCLMR_PROPOSTA_ITEM : VarBasis
    {
        /*"    10 MRPROITE-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROITE_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROITE-NUM-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis MRPROITE_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRPROITE-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis MRPROITE_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRPROITE-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROITE_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROITE-NUM-VERSAO  PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROITE_NUM_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROITE-NUM-TP-MORA-IMOVEL       PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROITE_NUM_TP_MORA_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROITE-NUM-TP-OCUP-IMOVEL       PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROITE_NUM_TP_OCUP_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROITE-DTH-INI-VIGENCIA       PIC X(10).*/
        public StringBasis MRPROITE_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MRPROITE-DTH-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis MRPROITE_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MRPROITE-IND-TIPO-SEGURO       PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROITE_IND_TIPO_SEGURO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROITE-NUM-PROPOSTA-SIMU       PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis MRPROITE_NUM_PROPOSTA_SIMU { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 MRPROITE-QTD-RENOVACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROITE_QTD_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROITE-STA-PROPOSTA-ITEM       PIC X(1).*/
        public StringBasis MRPROITE_STA_PROPOSTA_ITEM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MRPROITE-PCT-DESC-FIDEL       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MRPROITE_PCT_DESC_FIDEL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MRPROITE-PCT-DESC-AGRUP       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MRPROITE_PCT_DESC_AGRUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MRPROITE-PCT-DESC-EXPER       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MRPROITE_PCT_DESC_EXPER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MRPROITE-OCORR-ENDERECO       PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROITE_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROITE-DTH-TIMESTAMP       PIC X(26).*/
        public StringBasis MRPROITE_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MRPROITE-COD-CLIENTE       PIC S9(9) USAGE COMP.*/
        public IntBasis MRPROITE_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRPROITE-COD-BENEFICIARIO       PIC S9(9) USAGE COMP.*/
        public IntBasis MRPROITE_COD_BENEFICIARIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRPROITE-IND-RENOVACAO-AUT       PIC X(1).*/
        public StringBasis MRPROITE_IND_RENOVACAO_AUT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MRPROITE-PCT-DESC-FUNC-PUBL       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MRPROITE_PCT_DESC_FUNC_PUBL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MRPROITE-PCT-DESC-COMERCIAL       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MRPROITE_PCT_DESC_COMERCIAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"*/
    }
}