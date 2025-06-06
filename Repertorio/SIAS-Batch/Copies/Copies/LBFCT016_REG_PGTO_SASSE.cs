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
    public class LBFCT016_REG_PGTO_SASSE : VarBasis
    {
        /*"     10 R4-TIPO-REG                 PIC  X(001)*/
        public StringBasis R4_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10 R4-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R4_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10 R4-SIT-COBRANCA             PIC  X(003)*/
        public StringBasis R4_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"     10 R4-DATA-SITUACAO            PIC  9(008)*/
        public IntBasis R4_DATA_SITUACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10 R4-PARCELAS-PAGAS           PIC  9(003)*/
        public IntBasis R4_PARCELAS_PAGAS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"     10 R4-TOTAL-PARCELAS           PIC  9(003)*/
        public IntBasis R4_TOTAL_PARCELAS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"     10 FILLER                      PIC  X(068)*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "68", "X(068)"), @"");
        /*"*/
    }
}