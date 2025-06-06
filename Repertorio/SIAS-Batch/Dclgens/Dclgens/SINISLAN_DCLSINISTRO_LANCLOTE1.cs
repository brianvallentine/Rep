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
    public class SINISLAN_DCLSINISTRO_LANCLOTE1 : VarBasis
    {
        /*"    10 SINISLAN-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SINISLAN_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISLAN-NUM-LOTE    PIC S9(9) USAGE COMP.*/
        public IntBasis SINISLAN_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISLAN-NUM-APOL-SINISTRO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINISLAN_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINISLAN-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISLAN_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISLAN-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISLAN_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISLAN-VAL-OPERACAO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINISLAN_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINISLAN-DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis SINISLAN_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISLAN-COD-USUARIO       PIC X(8).*/
        public StringBasis SINISLAN_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SINISLAN-TIMESTAMP   PIC X(26).*/
        public StringBasis SINISLAN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINISLAN-COD-PROCESSO-JURID       PIC X(15).*/
        public StringBasis SINISLAN_COD_PROCESSO_JURID { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 SINISLAN-SEQ-TP-SERVICO-INSS       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISLAN_SEQ_TP_SERVICO_INSS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISLAN-SEQ-INDICATIVO-OBRA       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISLAN_SEQ_INDICATIVO_OBRA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISLAN-COD-NACIONAL-OBRA       PIC S9(18) USAGE COMP.*/
        public IntBasis SINISLAN_COD_NACIONAL_OBRA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SINISLAN-VLR-CUSTO-N-BASE-INSS       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINISLAN_VLR_CUSTO_N_BASE_INSS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINISLAN-VLR-BASE-CALCULO-INSS       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINISLAN_VLR_BASE_CALCULO_INSS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINISLAN-VLR-INSS-SUBCONTRATO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINISLAN_VLR_INSS_SUBCONTRATO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINISLAN-NOM-PROGRAMA       PIC X(10).*/
        public StringBasis SINISLAN_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}