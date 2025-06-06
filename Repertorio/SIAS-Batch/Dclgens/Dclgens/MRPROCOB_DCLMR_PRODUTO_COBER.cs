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
    public class MRPROCOB_DCLMR_PRODUTO_COBER : VarBasis
    {
        /*"    10 MRPROCOB-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROCOB_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROCOB-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis MRPROCOB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRPROCOB-NUM-VERSAO  PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROCOB_NUM_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROCOB-RAMO-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROCOB_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROCOB-MODALI-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROCOB_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROCOB-COD-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROCOB_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROCOB-COD-TP-COBERTURA       PIC X(1).*/
        public StringBasis MRPROCOB_COD_TP_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MRPROCOB-STA-PRODUTO-COBER       PIC X(1).*/
        public StringBasis MRPROCOB_STA_PRODUTO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MRPROCOB-COD-USUARIO       PIC X(8).*/
        public StringBasis MRPROCOB_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 MRPROCOB-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis MRPROCOB_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MRPROCOB-IND-RESSEGURO       PIC X(1).*/
        public StringBasis MRPROCOB_IND_RESSEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MRPROCOB-IND-CESSAO  PIC X(1).*/
        public StringBasis MRPROCOB_IND_CESSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}