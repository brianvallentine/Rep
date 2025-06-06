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
    public class LT028_DCLLT_PREMIO : VarBasis
    {
        /*"    10 LT028-NUM-PROPOSTA-SIM       PIC S9(18) USAGE COMP.*/
        public IntBasis LT028_NUM_PROPOSTA_SIM { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 LT028-IND-TIPO-VIGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis LT028_IND_TIPO_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LT028-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis LT028_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LT028-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis LT028_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LT028-IND-FORMA-COBRANCA-SEG       PIC S9(4) USAGE COMP.*/
        public IntBasis LT028_IND_FORMA_COBRANCA_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LT028-IND-FORMA-PGTO-PRIM-PARC       PIC S9(4) USAGE COMP.*/
        public IntBasis LT028_IND_FORMA_PGTO_PRIM_PARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LT028-IND-FORMA-PGTO-DEM-PARC       PIC S9(4) USAGE COMP.*/
        public IntBasis LT028_IND_FORMA_PGTO_DEM_PARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LT028-VLR-PRIM-PARCELA       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_PRIM_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 LT028-VLR-DEMAIS-PARCELAS       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_DEMAIS_PARCELAS { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 LT028-DTA-VENC-PRIM-PARCELA       PIC X(10).*/
        public StringBasis LT028_DTA_VENC_PRIM_PARCELA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LT028-DIA-VENC-DEMAIS-PARCELAS       PIC S9(4) USAGE COMP.*/
        public IntBasis LT028_DIA_VENC_DEMAIS_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LT028-QTD-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis LT028_QTD_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LT028-VLR-IOF-PRIM-PARCELA       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_IOF_PRIM_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-IOF-DEMAIS-PARCELAS       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_IOF_DEMAIS_PARCELAS { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-DESCONTO-FIDELIDADE       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_DESCONTO_FIDELIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-DESCONTO-COB-ADIC       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_DESCONTO_COB_ADIC { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-DESCONTO-RENOVACAO       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_DESCONTO_RENOVACAO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-DESCONTO-EXPERIENCIA       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_DESCONTO_EXPERIENCIA { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-DESCONTO-COFRE-INT       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_DESCONTO_COFRE_INT { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-DESCONTO-BLINDAGEM       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_DESCONTO_BLINDAGEM { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-DESCONTO-PLURIANUAL       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_DESCONTO_PLURIANUAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-PREMIO-TARIFARIO       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_PREMIO_TARIFARIO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 LT028-VLR-DESCONTO-TOTAL       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_DESCONTO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 LT028-VLR-PREMIO-LIQUIDO       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_PREMIO_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 LT028-VLR-ADICIONAL-FRACIONA       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_ADICIONAL_FRACIONA { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-CUSTO-EMISSAO       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_CUSTO_EMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-IOF        PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_IOF { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-PREMIO-TOTAL       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-QTD-DIAS-VIGENCIA       PIC S9(9) USAGE COMP.*/
        public IntBasis LT028_QTD_DIAS_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LT028-VLR-PREMIO-LIQ-PRIM-PARC       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_PREMIO_LIQ_PRIM_PARC { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-ADICIONAL-PRIM-PARC       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_ADICIONAL_PRIM_PARC { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-PREMIO-LIQ-DEM-PARC       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_PREMIO_LIQ_DEM_PARC { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT028-VLR-ADICIONAL-DEM-PARC       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT028_VLR_ADICIONAL_DEM_PARC { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"*/
    }
}