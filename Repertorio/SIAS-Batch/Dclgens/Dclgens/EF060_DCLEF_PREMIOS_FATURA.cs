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
    public class EF060_DCLEF_PREMIOS_FATURA : VarBasis
    {
        /*"    10 EF060-NUM-CONTRATO-SEGUR       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF060_NUM_CONTRATO_SEGUR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF060-NUM-CONTRATO-APOL       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF060_NUM_CONTRATO_APOL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF060-SEQ-OPERACAO-FATUR       PIC S9(4) USAGE COMP.*/
        public IntBasis EF060_SEQ_OPERACAO_FATUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF060-SEQ-PREMIO     PIC S9(9) USAGE COMP.*/
        public IntBasis EF060_SEQ_PREMIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF060-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis EF060_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}