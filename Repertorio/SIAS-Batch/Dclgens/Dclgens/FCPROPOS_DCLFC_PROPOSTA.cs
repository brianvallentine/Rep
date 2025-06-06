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
    public class FCPROPOS_DCLFC_PROPOSTA : VarBasis
    {
        /*"    10 FCPROPOS-NUM-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis FCPROPOS_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPROPOS-NUM-PROPOSTA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FCPROPOS_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FCPROPOS-NUM-NSA     PIC S9(9) USAGE COMP.*/
        public IntBasis FCPROPOS_NUM_NSA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPROPOS-VLR-PROPOSTA       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCPROPOS_VLR_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCPROPOS-COD-TIPO-PAGTO       PIC X(3).*/
        public StringBasis FCPROPOS_COD_TIPO_PAGTO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPROPOS-STA-PROPOSTA       PIC X(3).*/
        public StringBasis FCPROPOS_STA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPROPOS-DTH-PROPOSTA       PIC X(10).*/
        public StringBasis FCPROPOS_DTH_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCPROPOS-PCT-DESCONTO       PIC S9(8)V9(4) USAGE COMP-3.*/
        public DoubleBasis FCPROPOS_PCT_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(4)"), 4);
        /*"    10 FCPROPOS-NUM-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPROPOS_NUM_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPROPOS-NUM-NSR     PIC S9(9) USAGE COMP.*/
        public IntBasis FCPROPOS_NUM_NSR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPROPOS-IDE-CONTA-BANCARIA       PIC S9(9) USAGE COMP.*/
        public IntBasis FCPROPOS_IDE_CONTA_BANCARIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPROPOS-NUM-MATRICULA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FCPROPOS_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FCPROPOS-IDE-USUARIO       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPROPOS_IDE_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPROPOS-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPROPOS_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPROPOS-IDE-SUBSCRITOR       PIC S9(9) USAGE COMP.*/
        public IntBasis FCPROPOS_IDE_SUBSCRITOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPROPOS-IDE-ENDERECO-SUBS       PIC S9(9) USAGE COMP.*/
        public IntBasis FCPROPOS_IDE_ENDERECO_SUBS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPROPOS-IND-DIA-VENCTO       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPROPOS_IND_DIA_VENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPROPOS-COD-BOL-DESCT-RESG       PIC X(1).*/
        public StringBasis FCPROPOS_COD_BOL_DESCT_RESG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPROPOS-COD-TIPO-PROPOSTA       PIC X(3).*/
        public StringBasis FCPROPOS_COD_TIPO_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPROPOS-IND-ENVIO-SIGPF       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPROPOS_IND_ENVIO_SIGPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPROPOS-COD-UNIDADE       PIC S9(9) USAGE COMP.*/
        public IntBasis FCPROPOS_COD_UNIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPROPOS-COD-RAMO    PIC S9(4) USAGE COMP.*/
        public IntBasis FCPROPOS_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPROPOS-NUM-MOD-PLANO       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPROPOS_NUM_MOD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPROPOS-NUM-RESPOSTA       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPROPOS_NUM_RESPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPROPOS-COD-CANAL-VENDA       PIC X(3).*/
        public StringBasis FCPROPOS_COD_CANAL_VENDA { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPROPOS-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis FCPROPOS_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 FCPROPOS-SEQ-CAMPANHA       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPROPOS_SEQ_CAMPANHA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPROPOS-COD-PARCEIRO       PIC S9(9) USAGE COMP.*/
        public IntBasis FCPROPOS_COD_PARCEIRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPROPOS-COD-FORMA-COBRANCA       PIC X(2).*/
        public StringBasis FCPROPOS_COD_FORMA_COBRANCA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}