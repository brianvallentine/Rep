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
    public class PROPOFID_DCLPROPOSTA_FIDELIZ : VarBasis
    {
        /*"    10 PROPOFID-NUM-PROPOSTA-SIVPF       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOFID_NUM_PROPOSTA_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOFID-NUM-IDENTIFICACAO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOFID_NUM_IDENTIFICACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOFID-COD-EMPRESA-SIVPF       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_COD_EMPRESA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-COD-PESSOA  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOFID_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOFID-NUM-SICOB   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOFID_NUM_SICOB { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOFID-DATA-PROPOSTA       PIC X(10).*/
        public StringBasis PROPOFID_DATA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOFID-COD-PRODUTO-SIVPF       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_COD_PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-AGECOBR     PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-DIA-DEBITO  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-OPCAOPAG    PIC X(1).*/
        public StringBasis PROPOFID_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOFID-AGECTADEB   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-OPRCTADEB   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-NUMCTADEB   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PROPOFID_NUMCTADEB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PROPOFID-DIGCTADEB   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-PERC-DESCONTO       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPOFID_PERC_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PROPOFID-NRMATRVEN   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOFID_NRMATRVEN { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOFID-AGECTAVEN   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_AGECTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-OPRCTAVEN   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_OPRCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-NUMCTAVEN   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PROPOFID_NUMCTAVEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PROPOFID-DIGCTAVEN   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_DIGCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-CGC-CONVENENTE       PIC S9(14)V USAGE COMP-3.*/
        public DoubleBasis PROPOFID_CGC_CONVENENTE { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V"), 0);
        /*"    10 PROPOFID-NOME-CONVENENTE       PIC X(40).*/
        public StringBasis PROPOFID_NOME_CONVENENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PROPOFID-NRMATRCON   PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOFID_NRMATRCON { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOFID-DTQITBCO    PIC X(10).*/
        public StringBasis PROPOFID_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOFID-VAL-PAGO    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPOFID_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PROPOFID-AGEPGTO     PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_AGEPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-VAL-TARIFA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPOFID_VAL_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PROPOFID-VAL-IOF     PIC S9(4)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPOFID_VAL_IOF { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(2)"), 2);
        /*"    10 PROPOFID-DATA-CREDITO       PIC X(10).*/
        public StringBasis PROPOFID_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOFID-VAL-COMISSAO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPOFID_VAL_COMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PROPOFID-SIT-PROPOSTA       PIC X(3).*/
        public StringBasis PROPOFID_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 PROPOFID-COD-USUARIO       PIC X(8).*/
        public StringBasis PROPOFID_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PROPOFID-CANAL-PROPOSTA       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_CANAL_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-NSAS-SIVPF  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOFID_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOFID-ORIGEM-PROPOSTA       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-TIMESTAMP   PIC X(26).*/
        public StringBasis PROPOFID_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PROPOFID-NSL         PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOFID_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOFID-NSAC-SIVPF  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOFID_NSAC_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOFID-SITUACAO-ENVIO       PIC X(1).*/
        public StringBasis PROPOFID_SITUACAO_ENVIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOFID-OPCAO-COBER       PIC X(1).*/
        public StringBasis PROPOFID_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOFID-COD-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOFID_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOFID-NOME-CONJUGE       PIC X(40).*/
        public StringBasis PROPOFID_NOME_CONJUGE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PROPOFID-DATA-NASC-CONJUGE       PIC X(10).*/
        public StringBasis PROPOFID_DATA_NASC_CONJUGE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOFID-PROFISSAO-CONJUGE       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOFID_PROFISSAO_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOFID-FAIXA-RENDA-IND       PIC X(1).*/
        public StringBasis PROPOFID_FAIXA_RENDA_IND { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOFID-FAIXA-RENDA-FAM       PIC X(1).*/
        public StringBasis PROPOFID_FAIXA_RENDA_FAM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOFID-IND-TP-PROPOSTA       PIC X(1).*/
        public StringBasis PROPOFID_IND_TP_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOFID-IND-TIPO-CONTA       PIC X(1).*/
        public StringBasis PROPOFID_IND_TIPO_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}