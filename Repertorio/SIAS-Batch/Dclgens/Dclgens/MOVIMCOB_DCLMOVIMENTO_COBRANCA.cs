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
    public class MOVIMCOB_DCLMOVIMENTO_COBRANCA : VarBasis
    {
        /*"    10 MOVIMCOB-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis MOVIMCOB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVIMCOB-COD-MOVIMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMCOB_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMCOB-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMCOB_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMCOB-COD-AGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMCOB_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMCOB-NUM-AVISO   PIC S9(9) USAGE COMP.*/
        public IntBasis MOVIMCOB_NUM_AVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVIMCOB-NUM-FITA    PIC S9(9) USAGE COMP.*/
        public IntBasis MOVIMCOB_NUM_FITA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVIMCOB-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis MOVIMCOB_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVIMCOB-DATA-QUITACAO  PIC X(10).*/
        public StringBasis MOVIMCOB_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVIMCOB-NUM-TITULO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MOVIMCOB_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MOVIMCOB-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MOVIMCOB_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MOVIMCOB-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis MOVIMCOB_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVIMCOB-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMCOB_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMCOB-VAL-TITULO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMCOB_VAL_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMCOB-VAL-IOCC    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMCOB_VAL_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMCOB-VAL-CREDITO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMCOB_VAL_CREDITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMCOB-SIT-REGISTRO  PIC X(1).*/
        public StringBasis MOVIMCOB_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMCOB-TIMESTAMP   PIC X(26).*/
        public StringBasis MOVIMCOB_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MOVIMCOB-NOME-SEGURADO  PIC X(40).*/
        public StringBasis MOVIMCOB_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 MOVIMCOB-TIPO-MOVIMENTO  PIC X(1).*/
        public StringBasis MOVIMCOB_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMCOB-NUM-NOSSO-TITULO  PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis MOVIMCOB_NUM_NOSSO_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"*/
    }
}