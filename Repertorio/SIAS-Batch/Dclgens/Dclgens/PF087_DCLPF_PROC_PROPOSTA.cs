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
    public class PF087_DCLPF_PROC_PROPOSTA : VarBasis
    {
        /*"    10 PF087-SIGLA-ARQUIVO  PIC X(8).*/
        public StringBasis PF087_SIGLA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PF087-SISTEMA-ORIGEM       PIC S9(4) USAGE COMP.*/
        public IntBasis PF087_SISTEMA_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PF087-NSAS-SIVPF     PIC S9(9) USAGE COMP.*/
        public IntBasis PF087_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PF087-NUM-PROPOSTA   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PF087_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PF087-SEQ-OCORRENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis PF087_SEQ_OCORRENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PF087-NUM-DET-ARQ-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis PF087_NUM_DET_ARQ_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PF087-NUM-ERRO-PROPOSTA       PIC S9(4) USAGE COMP.*/
        public IntBasis PF087_NUM_ERRO_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PF087-NUM-APOLICE-VINCULADA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PF087_NUM_APOLICE_VINCULADA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PF087-NUM-LINHA-ARQUIVO       PIC S9(9) USAGE COMP.*/
        public IntBasis PF087_NUM_LINHA_ARQUIVO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PF087-DES-CONTEUDO.*/
        public PF087_PF087_DES_CONTEUDO PF087_DES_CONTEUDO { get; set; } = new PF087_PF087_DES_CONTEUDO();

        public StringBasis PF087_STA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PF087-COD-USUARIO    PIC X(10).*/
        public StringBasis PF087_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PF087-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis PF087_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}