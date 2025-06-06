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
    public class PF038_DCLPF_PGTO_SIVPF : VarBasis
    {
        /*"    10 PF038-NUM-TITULO-SIVPF  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PF038_NUM_TITULO_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PF038-COD-PRODUTO-SIVPF  PIC S9(4) USAGE COMP.*/
        public IntBasis PF038_COD_PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PF038-COD-AGENCIA    PIC S9(4) USAGE COMP.*/
        public IntBasis PF038_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PF038-IND-PAGAMENTO  PIC X(1).*/
        public StringBasis PF038_IND_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PF038-NUM-CGC-CPF    PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PF038_NUM_CGC_CPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PF038-NUM-PROPOSTA   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PF038_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PF038-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PF038_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PF038-NUM-PARCELA-PAGA  PIC S9(4) USAGE COMP.*/
        public IntBasis PF038_NUM_PARCELA_PAGA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PF038-DTH-QUITACAO   PIC X(10).*/
        public StringBasis PF038_DTH_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PF038-VLR-PAGO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PF038_VLR_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PF038-SIGLA-ARQUIVO  PIC X(8).*/
        public StringBasis PF038_SIGLA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PF038-SISTEMA-ORIGEM  PIC S9(4) USAGE COMP.*/
        public IntBasis PF038_SISTEMA_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PF038-NSAS-SIVPF     PIC S9(9) USAGE COMP.*/
        public IntBasis PF038_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}