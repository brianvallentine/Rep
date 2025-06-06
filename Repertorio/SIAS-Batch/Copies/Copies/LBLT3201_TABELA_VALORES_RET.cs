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
    public class LBLT3201_TABELA_VALORES_RET : VarBasis
    {
        /*"        15 LT3201-NUM-PROPOSTA-SIM-RET  PIC S9(018)      COMP*/
        public IntBasis LT3201_NUM_PROPOSTA_SIM_RET { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"        15 LT3201-IND-TIPO-VIGENCIA-RET PIC S9(004)      COMP*/
        public IntBasis LT3201_IND_TIPO_VIGENCIA_RET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"        15 LT3201-DTINIVIG-RET          PIC X(10)*/
        public StringBasis LT3201_DTINIVIG_RET { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"        15 LT3201-DTTERVIG-RET          PIC X(10)*/
        public StringBasis LT3201_DTTERVIG_RET { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"        15 LT3201-IND-FCOB-SEG-RET      PIC S9(004)      COMP*/
        public IntBasis LT3201_IND_FCOB_SEG_RET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"        15 LT3201-IND-FPG-PRIM-PCL-RET  PIC S9(004)      COMP*/
        public IntBasis LT3201_IND_FPG_PRIM_PCL_RET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"        15 LT3201-IND-FPG-DEM-PCL-RET   PIC S9(004)      COMP*/
        public IntBasis LT3201_IND_FPG_DEM_PCL_RET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"        15 LT3201-VLR-PRIM-PCL-RET      PIC S9(010)V9(2) COMP*/
        public DoubleBasis LT3201_VLR_PRIM_PCL_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-DEM-PCL-RET       PIC S9(010)V9(2) COMP*/
        public DoubleBasis LT3201_VLR_DEM_PCL_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-DTA-VENC-PRIM-PCL-RET PIC X(10)*/
        public StringBasis LT3201_DTA_VENC_PRIM_PCL_RET { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"        15 LT3201-DIA-VENC-DEM-PCL-RET  PIC S9(004)      COMP*/
        public IntBasis LT3201_DIA_VENC_DEM_PCL_RET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"        15 LT3201-QTD-PCL-RET           PIC S9(004)      COMP*/
        public IntBasis LT3201_QTD_PCL_RET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"        15 LT3201-VLR-IOF-PRIM-PCL-RET  PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_IOF_PRIM_PCL_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-IOF-DEM-PCL-RET   PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_IOF_DEM_PCL_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-DESC-FID-RET      PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_DESC_FID_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-DESC-COB-ADIC-RET PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_DESC_COB_ADIC_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-DESC-RENOV-RET    PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_DESC_RENOV_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-DESC-EXP-RET      PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_DESC_EXP_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-DESC-COFRE-RET    PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_DESC_COFRE_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-DESC-BLIND-RET    PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_DESC_BLIND_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-DESC-PLURI-RET    PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_DESC_PLURI_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-PREMIO-TARIF-RET  PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_PREMIO_TARIF_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-DESC-TOT-RET      PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_DESC_TOT_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-PREMIO-LIQ-RET    PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_PREMIO_LIQ_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-ADIC-FRAC-RET     PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_ADIC_FRAC_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-CUSTO-EMIS-RET    PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_CUSTO_EMIS_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-IOF-RET           PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_IOF_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 LT3201-VLR-PREMIO-TOTAL-RET  PIC S9(010)V9(2) COMP-3*/
        public DoubleBasis LT3201_VLR_PREMIO_TOTAL_RET { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(2)"), 2);
        /*"        15 TABELA-DESCONTO-RET OCCURS 15 TIMES*/
        public ListBasis<LBLT3201_TABELA_DESCONTO_RET> TABELA_DESCONTO_RET { get; set; } = new ListBasis<LBLT3201_TABELA_DESCONTO_RET>(15);

    }
}