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
    public class LBFCT000_REGISTRO_ENDOSSOS : VarBasis
    {
        /*"     10  R0-TIPO-IDE-ENDOSSO         PIC  X(001)*/
        public StringBasis R0_TIPO_IDE_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R0-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R0_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R0-VAL-DIF-ENDOSSO          PIC  9(015)V99*/
        public DoubleBasis R0_VAL_DIF_ENDOSSO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
        /*"     10  R0-SINAL-ENDOSSO            PIC  X(001)*/
        public StringBasis R0_SINAL_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R0-DATA-EMISSAO-ENDOSSO     PIC  9(008)*/
        public IntBasis R0_DATA_EMISSAO_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  FILLER                      PIC  X(059)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "59", "X(059)"), @"");
        /*"*/
    }
}