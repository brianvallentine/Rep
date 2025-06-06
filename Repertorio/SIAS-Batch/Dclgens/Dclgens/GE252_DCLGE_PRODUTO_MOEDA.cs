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
    public class GE252_DCLGE_PRODUTO_MOEDA : VarBasis
    {
        /*"    10 GE252-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis GE252_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE252-COD-MOEDA      PIC S9(4) USAGE COMP.*/
        public IntBasis GE252_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE252-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis GE252_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE252-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis GE252_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE252-COD-USUARIO    PIC X(8).*/
        public StringBasis GE252_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE252-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis GE252_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE252-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE252_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE252-PCT-JUROS      PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis GE252_PCT_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"    10 GE252-PCT-MULTA      PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis GE252_PCT_MULTA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
    }
}