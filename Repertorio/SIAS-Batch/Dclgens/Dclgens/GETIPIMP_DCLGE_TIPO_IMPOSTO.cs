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
    public class GETIPIMP_DCLGE_TIPO_IMPOSTO : VarBasis
    {
        /*"    10 GETIPIMP-COD-IMP-INTERNO  PIC S9(4) USAGE COMP.*/
        public IntBasis GETIPIMP_COD_IMP_INTERNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GETIPIMP-DATA-INIVIG-IMP  PIC X(10).*/
        public StringBasis GETIPIMP_DATA_INIVIG_IMP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GETIPIMP-DATA-TERVIG-IMP  PIC X(10).*/
        public StringBasis GETIPIMP_DATA_TERVIG_IMP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GETIPIMP-DESCRICAO-IMP  PIC X(40).*/
        public StringBasis GETIPIMP_DESCRICAO_IMP { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GETIPIMP-SIGLA-IMP   PIC X(10).*/
        public StringBasis GETIPIMP_SIGLA_IMP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GETIPIMP-IND-TIPO-IMPOSTO  PIC X(1).*/
        public StringBasis GETIPIMP_IND_TIPO_IMPOSTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GETIPIMP-COD-EXTERNO-IMP  PIC X(20).*/
        public StringBasis GETIPIMP_COD_EXTERNO_IMP { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 GETIPIMP-TIMESTAMP   PIC X(26).*/
        public StringBasis GETIPIMP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}