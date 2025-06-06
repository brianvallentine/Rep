using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBLT3201_LT3201_AREA_PARAMETROS : VarBasis
    {
        /*"  05  LT3201-TIPO-OPERACAO          PIC  X(02)*/
        public StringBasis LT3201_TIPO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"  05  LT3201-COD-LOTERICO           PIC S9(10)       COMP-3*/
        public IntBasis LT3201_COD_LOTERICO { get; set; } = new IntBasis(new PIC("S9", "10", "S9(10)"));
        /*"  05  LT3201-CGCCPF                 PIC S9(15)       COMP-3*/
        public IntBasis LT3201_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"  05  LT3201-COD-USUARIO            PIC  X(10)*/
        public StringBasis LT3201_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"  05  LT3201-IND-VIGENCIA-PLURI     PIC S9(04)       COMP*/
        public IntBasis LT3201_IND_VIGENCIA_PLURI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-NUM-APOLICE            PIC S9(13)       COMP-3*/
        public IntBasis LT3201_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"  05  LT3201-DTINIVIG-PROPOSTA      PIC  X(10)*/
        public StringBasis LT3201_DTINIVIG_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"  05  LT3201-DTTERVIG-PROPOSTA      PIC  X(10)*/
        public StringBasis LT3201_DTTERVIG_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"  05  LT3201-COD-REGIAO             PIC S9(04)       COMP*/
        public IntBasis LT3201_COD_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-DDMM-VENC-1PARC        PIC X(10)*/
        public StringBasis LT3201_DDMM_VENC_1PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"  05  LT3201-COD-CLASSE-ADESAO      PIC  X(01)*/
        public StringBasis LT3201_COD_CLASSE_ADESAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"  05  LT3201-NUM-CLASSE-ADESAO      PIC S9(04)       COMP*/
        public IntBasis LT3201_NUM_CLASSE_ADESAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-DIA-VENC-DEMAIS-PARC        PIC S9(04)       COMP*/
        public IntBasis LT3201_DIA_VENC_DEMAIS_PARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-IND-FORMA-PGTO-PRI-PARC     PIC S9(04)   COMP*/
        public IntBasis LT3201_IND_FORMA_PGTO_PRI_PARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-IND-FORMA-PGTO-DEM-PARC     PIC S9(04)   COMP*/
        public IntBasis LT3201_IND_FORMA_PGTO_DEM_PARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-NUM-PARCELA                 PIC S9(04)   COMP*/
        public IntBasis LT3201_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-QTD-PARCELAS                PIC S9(04)   COMP*/
        public IntBasis LT3201_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-IND-TIPO-ENDOSSO            PIC S9(04)   COMP*/
        public IntBasis LT3201_IND_TIPO_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-NUM-PROPOSTA-SIM       PIC S9(18)       COMP*/
        public IntBasis LT3201_NUM_PROPOSTA_SIM { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"  05  LT3201-IND-TIPO-VIGENCIA      PIC S9(04)       COMP*/
        public IntBasis LT3201_IND_TIPO_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-IND-GRAVAR-CALCULO     PIC S9(04)    COMP*/
        public IntBasis LT3201_IND_GRAVAR_CALCULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-TIPO-CALCULO           PIC  X(02)*/
        public StringBasis LT3201_TIPO_CALCULO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"  05  LT3201-CUSTO-APOLICE          PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3201_CUSTO_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3201-PCT-IOF                PIC S9(03)V9(06) COMP-3*/
        public DoubleBasis LT3201_PCT_IOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(06)"), 6);
        /*"  05  LT3201-DISPLAY                PIC  X(01)*/
        public StringBasis LT3201_DISPLAY { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"  05  LT3201-QTDRENOV               PIC S9(04) COMP*/
        public IntBasis LT3201_QTDRENOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-TABELA-IMPSEG*/
        public LBLT3201_LT3201_TABELA_IMPSEG LT3201_TABELA_IMPSEG { get; set; } = new LBLT3201_LT3201_TABELA_IMPSEG();

        public LBLT3201_LT3201_TABELA_TAXAS LT3201_TABELA_TAXAS { get; set; } = new LBLT3201_LT3201_TABELA_TAXAS();

        public LBLT3201_LT3201_TABELA_VALORES_CB LT3201_TABELA_VALORES_CB { get; set; } = new LBLT3201_LT3201_TABELA_VALORES_CB();

        public LBLT3201_TABELA_VALORES_RETORNO TABELA_VALORES_RETORNO { get; set; } = new LBLT3201_TABELA_VALORES_RETORNO();

        public LBLT3201_LT3201_TABELA_PREMIOS LT3201_TABELA_PREMIOS { get; set; } = new LBLT3201_LT3201_TABELA_PREMIOS();

        public LBLT3201_LT3201_TABELA_COEF LT3201_TABELA_COEF { get; set; } = new LBLT3201_LT3201_TABELA_COEF();

        public LBLT3201_LT3201_TABELA_PCT_PLURI LT3201_TABELA_PCT_PLURI { get; set; } = new LBLT3201_LT3201_TABELA_PCT_PLURI();

        public DoubleBasis LT3201_PCT_DESC_FIDEL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT3201-PCT-DESC-FIDEL-INFO    PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT3201_PCT_DESC_FIDEL_INFO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT3201-PCT-DESC-EXP           PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT3201_PCT_DESC_EXP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT3201-PCT-DESC-EXP-INFO      PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT3201_PCT_DESC_EXP_INFO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT3201-PCT-DESC-AGRUP         PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT3201_PCT_DESC_AGRUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT3201-PCT-DESC-COFRE         PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT3201_PCT_DESC_COFRE { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT3201-PCT-DESC-BLINDAGEM     PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT3201_PCT_DESC_BLINDAGEM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT3201-IOF-PCL1               PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3201_IOF_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3201-ADICIONAL-FRAC-PCL1    PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3201_ADICIONAL_FRAC_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3201-JUROS-PCL1             PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3201_JUROS_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3201-PERC-JUROS-PCL1        PIC S9(06)V9(04) COMP-3*/
        public DoubleBasis LT3201_PERC_JUROS_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(04)"), 4);
        /*"  05  LT3201-VL-PREMIO-LIQ-PCL1     PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3201_VL_PREMIO_LIQ_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3201-VL-PREMIO-PCL1         PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3201_VL_PREMIO_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3201-IOF-PCLN               PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3201_IOF_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3201-ADICIONAL-FRAC-PCLN    PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3201_ADICIONAL_FRAC_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3201-JUROS-PCLN             PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3201_JUROS_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3201-PERC-JUROS-PCLN        PIC S9(06)V9(04) COMP-3*/
        public DoubleBasis LT3201_PERC_JUROS_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(04)"), 4);
        /*"  05  LT3201-VL-PREMIO-LIQ-PCLN     PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3201_VL_PREMIO_LIQ_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3201-VL-PREMIO-PCLN         PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3201_VL_PREMIO_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3201-VL-SUBTOTAL            PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_VL_SUBTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-DESC-FIDEL             PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_DESC_FIDEL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-DESC-FIDEL-INFO        PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_DESC_FIDEL_INFO { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-DESC-EXP               PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_DESC_EXP { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-DESC-EXP-INFO          PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_DESC_EXP_INFO { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-DESC-AGRUP             PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_DESC_AGRUP { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-DESC-COFRE             PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_DESC_COFRE { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-DESC-BLINDAGEM         PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_DESC_BLINDAGEM { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-VL-BOLETO              PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_VL_BOLETO { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-VL-PREMIO-LIQ          PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_VL_PREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-VL-PREMIO-TOTAL        PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_VL_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-VL-PREMIO-TOTAL-1PCL   PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_VL_PREMIO_TOTAL_1PCL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-JURO-TOTAL             PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_JURO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-IOF-TOTAL              PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_IOF_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-ADICIONAL-TOTAL        PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3201_ADICIONAL_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3201-NUM-APOL-DESC          PIC S9(13)       COMP-3*/
        public IntBasis LT3201_NUM_APOL_DESC { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"  05  LT3201-VLR-ADIC-COBER         PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3201_VLR_ADIC_COBER { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"  05  LT3201-CRITICAR-PRMLIQ        PIC S9(04)       COMP*/
        public IntBasis LT3201_CRITICAR_PRMLIQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3201-VLR-MIN-SAP            PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3201_VLR_MIN_SAP { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"  05  LT3201-VLR-MIN-PRMLIQ         PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3201_VLR_MIN_PRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"  05  LT3201-VLR-TAXA-ADESAO        PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3201_VLR_TAXA_ADESAO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"  05  LT3201-VL-DESC-TOTAIS         PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3201_VL_DESC_TOTAIS { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3201-VL-DESC-CONCEDIDO      PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3201_VL_DESC_CONCEDIDO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"  05  LT3201-QTD-REN-SSIN-IND       PIC  9(04)*/
        public IntBasis LT3201_QTD_REN_SSIN_IND { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"  05  LT3201-QTD-REN-SSIN-IND-INFO  PIC  9(04)*/
        public IntBasis LT3201_QTD_REN_SSIN_IND_INFO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"  05  LT3201-QTD-ESP-INFO           PIC  9(04)*/
        public IntBasis LT3201_QTD_ESP_INFO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"  05  LT3201-COD-RETORNO            PIC S9(05) COMP-3 VALUE +0*/
        public IntBasis LT3201_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
        /*"  05  LT3201-MSG-RETORNO            PIC  X(100)*/
        public StringBasis LT3201_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"*/
    }
}