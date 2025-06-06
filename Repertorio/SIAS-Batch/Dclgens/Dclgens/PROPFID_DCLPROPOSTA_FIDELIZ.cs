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
    public class PROPFID_DCLPROPOSTA_FIDELIZ : VarBasis
    {
        /*"    10 NUM-PROPOSTA-SIVPF   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_PROPOSTA_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 NUM-IDENTIFICACAO    PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_IDENTIFICACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COD-EMPRESA-SIVPF    PIC S9(4) USAGE COMP.*/
        public IntBasis COD_EMPRESA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-PESSOA           PIC S9(9) USAGE COMP.*/
        public IntBasis COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-SICOB            PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_SICOB { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 DATA-PROPOSTA        PIC X(10).*/
        public StringBasis DATA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COD-PRODUTO-SIVPF    PIC S9(4) USAGE COMP.*/
        public IntBasis COD_PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGECOBR              PIC S9(4) USAGE COMP.*/
        public IntBasis AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DIA-DEBITO           PIC S9(4) USAGE COMP.*/
        public IntBasis DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPCAOPAG             PIC X(1).*/
        public StringBasis OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AGECTADEB            PIC S9(4) USAGE COMP.*/
        public IntBasis AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPRCTADEB            PIC S9(4) USAGE COMP.*/
        public IntBasis OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUMCTADEB            PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUMCTADEB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 DIGCTADEB            PIC S9(4) USAGE COMP.*/
        public IntBasis DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PERC-DESCONTO        PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PERC_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 NRMATRVEN            PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NRMATRVEN { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 AGECTAVEN            PIC S9(4) USAGE COMP.*/
        public IntBasis AGECTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPRCTAVEN            PIC S9(4) USAGE COMP.*/
        public IntBasis OPRCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUMCTAVEN            PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUMCTAVEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 DIGCTAVEN            PIC S9(4) USAGE COMP.*/
        public IntBasis DIGCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CGC-CONVENENTE       PIC S9(14)V USAGE COMP-3.*/
        public DoubleBasis CGC_CONVENENTE { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V"), 0);
        /*"    10 NOME-CONVENENTE      PIC X(40).*/
        public StringBasis NOME_CONVENENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 NRMATRCON            PIC S9(9) USAGE COMP.*/
        public IntBasis NRMATRCON { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 DTQITBCO             PIC X(10).*/
        public StringBasis DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VAL-PAGO             PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AGEPGTO              PIC S9(4) USAGE COMP.*/
        public IntBasis AGEPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VAL-TARIFA           PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VAL-IOF              PIC S9(4)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_IOF { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(2)"), 2);
        /*"    10 DATA-CREDITO         PIC X(10).*/
        public StringBasis DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VAL-COMISSAO         PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_COMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIT-PROPOSTA         PIC X(3).*/
        public StringBasis SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 COD-USUARIO          PIC X(8).*/
        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 CANAL-PROPOSTA       PIC S9(4) USAGE COMP.*/
        public IntBasis CANAL_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NSAS-SIVPF           PIC S9(9) USAGE COMP.*/
        public IntBasis NSAS_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ORIGEM-PROPOSTA      PIC S9(4) USAGE COMP.*/
        public IntBasis ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 NSL                  PIC S9(9) USAGE COMP.*/
        public IntBasis NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NSAC-SIVPF           PIC S9(9) USAGE COMP.*/
        public IntBasis NSAC_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SITUACAO-ENVIO       PIC X(1).*/
        public StringBasis SITUACAO_ENVIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OPCAO-COBER          PIC X(1).*/
        public StringBasis OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-PLANO            PIC S9(4) USAGE COMP.*/
        public IntBasis COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NOME-CONJUGE         PIC X(40).*/
        public StringBasis NOME_CONJUGE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 DATA-NASC-CONJUGE    PIC X(10).*/
        public StringBasis DATA_NASC_CONJUGE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROFISSAO-CONJUGE    PIC S9(9) USAGE COMP.*/
        public IntBasis PROFISSAO_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FAIXA-RENDA-IND      PIC X(1).*/
        public StringBasis FAIXA_RENDA_IND { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FAIXA-RENDA-FAM      PIC X(1).*/
        public StringBasis FAIXA_RENDA_FAM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 IND-TP-PROPOSTA      PIC X(1).*/
        public StringBasis IND_TP_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 IND-TIPO-CONTA       PIC X(1).*/
        public StringBasis IND_TIPO_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}