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
    public class V1MOEDA_DCLV1MOEDA : VarBasis
    {
        /*"    10 V1MOEDA-CODUNIMO     PIC S9(4) USAGE COMP.*/
        public IntBasis V1MOEDA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1MOEDA-NOMEUNIM     PIC X(20).*/
        public StringBasis V1MOEDA_NOMEUNIM { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 V1MOEDA-VALCPR       PIC S9(6)V9(9) USAGE COMP-3.*/
        public DoubleBasis V1MOEDA_VALCPR { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(6)V9(9)"), 9);
        /*"    10 V1MOEDA-VLCRUZAD     PIC S9(6)V9(9) USAGE COMP-3.*/
        public DoubleBasis V1MOEDA_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(6)V9(9)"), 9);
        /*"    10 V1MOEDA-DTINIVIG     PIC X(10).*/
        public StringBasis V1MOEDA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 V1MOEDA-DTTERVIG     PIC X(10).*/
        public StringBasis V1MOEDA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 V1MOEDA-SIGLUNIM     PIC X(6).*/
        public StringBasis V1MOEDA_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(6)."), @"");
        /*"    10 V1MOEDA-TIPO-MOEDA   PIC X(1).*/
        public StringBasis V1MOEDA_TIPO_MOEDA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1MOEDA-SITUACAO     PIC X(1).*/
        public StringBasis V1MOEDA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}