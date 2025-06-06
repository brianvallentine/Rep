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
    public class SIREFAEV_DCLSI_REL_FASE_EVENTO : VarBasis
    {
        /*"    10 SIREFAEV-COD-FASE    PIC S9(4) USAGE COMP.*/
        public IntBasis SIREFAEV_COD_FASE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIREFAEV-COD-EVENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIREFAEV_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIREFAEV-DATA-INIVIG-REFAEV  PIC X(10).*/
        public StringBasis SIREFAEV_DATA_INIVIG_REFAEV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIREFAEV-DATA-TERVIG-REFAEV  PIC X(10).*/
        public StringBasis SIREFAEV_DATA_TERVIG_REFAEV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIREFAEV-IND-ALTERACAO-FASE  PIC X(1).*/
        public StringBasis SIREFAEV_IND_ALTERACAO_FASE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIREFAEV-COD-USUARIO  PIC X(8).*/
        public StringBasis SIREFAEV_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIREFAEV-TIMESTAMP   PIC X(26).*/
        public StringBasis SIREFAEV_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SIREFAEV-SITUACAO-REFAEV  PIC X(1).*/
        public StringBasis SIREFAEV_SITUACAO_REFAEV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}