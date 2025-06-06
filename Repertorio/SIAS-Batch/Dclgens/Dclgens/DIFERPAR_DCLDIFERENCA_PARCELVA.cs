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
    public class DIFERPAR_DCLDIFERENCA_PARCELVA : VarBasis
    {
        /*"    10 DIFERPAR-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis DIFERPAR_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 DIFERPAR-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis DIFERPAR_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DIFERPAR-NUM-PARCELA-DIF  PIC S9(4) USAGE COMP.*/
        public IntBasis DIFERPAR_NUM_PARCELA_DIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DIFERPAR-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis DIFERPAR_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DIFERPAR-DATA-VENCIMENTO  PIC X(10).*/
        public StringBasis DIFERPAR_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 DIFERPAR-PRMDEVVG    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis DIFERPAR_PRMDEVVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 DIFERPAR-PRMDEVAP    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis DIFERPAR_PRMDEVAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 DIFERPAR-PRMPAGVG    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis DIFERPAR_PRMPAGVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 DIFERPAR-PRMPAGAP    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis DIFERPAR_PRMPAGAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 DIFERPAR-PRMDIFVG    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis DIFERPAR_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 DIFERPAR-PRMDIFAP    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis DIFERPAR_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 DIFERPAR-VAL-MULTA   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis DIFERPAR_VAL_MULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 DIFERPAR-SITUACAO    PIC X(1).*/
        public StringBasis DIFERPAR_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
    }
}