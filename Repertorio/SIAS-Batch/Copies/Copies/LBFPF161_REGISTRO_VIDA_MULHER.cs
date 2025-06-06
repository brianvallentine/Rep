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
    public class LBFPF161_REGISTRO_VIDA_MULHER : VarBasis
    {
        /*"  10   R6-TIPO-REG                     PIC  X(001)*/
        public StringBasis R6_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"  10   R6-NUM-PROPOSTA                 PIC  9(014)*/
        public IntBasis R6_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"  10   R6-TIPO-INFORMACAO              PIC  9(002)*/
        public IntBasis R6_TIPO_INFORMACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"  10   R6-DPS-TITULAR                  PIC  X(026)*/
        public StringBasis R6_DPS_TITULAR { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"  10   R6-DPS-CONJUGE                  PIC  X(026)*/
        public StringBasis R6_DPS_CONJUGE { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"  10   R6-INFORMACOES-DO-MEDICO        PIC  X(100)*/
        public StringBasis R6_INFORMACOES_DO_MEDICO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"  10   FILLER                          PIC  X(131)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "131", "X(131)"), @"");
        /*"*/
    }
}