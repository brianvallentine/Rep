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
    public class SX118_DCLSX_APOL_COSSEGURO : VarBasis
    {
        /*"    10 SX118-SEQ-APOLICE    PIC S9(9) USAGE COMP.*/
        public IntBasis SX118_SEQ_APOLICE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SX118-NUM-RAMO       PIC S9(4) USAGE COMP.*/
        public IntBasis SX118_NUM_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX118-NUM-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis SX118_NUM_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX118-COD-CONGENERE  PIC S9(4) USAGE COMP.*/
        public IntBasis SX118_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX118-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis SX118_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SX118-PCT-COMISSAO   PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SX118_PCT_COMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SX118-PCT-PARTICIPACAO       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis SX118_PCT_PARTICIPACAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 SX118-IND-LIDER      PIC X(1).*/
        public StringBasis SX118_IND_LIDER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX118-COD-SUSEP      PIC X(25).*/
        public StringBasis SX118_COD_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 SX118-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis SX118_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}