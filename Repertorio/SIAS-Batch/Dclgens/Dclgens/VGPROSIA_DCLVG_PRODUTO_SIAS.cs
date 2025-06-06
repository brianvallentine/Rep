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
    public class VGPROSIA_DCLVG_PRODUTO_SIAS : VarBasis
    {
        /*"    10 VGPROSIA-COD-PRODUTO-EMP  PIC S9(4) USAGE COMP.*/
        public IntBasis VGPROSIA_COD_PRODUTO_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGPROSIA-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGPROSIA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGPROSIA-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VGPROSIA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VGPROSIA-NUM-PERIODO-PAG  PIC S9(4) USAGE COMP.*/
        public IntBasis VGPROSIA_NUM_PERIODO_PAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGPROSIA-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis VGPROSIA_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}