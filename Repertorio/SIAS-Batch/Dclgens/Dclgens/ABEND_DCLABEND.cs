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
    public class ABEND_DCLABEND : VarBasis
    {
        /*"    10 ABEND-TIMESTAMP      PIC X(26).*/
        public StringBasis ABEND_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 ABEND-COD-USUARIO    PIC X(8).*/
        public StringBasis ABEND_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 ABEND-COD-APLICACAO  PIC X(8).*/
        public StringBasis ABEND_COD_APLICACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 ABEND-COD-PROCESSO   PIC X(18).*/
        public StringBasis ABEND_COD_PROCESSO { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
        /*"    10 ABEND-SQLCODE        PIC S9(9) USAGE COMP.*/
        public IntBasis ABEND_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ABEND-SQLERRMC       PIC X(70).*/
        public StringBasis ABEND_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(70)."), @"");
        /*"    10 ABEND-SQLERRP        PIC X(8).*/
        public StringBasis ABEND_SQLERRP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 ABEND-SQLERRD        PIC S9(9) USAGE COMP.*/
        public IntBasis ABEND_SQLERRD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ABEND-SQLWARN        PIC X(11).*/
        public StringBasis ABEND_SQLWARN { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
        /*"    10 ABEND-SQLWARN0       PIC X(1).*/
        public StringBasis ABEND_SQLWARN0 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ABEND-SQLWARN1       PIC X(1).*/
        public StringBasis ABEND_SQLWARN1 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ABEND-SQLWARN2       PIC X(1).*/
        public StringBasis ABEND_SQLWARN2 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ABEND-SQLWARN3       PIC X(1).*/
        public StringBasis ABEND_SQLWARN3 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ABEND-SQLWARN4       PIC X(1).*/
        public StringBasis ABEND_SQLWARN4 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ABEND-SQLWARN5       PIC X(1).*/
        public StringBasis ABEND_SQLWARN5 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ABEND-SQLWARN6       PIC X(1).*/
        public StringBasis ABEND_SQLWARN6 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ABEND-SQLWARN7       PIC X(1).*/
        public StringBasis ABEND_SQLWARN7 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ABEND-SQLWARN8       PIC X(1).*/
        public StringBasis ABEND_SQLWARN8 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ABEND-SQLWARN9       PIC X(1).*/
        public StringBasis ABEND_SQLWARN9 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ABEND-SQLWARNA       PIC X(1).*/
        public StringBasis ABEND_SQLWARNA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ABEND-SQLEXT         PIC X(5).*/
        public StringBasis ABEND_SQLEXT { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 ABEND-COD-EMPRESA    PIC S9(9) USAGE COMP.*/
        public IntBasis ABEND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}