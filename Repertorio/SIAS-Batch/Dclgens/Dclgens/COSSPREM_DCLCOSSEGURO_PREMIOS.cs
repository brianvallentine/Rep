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
    public class COSSPREM_DCLCOSSEGURO_PREMIOS : VarBasis
    {
        /*"    10 COSSPREM-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis COSSPREM_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COSSPREM-TIPO-SEGURO  PIC X(1).*/
        public StringBasis COSSPREM_TIPO_SEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COSSPREM-COD-CONGENERE  PIC S9(4) USAGE COMP.*/
        public IntBasis COSSPREM_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COSSPREM-NUM-ORDEM   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis COSSPREM_NUM_ORDEM { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COSSPREM-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis COSSPREM_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 COSSPREM-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis COSSPREM_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COSSPREM-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis COSSPREM_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COSSPREM-PRM-TARIFARIO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis COSSPREM_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 COSSPREM-VAL-DESCONTO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis COSSPREM_VAL_DESCONTO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 COSSPREM-PRM-LIQUIDO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis COSSPREM_PRM_LIQUIDO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 COSSPREM-ADIC-FRACIO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis COSSPREM_ADIC_FRACIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 COSSPREM-VAL-COMISSAO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis COSSPREM_VAL_COMISSAO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 COSSPREM-PRM-TOTAL-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis COSSPREM_PRM_TOTAL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 COSSPREM-SIT-REGISTRO  PIC X(1).*/
        public StringBasis COSSPREM_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COSSPREM-SIT-CONGENERE  PIC X(1).*/
        public StringBasis COSSPREM_SIT_CONGENERE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COSSPREM-TIMESTAMP   PIC X(26).*/
        public StringBasis COSSPREM_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 COSSPREM-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis COSSPREM_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
    }
}