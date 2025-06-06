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
    public class SINISCAU_DCLSINISTRO_CAUSA : VarBasis
    {
        /*"    10 SINISCAU-RAMO-EMISSOR       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAU_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAU-COD-CAUSA   PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAU_COD_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAU-DESCR-CAUSA       PIC X(40).*/
        public StringBasis SINISCAU_DESCR_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SINISCAU-SIT-REGISTRO       PIC X(1).*/
        public StringBasis SINISCAU_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISCAU-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISCAU_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISCAU-TIMESTAMP   PIC X(26).*/
        public StringBasis SINISCAU_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINISCAU-IND-CANCELAMENTO       PIC X(1).*/
        public StringBasis SINISCAU_IND_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISCAU-GRUPO-CAUSAS       PIC X(20).*/
        public StringBasis SINISCAU_GRUPO_CAUSAS { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 SINISCAU-COD-GRUPO-CAUSA       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAU_COD_GRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAU-COD-SUBGRUPO-CAUSA       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAU_COD_SUBGRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAU-COD-CAUSA-SUSEP       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAU_COD_CAUSA_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}