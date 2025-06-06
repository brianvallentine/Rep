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
    public class FCTPROPO_DCLFC_TP_PROPOSTA : VarBasis
    {
        /*"    10 FCTPROPO-NUM-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis FCTPROPO_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTPROPO-NUM-TP-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis FCTPROPO_NUM_TP_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTPROPO-COD-PROCESSO-SUSEP  PIC X(18).*/
        public StringBasis FCTPROPO_COD_PROCESSO_SUSEP { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
        /*"    10 FCTPROPO-NOM-PROPOSTA  PIC X(40).*/
        public StringBasis FCTPROPO_NOM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 FCTPROPO-COD-CANAL-VENDAS  PIC X(3).*/
        public StringBasis FCTPROPO_COD_CANAL_VENDAS { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCTPROPO-COD-TIPO-DESCONTO  PIC X(3).*/
        public StringBasis FCTPROPO_COD_TIPO_DESCONTO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCTPROPO-COD-TIPO-INDICADOR  PIC X(3).*/
        public StringBasis FCTPROPO_COD_TIPO_INDICADOR { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCTPROPO-COD-TIPO-METAS-CV  PIC X(3).*/
        public StringBasis FCTPROPO_COD_TIPO_METAS_CV { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCTPROPO-COD-TIPO-SUBSCR  PIC X(3).*/
        public StringBasis FCTPROPO_COD_TIPO_SUBSCR { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCTPROPO-COD-TIPO-TITULAR  PIC X(3).*/
        public StringBasis FCTPROPO_COD_TIPO_TITULAR { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCTPROPO-DTH-FIM-VENDAS  PIC X(10).*/
        public StringBasis FCTPROPO_DTH_FIM_VENDAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTPROPO-DTH-INI-VENDAS  PIC X(10).*/
        public StringBasis FCTPROPO_DTH_INI_VENDAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTPROPO-NUM-CONTA-MEMO  PIC S9(9) USAGE COMP.*/
        public IntBasis FCTPROPO_NUM_CONTA_MEMO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTPROPO-NUM-IDENT-PADRAO  PIC S9(4) USAGE COMP.*/
        public IntBasis FCTPROPO_NUM_IDENT_PADRAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTPROPO-NUM-INTV-REP-OUTR  PIC S9(4) USAGE COMP.*/
        public IntBasis FCTPROPO_NUM_INTV_REP_OUTR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTPROPO-NUM-INTV-REP-PRIM  PIC S9(4) USAGE COMP.*/
        public IntBasis FCTPROPO_NUM_INTV_REP_PRIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTPROPO-NUM-PARC-FIM-DESC  PIC S9(4) USAGE COMP.*/
        public IntBasis FCTPROPO_NUM_PARC_FIM_DESC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTPROPO-NUM-PARC-INI-DESC  PIC S9(4) USAGE COMP.*/
        public IntBasis FCTPROPO_NUM_PARC_INI_DESC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTPROPO-NUM-REP-OUTR-PARC  PIC S9(4) USAGE COMP.*/
        public IntBasis FCTPROPO_NUM_REP_OUTR_PARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTPROPO-NUM-REP-PRIM-PARC  PIC S9(4) USAGE COMP.*/
        public IntBasis FCTPROPO_NUM_REP_PRIM_PARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTPROPO-NUM-TITULO-FIM  PIC S9(9) USAGE COMP.*/
        public IntBasis FCTPROPO_NUM_TITULO_FIM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTPROPO-NUM-TITULO-INI  PIC S9(9) USAGE COMP.*/
        public IntBasis FCTPROPO_NUM_TITULO_INI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTPROPO-QTD-MAX-TITULARES  PIC S9(4) USAGE COMP.*/
        public IntBasis FCTPROPO_QTD_MAX_TITULARES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTPROPO-QTD-MAX-TITULO-PF  PIC S9(9) USAGE COMP.*/
        public IntBasis FCTPROPO_QTD_MAX_TITULO_PF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTPROPO-QTD-MAX-TITULO-PJ  PIC S9(9) USAGE COMP.*/
        public IntBasis FCTPROPO_QTD_MAX_TITULO_PJ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTPROPO-QTD-MAX-VIAS-CART  PIC S9(4) USAGE COMP.*/
        public IntBasis FCTPROPO_QTD_MAX_VIAS_CART { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTPROPO-QTD-MAX-VIAS-TIT  PIC S9(4) USAGE COMP.*/
        public IntBasis FCTPROPO_QTD_MAX_VIAS_TIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTPROPO-STA-COBR-OUTR-PARC  PIC X(1).*/
        public StringBasis FCTPROPO_STA_COBR_OUTR_PARC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCTPROPO-STA-COBR-PRIM-PARC  PIC X(1).*/
        public StringBasis FCTPROPO_STA_COBR_PRIM_PARC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCTPROPO-STA-EMPRESA-CONVEN  PIC X(1).*/
        public StringBasis FCTPROPO_STA_EMPRESA_CONVEN { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCTPROPO-STA-GER-TIT-PAPEL  PIC X(1).*/
        public StringBasis FCTPROPO_STA_GER_TIT_PAPEL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCTPROPO-STA-SUBSCRITOR  PIC X(1).*/
        public StringBasis FCTPROPO_STA_SUBSCRITOR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCTPROPO-VLR-DESCONTO  PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCTPROPO_VLR_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCTPROPO-VLR-MAX-PARCELAS  PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCTPROPO_VLR_MAX_PARCELAS { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCTPROPO-VLR-MIN-PARCELAS  PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCTPROPO_VLR_MIN_PARCELAS { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCTPROPO-VLR-MULT-PARCELAS  PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCTPROPO_VLR_MULT_PARCELAS { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCTPROPO-NUM-INI-PROPOSTA  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FCTPROPO_NUM_INI_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FCTPROPO-NUM-FIM-PROPOSTA  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FCTPROPO_NUM_FIM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"*/
    }
}