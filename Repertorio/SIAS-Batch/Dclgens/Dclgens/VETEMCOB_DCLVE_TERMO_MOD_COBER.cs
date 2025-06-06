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
    public class VETEMCOB_DCLVE_TERMO_MOD_COBER : VarBasis
    {
        /*"    10 VETEMCOB-NUM-TERMO   PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis VETEMCOB_NUM_TERMO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 VETEMCOB-COD-MODULO  PIC S9(4) USAGE COMP.*/
        public IntBasis VETEMCOB_COD_MODULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VETEMCOB-COD-COBER-EMP  PIC S9(4) USAGE COMP.*/
        public IntBasis VETEMCOB_COD_COBER_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VETEMCOB-IMP-SEGURADA-EMP  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VETEMCOB_IMP_SEGURADA_EMP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VETEMCOB-VAL-PREMIO-EMP  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VETEMCOB_VAL_PREMIO_EMP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}