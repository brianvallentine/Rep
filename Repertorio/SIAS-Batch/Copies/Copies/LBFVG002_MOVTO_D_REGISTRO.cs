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
    public class LBFVG002_MOVTO_D_REGISTRO : VarBasis
    {
        /*"    10      MOVTO-D-TIPO-REG     PIC  X(001)*/
        public StringBasis MOVTO_D_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    10      MOVTO-D-DTH-GERACAO*/
        public LBFVG002_MOVTO_D_DTH_GERACAO MOVTO_D_DTH_GERACAO { get; set; } = new LBFVG002_MOVTO_D_DTH_GERACAO();

        public IntBasis MOVTO_D_DTH_REFER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    10      MOVTO-D-NUM-SEQ      PIC  9(006)*/
        public IntBasis MOVTO_D_NUM_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    10      MOVTO-D-COD-OPER     PIC  X(001)*/
        public StringBasis MOVTO_D_COD_OPER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    10      MOVTO-D-DTH-OPERACAO*/
        public LBFVG002_MOVTO_D_DTH_OPERACAO MOVTO_D_DTH_OPERACAO { get; set; } = new LBFVG002_MOVTO_D_DTH_OPERACAO();

        public StringBasis MOVTO_D_IND_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    10      MOVTO-D-PRINCIPAL*/
        public LBFVG002_MOVTO_D_PRINCIPAL MOVTO_D_PRINCIPAL { get; set; } = new LBFVG002_MOVTO_D_PRINCIPAL();

    }
}