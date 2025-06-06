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
    public class VGCOMTRO_DCLVG_COMPL_TERMO : VarBasis
    {
        /*"    10 VGCOMTRO-NUM-TERMO   PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis VGCOMTRO_NUM_TERMO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 VGCOMTRO-NUM-PROPOSTA-SIVPF       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VGCOMTRO-DTH-DIA-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOMTRO_DTH_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOMTRO-COD-AGENCIA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOMTRO_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOMTRO-OPERACAO-CONTA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOMTRO_OPERACAO_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOMTRO-NUM-CONTA-DEBITO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VGCOMTRO_NUM_CONTA_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VGCOMTRO-DIG-CONTA-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOMTRO_DIG_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOMTRO-DTH-LIBERACAO       PIC X(10).*/
        public StringBasis VGCOMTRO_DTH_LIBERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGCOMTRO-NUM-CARTAO-CREDITO       PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis VGCOMTRO_NUM_CARTAO_CREDITO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"*/
    }
}