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
    public class SI111_DCLSI_RESSARC_PARCELA : VarBasis
    {
        /*"    10 SI111-NUM-APOL-SINISTRO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SI111_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SI111-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis SI111_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI111-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis SI111_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI111-NUM-RESSARC    PIC S9(9) USAGE COMP.*/
        public IntBasis SI111_NUM_RESSARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SI111-SEQ-RESSARC    PIC S9(4) USAGE COMP.*/
        public IntBasis SI111_SEQ_RESSARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI111-NUM-PARCELA    PIC S9(9) USAGE COMP.*/
        public IntBasis SI111_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SI111-COD-AGENCIA-CEDENT       PIC S9(4) USAGE COMP.*/
        public IntBasis SI111_COD_AGENCIA_CEDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI111-COD-SISTEMA-ORIGEM       PIC S9(4) USAGE COMP.*/
        public IntBasis SI111_COD_SISTEMA_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI111-NUM-CEDENTE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SI111_NUM_CEDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SI111-NUM-CEDENTE-DV       PIC X(1).*/
        public StringBasis SI111_NUM_CEDENTE_DV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SI111-DTH-VENCIMENTO       PIC X(10).*/
        public StringBasis SI111_DTH_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI111-NUM-NOSSO-TITULO       PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis SI111_NUM_NOSSO_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 SI111-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis SI111_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SI111-PCT-OPERACAO   PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis SI111_PCT_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"    10 SI111-IND-FORMA-BAIXA       PIC X(1).*/
        public StringBasis SI111_IND_FORMA_BAIXA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SI111-NOM-PROGRAMA   PIC X(8).*/
        public StringBasis SI111_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SI111-DTH-PAGAMENTO  PIC X(10).*/
        public StringBasis SI111_DTH_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI111-IND-INTEGRACAO       PIC X(1).*/
        public StringBasis SI111_IND_INTEGRACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SI111-NUM-TITULO-SIGCB       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis SI111_NUM_TITULO_SIGCB { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"*/
    }
}