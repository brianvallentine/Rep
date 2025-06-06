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
    public class LBLT3214_TABELA_VALORES_RET : VarBasis
    {
        /*"        15 LT3214-NUM-PROP-SIM          PIC S9(018)      COMP*/
        public IntBasis LT3214_NUM_PROP_SIM { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"        15 LT3214-IND-TIPO-VIG          PIC S9(004)      COMP*/
        public IntBasis LT3214_IND_TIPO_VIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"        15 LT3214-DTA-INI-VIGENCIA      PIC X(10)*/
        public StringBasis LT3214_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"        15 LT3214-DTA-FIM-VIGENCIA      PIC X(10)*/
        public StringBasis LT3214_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"        15 LT3214-IND-FCOB-SEG          PIC S9(004)      COMP*/
        public IntBasis LT3214_IND_FCOB_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"        15 LT3214-IND-FPG-PRIM-PCL      PIC S9(004)      COMP*/
        public IntBasis LT3214_IND_FPG_PRIM_PCL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"        15 LT3214-IND-FPG-DEM-PCL       PIC S9(004)      COMP*/
        public IntBasis LT3214_IND_FPG_DEM_PCL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"        15 LT3214-DTA-VENC-PRIM-PCL     PIC X(10)*/
        public StringBasis LT3214_DTA_VENC_PRIM_PCL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"        15 LT3214-DIA-VENC-DEM-PCL      PIC S9(004)      COMP*/
        public IntBasis LT3214_DIA_VENC_DEM_PCL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"        15 LT3214-QTD-PARCELAS          PIC S9(004)      COMP*/
        public IntBasis LT3214_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"        15  LT3214-VL-PREMIO-PCL1       PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_VL_PREMIO_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-VL-PREMIO-LIQ-PCL1   PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_VL_PREMIO_LIQ_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-VL-IOF-PCL1          PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_VL_IOF_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-VL-ADICIONAL-PCL1    PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_VL_ADICIONAL_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-VL-JUROS-PCL1        PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_VL_JUROS_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-VL-PREMIO-TOT-PCL1   PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_VL_PREMIO_TOT_PCL1 { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-VL-PREMIO-PCLN       PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_VL_PREMIO_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-VL-PREMIO-LIQ-PCLN   PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_VL_PREMIO_LIQ_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-VL-IOF-PCLN          PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_VL_IOF_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-VL-ADICIONAL-PCLN    PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_VL_ADICIONAL_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-VL-JUROS-PCLN        PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_VL_JUROS_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-VL-PREMIO-TOT-PCLN   PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_VL_PREMIO_TOT_PCLN { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-DESC-FIDEL           PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_DESC_FIDEL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-DESC-FIDEL-INFO      PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_DESC_FIDEL_INFO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-DESC-EXP             PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_DESC_EXP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-DESC-EXP-INFO        PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_DESC_EXP_INFO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-DESC-AGRUP           PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_DESC_AGRUP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-DESC-COFRE           PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_DESC_COFRE { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15  LT3214-DESC-BLINDAGEM       PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3214_DESC_BLINDAGEM { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"        15 LT3214-VL-SUBTOTAL           PIC S9(10)V9(2) COMP-3*/
        public DoubleBasis LT3214_VL_SUBTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"        15 LT3214-VL-DESCONTO           PIC S9(10)V9(2) COMP-3*/
        public DoubleBasis LT3214_VL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"        15 LT3214-VL-PREMIO-LIQ         PIC S9(10)V9(2) COMP-3*/
        public DoubleBasis LT3214_VL_PREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"        15 LT3214-VL-ADICIONAL          PIC S9(10)V9(2) COMP-3*/
        public DoubleBasis LT3214_VL_ADICIONAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"        15 LT3214-VL-JURO               PIC S9(10)V9(2) COMP-3*/
        public DoubleBasis LT3214_VL_JURO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"        15 LT3214-VL-CUSTO-EMISSAO      PIC S9(10)V9(2) COMP-3*/
        public DoubleBasis LT3214_VL_CUSTO_EMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"        15 LT3214-VL-IOF                PIC S9(10)V9(2) COMP-3*/
        public DoubleBasis LT3214_VL_IOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"        15 LT3214-VL-PREMIO-TOTAL       PIC S9(10)V9(2) COMP-3*/
        public DoubleBasis LT3214_VL_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"  05  LT3214-COD-RETORNO            PIC S9(05) COMP VALUE +0*/
    }
}