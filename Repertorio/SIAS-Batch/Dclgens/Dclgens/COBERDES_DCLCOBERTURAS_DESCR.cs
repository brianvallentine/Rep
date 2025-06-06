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
    public class COBERDES_DCLCOBERTURAS_DESCR : VarBasis
    {
        /*"    10 COBERDES-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis COBERDES_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COBERDES-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis COBERDES_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COBERDES-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis COBERDES_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COBERDES-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis COBERDES_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COBERDES-DESCR-COBERTURA  PIC X(40).*/
        public StringBasis COBERDES_DESCR_COBERTURA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 COBERDES-TIMESTAMP   PIC X(26).*/
        public StringBasis COBERDES_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 COBERDES-SEQ-COB-SIGPF  PIC S9(4) USAGE COMP.*/
        public IntBasis COBERDES_SEQ_COB_SIGPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}