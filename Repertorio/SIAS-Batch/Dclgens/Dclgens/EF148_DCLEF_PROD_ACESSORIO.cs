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
    public class EF148_DCLEF_PROD_ACESSORIO : VarBasis
    {
        /*"    10 EF148-NUM-CONTRATO-APOL       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF148_NUM_CONTRATO_APOL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF148-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis EF148_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF148-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis EF148_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF148-DTH-INI-VIGENCIA       PIC X(10).*/
        public StringBasis EF148_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF148-NUM-RAMO-CONTABIL       PIC S9(4) USAGE COMP.*/
        public IntBasis EF148_NUM_RAMO_CONTABIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF148-COD-PRODUTO-ACESS       PIC S9(4) USAGE COMP.*/
        public IntBasis EF148_COD_PRODUTO_ACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF148-COD-COBERTURA-ACESS       PIC S9(4) USAGE COMP.*/
        public IntBasis EF148_COD_COBERTURA_ACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF148-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis EF148_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 EF148-DTH-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis EF148_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF148-PCT-PREMIO-ACESS       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis EF148_PCT_PREMIO_ACESS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
    }
}