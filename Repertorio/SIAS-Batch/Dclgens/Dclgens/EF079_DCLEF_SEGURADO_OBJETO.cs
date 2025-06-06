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
    public class EF079_DCLEF_SEGURADO_OBJETO : VarBasis
    {
        /*"    10 EF079-NUM-CONTRATO-SEGUR  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF079_NUM_CONTRATO_SEGUR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF079-SEQ-TIPO-OBJ-SEG  PIC S9(4) USAGE COMP.*/
        public IntBasis EF079_SEQ_TIPO_OBJ_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF079-COD-TIPO-OBJ-SEG  PIC S9(4) USAGE COMP.*/
        public IntBasis EF079_COD_TIPO_OBJ_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF079-COD-PESSOA-CONTRTE  PIC S9(9) USAGE COMP.*/
        public IntBasis EF079_COD_PESSOA_CONTRTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF079-SEQ-SEGURADO-ESTIP  PIC S9(4) USAGE COMP.*/
        public IntBasis EF079_SEQ_SEGURADO_ESTIP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF079-STA-TITULAR    PIC X(1).*/
        public StringBasis EF079_STA_TITULAR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF079-PCT-COMPROM-RENDA  PIC S9(4)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF079_PCT_COMPROM_RENDA { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(2)"), 2);
        /*"    10 EF079-PCT-RENDA-PACTUADA  PIC S9(4)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF079_PCT_RENDA_PACTUADA { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(2)"), 2);
        /*"*/
    }
}