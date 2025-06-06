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
    public class SI155_DCLSI_MOV_HABIT_PAR : VarBasis
    {
        /*"    10 SI155-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SI155_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SI155-NUM-CONTRATO-ATU  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SI155_NUM_CONTRATO_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SI155-NUM-COTA       PIC S9(4) USAGE COMP.*/
        public IntBasis SI155_NUM_COTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI155-NUM-MES-REF-PAGTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SI155_NUM_MES_REF_PAGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI155-NUM-ANO-REF-PAGTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SI155_NUM_ANO_REF_PAGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI155-IND-TP-INDENIZACAO  PIC X(2).*/
        public StringBasis SI155_IND_TP_INDENIZACAO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SI155-NOM-ARQUIVO    PIC X(8).*/
        public StringBasis SI155_NOM_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SI155-SEQ-GERACAO    PIC S9(9) USAGE COMP.*/
        public IntBasis SI155_SEQ_GERACAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SI155-NUM-CONTRATO-ANT  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SI155_NUM_CONTRATO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SI155-NUM-PRAZO-VIGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis SI155_NUM_PRAZO_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI155-DTH-OCORRENCIA  PIC X(10).*/
        public StringBasis SI155_DTH_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI155-DTH-VENCIM-COTA  PIC X(10).*/
        public StringBasis SI155_DTH_VENCIM_COTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI155-DTH-INDENIZACAO  PIC X(10).*/
        public StringBasis SI155_DTH_INDENIZACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI155-VLR-BASE       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SI155_VLR_BASE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SI155-VLR-JUROS      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SI155_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SI155-VLR-CORRECAO   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SI155_VLR_CORRECAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SI155-VLR-MULTA      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SI155_VLR_MULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SI155-IND-TP-PRESTACAO  PIC X(1).*/
        public StringBasis SI155_IND_TP_PRESTACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SI155-STA-PROCESSAMENTO  PIC X(1).*/
        public StringBasis SI155_STA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SI155-NOM-SEGURADO   PIC X(40).*/
        public StringBasis SI155_NOM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SI155-NUM-CPF        PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SI155_NUM_CPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SI155-PCT-RENDA-PACTUADA  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis SI155_PCT_RENDA_PACTUADA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 SI155-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis SI155_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SI155-DTH-NASCIMENTO  PIC X(10).*/
        public StringBasis SI155_DTH_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI155-DTH-LIBERACAO-PAG  PIC X(26).*/
        public StringBasis SI155_DTH_LIBERACAO_PAG { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SI155-DTH-EFETIVACAO-PAG  PIC X(26).*/
        public StringBasis SI155_DTH_EFETIVACAO_PAG { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SI155-COD-USU-LIBERACAO  PIC X(8).*/
        public StringBasis SI155_COD_USU_LIBERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SI155-COD-USU-PAGAMENTO  PIC X(8).*/
        public StringBasis SI155_COD_USU_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SI155-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SI155_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI155-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis SI155_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI155-COD-AGENCIA    PIC S9(4) USAGE COMP.*/
        public IntBasis SI155_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}