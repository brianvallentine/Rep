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
    public class RCAPCOMP_DCLRCAP_COMPLEMENTAR : VarBasis
    {
        /*"    10 RCAPCOMP-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis RCAPCOMP_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RCAPCOMP-NUM-RCAP    PIC S9(9) USAGE COMP.*/
        public IntBasis RCAPCOMP_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RCAPCOMP-NUM-RCAP-COMPLEMEN  PIC S9(9) USAGE COMP.*/
        public IntBasis RCAPCOMP_NUM_RCAP_COMPLEMEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RCAPCOMP-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis RCAPCOMP_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RCAPCOMP-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis RCAPCOMP_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RCAPCOMP-HORA-OPERACAO  PIC X(8).*/
        public StringBasis RCAPCOMP_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 RCAPCOMP-SIT-REGISTRO  PIC X(1).*/
        public StringBasis RCAPCOMP_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RCAPCOMP-BCO-AVISO   PIC S9(4) USAGE COMP.*/
        public IntBasis RCAPCOMP_BCO_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RCAPCOMP-AGE-AVISO   PIC S9(4) USAGE COMP.*/
        public IntBasis RCAPCOMP_AGE_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RCAPCOMP-NUM-AVISO-CREDITO  PIC S9(9) USAGE COMP.*/
        public IntBasis RCAPCOMP_NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RCAPCOMP-VAL-RCAP    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RCAPCOMP_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RCAPCOMP-DATA-RCAP   PIC X(10).*/
        public StringBasis RCAPCOMP_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RCAPCOMP-DATA-CADASTRAMENTO  PIC X(10).*/
        public StringBasis RCAPCOMP_DATA_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RCAPCOMP-SIT-CONTABIL  PIC X(1).*/
        public StringBasis RCAPCOMP_SIT_CONTABIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RCAPCOMP-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis RCAPCOMP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RCAPCOMP-TIMESTAMP   PIC X(26).*/
        public StringBasis RCAPCOMP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}