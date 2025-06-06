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
    public class PROPOACO_DCLPROPOSTA_ACOMPANHA : VarBasis
    {
        /*"    10 PROPOACO-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOACO_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOACO-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOACO_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOACO-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOACO_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOACO-DATA-OPERACAO  PIC X(10).*/
        public StringBasis PROPOACO_DATA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOACO-HORA-OPERACAO  PIC X(8).*/
        public StringBasis PROPOACO_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PROPOACO-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOACO_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOACO-COD-USUARIO  PIC X(8).*/
        public StringBasis PROPOACO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PROPOACO-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOACO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOACO-TIMESTAMP   PIC X(26).*/
        public StringBasis PROPOACO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}