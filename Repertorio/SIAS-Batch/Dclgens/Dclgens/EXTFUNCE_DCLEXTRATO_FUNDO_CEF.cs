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
    public class EXTFUNCE_DCLEXTRATO_FUNDO_CEF : VarBasis
    {
        /*"    10 EXTFUNCE-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis EXTFUNCE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EXTFUNCE-NUM-MATRICULA  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EXTFUNCE_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EXTFUNCE-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis EXTFUNCE_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EXTFUNCE-COD-ESCNEG  PIC S9(4) USAGE COMP.*/
        public IntBasis EXTFUNCE_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EXTFUNCE-TIPO-FUNCIONARIO  PIC X(1).*/
        public StringBasis EXTFUNCE_TIPO_FUNCIONARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EXTFUNCE-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis EXTFUNCE_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EXTFUNCE-NRSEQ       PIC S9(9) USAGE COMP.*/
        public IntBasis EXTFUNCE_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EXTFUNCE-NUM-CHEQUE  PIC S9(9) USAGE COMP.*/
        public IntBasis EXTFUNCE_NUM_CHEQUE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EXTFUNCE-DIG-CHEQUE  PIC S9(4) USAGE COMP.*/
        public IntBasis EXTFUNCE_DIG_CHEQUE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EXTFUNCE-SITUACAO    PIC X(1).*/
        public StringBasis EXTFUNCE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EXTFUNCE-TIPO-MOVIMENTO  PIC X(1).*/
        public StringBasis EXTFUNCE_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EXTFUNCE-VAL-MOVIMENTO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis EXTFUNCE_VAL_MOVIMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 EXTFUNCE-DATA-OCORRENCIA  PIC X(10).*/
        public StringBasis EXTFUNCE_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EXTFUNCE-DESC-OCORRENCIA  PIC X(40).*/
        public StringBasis EXTFUNCE_DESC_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 EXTFUNCE-COD-USUARIO  PIC X(8).*/
        public StringBasis EXTFUNCE_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 EXTFUNCE-TIMESTAMP   PIC X(26).*/
        public StringBasis EXTFUNCE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 EXTFUNCE-SALDO-ATUAL  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis EXTFUNCE_SALDO_ATUAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
    }
}