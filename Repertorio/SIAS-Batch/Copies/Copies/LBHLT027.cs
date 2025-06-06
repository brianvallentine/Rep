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
    public class LBHLT027 : VarBasis
    {
        /*"01  LKIO-TIPO-OPERACAO                   PIC  X(02).*/
        public StringBasis LKIO_TIPO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"01  LKIO-COD-LOTERICO                    PIC S9(10)       COMP-3*/
        public IntBasis LKIO_COD_LOTERICO { get; set; } = new IntBasis(new PIC("S9", "10", "S9(10)"));
        /*"01  LKIO-CLASSE-ADESAO                   PIC  X(01).*/
        public StringBasis LKIO_CLASSE_ADESAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  LKIO-NUM-APOLICE                     PIC S9(13)       COMP-3*/
        public IntBasis LKIO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  LKIO-SITUACAO-APOLICE                PIC  X(05).*/
        public StringBasis LKIO_SITUACAO_APOLICE { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
        /*"01  LKIO-DT-INIVIG-APOLICE               PIC  X(08).*/
        public StringBasis LKIO_DT_INIVIG_APOLICE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"01  LKIO-DT-FIMVIG-APOLICE               PIC  X(08).*/
        public StringBasis LKIO_DT_FIMVIG_APOLICE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"01  LKIO-PREMIO-INCENDIO                 PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LKIO_PREMIO_INCENDIO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LKIO-PREMIO-VALORES                  PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LKIO_PREMIO_VALORES { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LKIO-PREMIO-DANELET                  PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LKIO_PREMIO_DANELET { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LKIO-PREMIO-AP-EMPGDR                PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LKIO_PREMIO_AP_EMPGDR { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LKIO-PREMIO-AP-EMP                   PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LKIO_PREMIO_AP_EMP { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LKIO-PREMIO-RC                       PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LKIO_PREMIO_RC { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LKIO-TX-PREMIO-INCENDIO              PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LKIO_TX_PREMIO_INCENDIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"01  LKIO-TX-PREMIO-VALORES               PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LKIO_TX_PREMIO_VALORES { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"01  LKIO-TX-PREMIO-DANELET               PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LKIO_TX_PREMIO_DANELET { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"01  LKIO-TX-PREMIO-AP-EMPGDR             PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LKIO_TX_PREMIO_AP_EMPGDR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"01  LKIO-TX-PREMIO-AP-EMP                PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LKIO_TX_PREMIO_AP_EMP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"01  LKIO-TX-PREMIO-RC                    PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LKIO_TX_PREMIO_RC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"01  LKIO-VL-IS-INCENDIO                  PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LKIO_VL_IS_INCENDIO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LKIO-VL-IS-VALORES                   PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LKIO_VL_IS_VALORES { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LKIO-VL-IS-DANELET                   PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LKIO_VL_IS_DANELET { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LKIO-VL-IS-AP-EMPGDR                 PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LKIO_VL_IS_AP_EMPGDR { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LKIO-VL-IS-AP-EMP                    PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LKIO_VL_IS_AP_EMP { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LKIO-VL-IS-RC                        PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LKIO_VL_IS_RC { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"01  LKIO-FATOR                           PIC S9(03)V9(9)  COMP-3*/
        public DoubleBasis LKIO_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(9)"), 9);
        /*"01  LKIO-QTD-PARCELAS                    PIC S9(04)       COMP.*/
        public IntBasis LKIO_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  LKIO-TIPO-PAGAMENTO                  PIC  X(01).*/
        public StringBasis LKIO_TIPO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  LKIO-TIPO-CALCULO                    PIC  X(02).*/
        public StringBasis LKIO_TIPO_CALCULO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"01  LKIO-CUSTO-APOLICE                   PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_CUSTO_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-IOF-PCL1                        PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_IOF_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-ADICIONAL-FRAC-PCL1             PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_ADICIONAL_FRAC_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-JUROS-PCL1                      PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_JUROS_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-PERC-JUROS-PCL1                 PIC S9(06)V9(04) COMP-3*/
        public DoubleBasis LKIO_PERC_JUROS_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(04)"), 4);
        /*"01  LKIO-VL-PREMIO-LIQ-PCL1              PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_VL_PREMIO_LIQ_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-VL-PREMIO-PCL1                  PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_VL_PREMIO_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-IOF-PCLN                        PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_IOF_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-ADICIONAL-FRAC-PCLN             PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_ADICIONAL_FRAC_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-JUROS-PCLN                      PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_JUROS_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-PERC-JUROS-PCLN                 PIC S9(13)V9(04) COMP-3*/
        public DoubleBasis LKIO_PERC_JUROS_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4);
        /*"01  LKIO-VL-PREMIO-LIQ-PCLN              PIC S9(13)V9(02) COMP-3*/
        public DoubleBasis LKIO_VL_PREMIO_LIQ_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01  LKIO-VL-PREMIO-PCLN                  PIC S9(13)V9(02) COMP-3*/
        public DoubleBasis LKIO_VL_PREMIO_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01  LKIO-VL-PREMIO-TOTAL                 PIC S9(13)V9(02) COMP-3*/
        public DoubleBasis LKIO_VL_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01  LKIO-JURO-TOTAL                      PIC S9(13)V9(02) COMP-3*/
        public DoubleBasis LKIO_JURO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01  LKIO-IOF-TOTAL                       PIC S9(13)V9(02) COMP-3*/
        public DoubleBasis LKIO_IOF_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01  LKIO-PREMIO-TAR-INC                  PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_PREMIO_TAR_INC { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-PREMIO-TAR-VAL                  PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_PREMIO_TAR_VAL { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-PREMIO-TAR-DAN                  PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_PREMIO_TAR_DAN { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-PREMIO-TAR-AP-EMPGDR            PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_PREMIO_TAR_AP_EMPGDR { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-PREMIO-TAR-AP-EMP               PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_PREMIO_TAR_AP_EMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-PREMIO-TAR-RC                   PIC S9(06)V9(02) COMP-3*/
        public DoubleBasis LKIO_PREMIO_TAR_RC { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(02)"), 2);
        /*"01  LKIO-COD-RETORNO                     PIC S9(05) COMP-3.*/
        public IntBasis LKIO_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
        /*"*/
    }
}