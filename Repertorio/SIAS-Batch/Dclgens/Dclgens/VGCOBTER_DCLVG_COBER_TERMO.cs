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
    public class VGCOBTER_DCLVG_COBER_TERMO : VarBasis
    {
        /*"    10 VGCOBTER-NUM-PROPOSTA-SIVPF  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VGCOBTER_NUM_PROPOSTA_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VGCOBTER-DTH-INI-VIGENCIA  PIC X(10).*/
        public StringBasis VGCOBTER_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGCOBTER-COD-GARANTIA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOBTER_COD_GARANTIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOBTER-DTH-FIM-VIGENCIA  PIC X(10).*/
        public StringBasis VGCOBTER_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGCOBTER-COD-USUARIO  PIC X(8).*/
        public StringBasis VGCOBTER_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VGCOBTER-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis VGCOBTER_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}