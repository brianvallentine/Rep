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
    public class EF025_DCLEF_CONTR_TERC_HAB : VarBasis
    {
        /*"    10 EF025-NOM-ARQUIVO    PIC X(8).*/
        public StringBasis EF025_NOM_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 EF025-NUM-CONTRATO-TERC       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF025_NUM_CONTRATO_TERC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF025-DTH-ASSIN-CONTRATO       PIC X(10).*/
        public StringBasis EF025_DTH_ASSIN_CONTRATO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF025-PCT-TAXA-JUROS       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis EF025_PCT_TAXA_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 EF025-QTD-MESES-CONTRATO       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_QTD_MESES_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-QTD-MESES-OBRA       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_QTD_MESES_OBRA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-IND-TIPO-GARANTIA       PIC X(1).*/
        public StringBasis EF025_IND_TIPO_GARANTIA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF025-DTH-FIM-CONTRATO       PIC X(10).*/
        public StringBasis EF025_DTH_FIM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF025-NUM-LINHA-FINANC       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_NUM_LINHA_FINANC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-NUM-TIPO-FINANC       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_NUM_TIPO_FINANC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-NUM-MATRIC-AGENTE       PIC S9(9) USAGE COMP.*/
        public IntBasis EF025_NUM_MATRIC_AGENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF025-COD-UNID-OPER  PIC S9(9) USAGE COMP.*/
        public IntBasis EF025_COD_UNID_OPER { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF025-COD-ORIGEM-REC       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_COD_ORIGEM_REC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-NUM-LEGISLACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_NUM_LEGISLACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-NUM-GRUPO-HAB  PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_NUM_GRUPO_HAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-NUM-CRITERIO-EXCEP       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_NUM_CRITERIO_EXCEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-COD-RGE        PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_COD_RGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-DTH-INI-AMORTIZ       PIC X(10).*/
        public StringBasis EF025_DTH_INI_AMORTIZ { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF025-NUM-MES-ANO-RECALC       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_NUM_MES_ANO_RECALC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-PCT-CES        PIC S9(9) USAGE COMP.*/
        public IntBasis EF025_PCT_CES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF025-COD-PLANO-SFH  PIC X(7).*/
        public StringBasis EF025_COD_PLANO_SFH { get; set; } = new StringBasis(new PIC("X", "7", "X(7)."), @"");
        /*"    10 EF025-COD-ESPECIAL-SFH       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_COD_ESPECIAL_SFH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-COD-SINOPSE-SFH       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_COD_SINOPSE_SFH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-COD-OPERACAO-SFH       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_COD_OPERACAO_SFH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-COD-CATEG-PROF-SFH       PIC S9(9) USAGE COMP.*/
        public IntBasis EF025_COD_CATEG_PROF_SFH { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF025-COD-CLASSE-FINANC       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_COD_CLASSE_FINANC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-IND-COBERT-FCVS       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_IND_COBERT_FCVS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-IND-OPER-LASTREADA       PIC S9(4) USAGE COMP.*/
        public IntBasis EF025_IND_OPER_LASTREADA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF025-VLR-CESH       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis EF025_VLR_CESH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 EF025-NUM-CCA        PIC S9(9) USAGE COMP.*/
        public IntBasis EF025_NUM_CCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF025-NUM-PONTO-VENDA-CCA       PIC S9(9) USAGE COMP.*/
        public IntBasis EF025_NUM_PONTO_VENDA_CCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF025-NUM-INDICADOR-CCA       PIC S9(9) USAGE COMP.*/
        public IntBasis EF025_NUM_INDICADOR_CCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}