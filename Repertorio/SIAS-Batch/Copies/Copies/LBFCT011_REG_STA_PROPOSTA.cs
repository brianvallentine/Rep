using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBFCT011_REG_STA_PROPOSTA : VarBasis
    {
        /*"     10  R1-TIPO-REG                 PIC  X(001)*/
        public StringBasis R1_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R1-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R1_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R1-SIT-PROPOSTA             PIC  X(003)*/
        public StringBasis R1_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"     10  R1-SIT-COBRANCA             PIC  X(003)*/
        public StringBasis R1_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"     10  R1-SIT-MOTIVO               PIC  9(003)*/
        public IntBasis R1_SIT_MOTIVO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"     10  R1-DATA-SITUACAO            PIC  9(008)*/
        public IntBasis R1_DATA_SITUACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  FILLER                      PIC  X(046)*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
        /*"     10  R1-NSAS                     PIC  9(006)*/
        public IntBasis R1_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"     10  R1-NSL                      PIC  9(006)*/
        public IntBasis R1_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"     10  FILLER                      PIC  X(010)*/
        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01      REG-TRAILLER-STA*/
    }
}