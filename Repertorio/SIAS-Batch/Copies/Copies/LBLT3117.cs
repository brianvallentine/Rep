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
    public class LBLT3117 : VarBasis
    {
        /*"01  LT3117-TIPO-OPERACAO               PIC  X(02)*/
        public StringBasis LT3117_TIPO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"01  LT3117-COD-LOTERICO                PIC S9(10)       COMP-3*/
        public IntBasis LT3117_COD_LOTERICO { get; set; } = new IntBasis(new PIC("S9", "10", "S9(10)"));
        /*"01  LT3117-NUM-CLASSE-ADESAO           PIC S9(04)       COMP*/
        public IntBasis LT3117_NUM_CLASSE_ADESAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  LT3117-NUM-APOLICE                 PIC S9(13)       COMP-3*/
        public IntBasis LT3117_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  LT3117-DTINIVIG-APOLICE            PIC  X(10)*/
        public StringBasis LT3117_DTINIVIG_APOLICE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  LT3117-DTTERVIG-APOLICE            PIC  X(10)*/
        public StringBasis LT3117_DTTERVIG_APOLICE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  LT3117-QTD-PARCELAS                PIC S9(04)       COMP*/
        public IntBasis LT3117_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  LT3117-TIPO-CALCULO                PIC  X(02)*/
        public StringBasis LT3117_TIPO_CALCULO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"01  LT3117-CUSTO-APOLICE               PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3117_CUSTO_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LT3117-PCT-IOF                     PIC S9(03)V9(06) COMP-3*/
        public DoubleBasis LT3117_PCT_IOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(06)"), 6);
        /*"01  LT3117-TX-INCENDIO                 PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LT3117_TX_INCENDIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"01  LT3117-TX-VALORES                  PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LT3117_TX_VALORES { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"01  LT3117-TX-DANELET                  PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LT3117_TX_DANELET { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"01  LT3117-TX-AP-EMPGDR                PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LT3117_TX_AP_EMPGDR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"01  LT3117-TX-AP-EMP                   PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LT3117_TX_AP_EMP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"01  LT3117-TX-RC                       PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LT3117_TX_RC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"01  LT3117-VL-IS-INCENDIO              PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3117_VL_IS_INCENDIO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LT3117-VL-IS-VALORES               PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3117_VL_IS_VALORES { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LT3117-VL-IS-DANELET               PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3117_VL_IS_DANELET { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LT3117-VL-IS-AP-EMPGDR             PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3117_VL_IS_AP_EMPGDR { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LT3117-VL-IS-AP-EMP                PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3117_VL_IS_AP_EMP { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LT3117-VL-IS-RC                    PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3117_VL_IS_RC { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LT3117-IOF-PCL1                    PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3117_IOF_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LT3117-ADICIONAL-FRAC-PCL1         PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3117_ADICIONAL_FRAC_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LT3117-JUROS-PCL1                  PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3117_JUROS_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LT3117-PERC-JUROS-PCL1             PIC S9(06)V9(04) COMP-3*/
        public DoubleBasis LT3117_PERC_JUROS_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(04)"), 4);
        /*"01  LT3117-VL-PREMIO-LIQ-PCL1          PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3117_VL_PREMIO_LIQ_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LT3117-VL-PREMIO-PCL1              PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3117_VL_PREMIO_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LT3117-IOF-PCLN                    PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3117_IOF_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LT3117-ADICIONAL-FRAC-PCLN         PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3117_ADICIONAL_FRAC_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LT3117-JUROS-PCLN                  PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3117_JUROS_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LT3117-PERC-JUROS-PCLN             PIC S9(06)V9(04) COMP-3*/
        public DoubleBasis LT3117_PERC_JUROS_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(04)"), 4);
        /*"01  LT3117-VL-PREMIO-LIQ-PCLN          PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3117_VL_PREMIO_LIQ_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LT3117-VL-PREMIO-PCLN              PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LT3117_VL_PREMIO_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LT3117-VL-PREMIO-TOTAL             PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3117_VL_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"01  LT3117-VL-PREMIO-TOTAL-1PCL        PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3117_VL_PREMIO_TOTAL_1PCL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"01  LT3117-JURO-TOTAL                  PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3117_JURO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"01  LT3117-IOF-TOTAL                   PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3117_IOF_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"01  LT3117-ADICIONAL-TOTAL             PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3117_ADICIONAL_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"01  LT3117-PREMIO-INCENDIO             PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3117_PREMIO_INCENDIO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"01  LT3117-PREMIO-VALORES              PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3117_PREMIO_VALORES { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"01  LT3117-PREMIO-DANELET              PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3117_PREMIO_DANELET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"01  LT3117-PREMIO-AP-EMPGDR            PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3117_PREMIO_AP_EMPGDR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"01  LT3117-PREMIO-AP-EMP               PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3117_PREMIO_AP_EMP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"01  LT3117-PREMIO-RC                   PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3117_PREMIO_RC { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"01  LT3117-COD-RETORNO                 PIC S9(05) COMP-3*/
        public IntBasis LT3117_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
    }
}