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
    public class LBFVG003_MOVTO_T_REGISTRO : VarBasis
    {
        /*"    10      MOVTO-T-TIPO-REG     PIC  X(001)*/
        public StringBasis MOVTO_T_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    10      MOVTO-T-DATA-GERACAO*/
        public LBFVG003_MOVTO_T_DATA_GERACAO MOVTO_T_DATA_GERACAO { get; set; } = new LBFVG003_MOVTO_T_DATA_GERACAO();

        public IntBasis MOVTO_T_DATA_REFER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    10      MOVTO-T-NUM-SEQ      PIC  9(006)*/
        public IntBasis MOVTO_T_NUM_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    10      MOVTO-T-TOT-DETALHE  PIC  9(006)*/
        public IntBasis MOVTO_T_TOT_DETALHE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    10      MOVTO-T-TOT-VALOR    PIC  9(013)V99*/
        public DoubleBasis MOVTO_T_TOT_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"    10      FILLER               PIC  X(456)*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "456", "X(456)"), @"");
    }
}