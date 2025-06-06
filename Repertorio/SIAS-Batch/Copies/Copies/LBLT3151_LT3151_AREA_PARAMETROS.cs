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
    public class LBLT3151_LT3151_AREA_PARAMETROS : VarBasis
    {
        /*"  05  LT3151-TIPO-OPERACAO          PIC  X(02)*/
        public StringBasis LT3151_TIPO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"  05  LT3151-COD-LOTERICO           PIC S9(10)       COMP-3*/
        public IntBasis LT3151_COD_LOTERICO { get; set; } = new IntBasis(new PIC("S9", "10", "S9(10)"));
        /*"  05  LT3151-CGCCPF                 PIC S9(15)       COMP-3*/
        public IntBasis LT3151_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"  05  LT3151-NUM-CLASSE-ADESAO      PIC S9(04)       COMP*/
        public IntBasis LT3151_NUM_CLASSE_ADESAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3151-NUM-APOLICE            PIC S9(13)       COMP-3*/
        public IntBasis LT3151_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"  05  LT3151-DTINIVIG-APOLICE       PIC  X(10)*/
        public StringBasis LT3151_DTINIVIG_APOLICE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"  05  LT3151-DTTERVIG-APOLICE       PIC  X(10)*/
        public StringBasis LT3151_DTTERVIG_APOLICE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"  05  LT3151-COD-REGIAO             PIC S9(04)       COMP*/
        public IntBasis LT3151_COD_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3151-QTD-PARCELAS           PIC S9(04)       COMP*/
        public IntBasis LT3151_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3151-TIPO-CALCULO           PIC  X(02)*/
        public StringBasis LT3151_TIPO_CALCULO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"  05  LT3151-CUSTO-APOLICE          PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3151_CUSTO_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3151-PCT-IOF                PIC S9(03)V9(06) COMP-3*/
        public DoubleBasis LT3151_PCT_IOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(06)"), 6);
        /*"  05  LT3151-DISPLAY                PIC  X(01)*/
        public StringBasis LT3151_DISPLAY { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"  05  LT3151-QTDRENOV               PIC S9(04) COMP*/
        public IntBasis LT3151_QTDRENOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3151-TABELA-IMPSEG*/
        public LBLT3151_LT3151_TABELA_IMPSEG LT3151_TABELA_IMPSEG { get; set; } = new LBLT3151_LT3151_TABELA_IMPSEG();

        public LBLT3151_LT3151_TABELA_TAXAS LT3151_TABELA_TAXAS { get; set; } = new LBLT3151_LT3151_TABELA_TAXAS();

        public LBLT3151_LT3151_TABELA_PREMIOS LT3151_TABELA_PREMIOS { get; set; } = new LBLT3151_LT3151_TABELA_PREMIOS();

        public LBLT3151_LT3151_TABELA_COEF LT3151_TABELA_COEF { get; set; } = new LBLT3151_LT3151_TABELA_COEF();

        public DoubleBasis LT3151_PCT_DESC_FIDEL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT3151-PCT-DESC-EXP           PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT3151_PCT_DESC_EXP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT3151-PCT-DESC-AGRUP         PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT3151_PCT_DESC_AGRUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT3151-PCT-DESC-COFRE         PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT3151_PCT_DESC_COFRE { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT3151-PCT-DESC-BLINDAGEM     PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT3151_PCT_DESC_BLINDAGEM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT3151-IOF-PCL1               PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3151_IOF_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3151-ADICIONAL-FRAC-PCL1    PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3151_ADICIONAL_FRAC_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3151-JUROS-PCL1             PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3151_JUROS_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3151-PERC-JUROS-PCL1        PIC S9(06)V9(04) COMP-3*/
        public DoubleBasis LT3151_PERC_JUROS_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(04)"), 4);
        /*"  05  LT3151-VL-PREMIO-LIQ-PCL1     PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3151_VL_PREMIO_LIQ_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3151-VL-PREMIO-PCL1         PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3151_VL_PREMIO_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3151-IOF-PCLN               PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3151_IOF_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3151-ADICIONAL-FRAC-PCLN    PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3151_ADICIONAL_FRAC_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3151-JUROS-PCLN             PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3151_JUROS_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3151-PERC-JUROS-PCLN        PIC S9(06)V9(04) COMP-3*/
        public DoubleBasis LT3151_PERC_JUROS_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(04)"), 4);
        /*"  05  LT3151-VL-PREMIO-LIQ-PCLN     PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3151_VL_PREMIO_LIQ_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3151-VL-PREMIO-PCLN         PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3151_VL_PREMIO_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3151-VL-SUBTOTAL            PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_VL_SUBTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-DESC-FIDEL             PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_DESC_FIDEL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-DESC-EXP               PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_DESC_EXP { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-DESC-AGRUP             PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_DESC_AGRUP { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-DESC-COFRE             PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_DESC_COFRE { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-DESC-BLINDAGEM         PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_DESC_BLINDAGEM { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-VL-BOLETO              PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_VL_BOLETO { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-VL-PREMIO-LIQ          PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_VL_PREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-VL-PREMIO-TOTAL        PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_VL_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-VL-PREMIO-TOTAL-1PCL   PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_VL_PREMIO_TOTAL_1PCL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-JURO-TOTAL             PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_JURO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-IOF-TOTAL              PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_IOF_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-ADICIONAL-TOTAL        PIC S9(07)V9(02) COMP-3*/
        public DoubleBasis LT3151_ADICIONAL_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(07)V9(02)"), 2);
        /*"  05  LT3151-NUM-APOL-DESC          PIC S9(13)       COMP-3*/
        public IntBasis LT3151_NUM_APOL_DESC { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"  05  LT3151-COD-RETORNO            PIC S9(05) COMP-3 VALUE +0*/
        public IntBasis LT3151_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
        /*"  05  LT3151-MSG-RETORNO            PIC  X(100)*/
        public StringBasis LT3151_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"  05  LT3151-VLR-ADIC-COBER         PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3151_VLR_ADIC_COBER { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"  05  LT3151-CRITICAR-PRMLIQ        PIC S9(04)       COMP*/
        public IntBasis LT3151_CRITICAR_PRMLIQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3151-VLR-MIN-SAP            PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3151_VLR_MIN_SAP { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"  05  LT3151-VLR-MIN-PRMLIQ         PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3151_VLR_MIN_PRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"  05  LT3151-VLR-TAXA-ADESAO        PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3151_VLR_TAXA_ADESAO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"  05  LT3151-VL-DESC-TOTAIS         PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3151_VL_DESC_TOTAIS { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"  05  LT3151-VL-DESC-CONCEDIDO      PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3151_VL_DESC_CONCEDIDO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
    }
}