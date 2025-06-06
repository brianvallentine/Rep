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
    public class PF090_DCLPF_PROC_PROPOSTA_HIST : VarBasis
    {
        /*"    10 PF090-SIGLA-ARQUIVO  PIC X(8).*/
        public StringBasis PF090_SIGLA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PF090-SISTEMA-ORIGEM       PIC S9(4) USAGE COMP.*/
        public IntBasis PF090_SISTEMA_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PF090-NSAS-SIVPF     PIC S9(9) USAGE COMP.*/
        public IntBasis PF090_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PF090-NUM-PROPOSTA   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PF090_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PF090-SEQ-OCORRENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis PF090_SEQ_OCORRENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PF090-SEQ-OCORR-HIST       PIC S9(4) USAGE COMP.*/
        public IntBasis PF090_SEQ_OCORR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PF090-STA-PROCESSAMENTO       PIC X(1).*/
        public StringBasis PF090_STA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PF090-COD-USUARIO    PIC X(10).*/
        public StringBasis PF090_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PF090-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis PF090_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}