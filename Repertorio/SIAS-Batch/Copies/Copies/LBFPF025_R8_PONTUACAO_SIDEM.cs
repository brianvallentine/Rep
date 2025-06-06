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
    public class LBFPF025_R8_PONTUACAO_SIDEM : VarBasis
    {
        /*"    10 R8-IDENTIFICACAO               PIC  9(001)*/
        public IntBasis R8_IDENTIFICACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"    10 R8-NUM-PROPOSTA                PIC  9(014)*/
        public IntBasis R8_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"    10 R8-NUM-PARCELA                 PIC  9(008)*/
        public IntBasis R8_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    10 R8-TP-LANCAMENTO               PIC  9(003)*/
        public IntBasis R8_TP_LANCAMENTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"    10 R8-VLR-LANCAMENTO              PIC  9(011)V99*/
        public DoubleBasis R8_VLR_LANCAMENTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
        /*"    10 R8-VLR-ESTOQUE                 PIC  9(011)V99*/
        public DoubleBasis R8_VLR_ESTOQUE { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
        /*"    10 R8-DATA-MOVIMENTO              PIC  X(010)*/
        public StringBasis R8_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"    10 FILLER                         PIC  X(038)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
    }
}