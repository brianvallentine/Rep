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
    public class PARCEDEV_DCLPARCELA_DEVEDOR : VarBasis
    {
        /*"    10 PARCEDEV-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PARCEDEV_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARCEDEV-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PARCEDEV_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PARCEDEV-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis PARCEDEV_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARCEDEV-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis PARCEDEV_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCEDEV-PRM-TOTAL   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEDEV_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEDEV-VLACRESCIMO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEDEV_VLACRESCIMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEDEV-SITUACAO    PIC X(1).*/
        public StringBasis PARCEDEV_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARCEDEV-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis PARCEDEV_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARCEDEV-DATA-VENCIMENTO  PIC X(10).*/
        public StringBasis PARCEDEV_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARCEDEV-COD-USUARIO  PIC X(8).*/
        public StringBasis PARCEDEV_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PARCEDEV-TIMESTAMP   PIC X(26).*/
        public StringBasis PARCEDEV_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PARCEDEV-NUM-TITULO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PARCEDEV_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PARCEDEV-NOVO-VENCIMENTO  PIC X(10).*/
        public StringBasis PARCEDEV_NOVO_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARCEDEV-DATA-CANCEL-PREV  PIC X(10).*/
        public StringBasis PARCEDEV_DATA_CANCEL_PREV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARCEDEV-NUM-LOTE    PIC S9(4) USAGE COMP.*/
        public IntBasis PARCEDEV_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCEDEV-DTLOTE      PIC X(10).*/
        public StringBasis PARCEDEV_DTLOTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}