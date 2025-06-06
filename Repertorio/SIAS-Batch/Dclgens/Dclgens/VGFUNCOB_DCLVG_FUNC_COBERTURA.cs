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
    public class VGFUNCOB_DCLVG_FUNC_COBERTURA : VarBasis
    {
        /*"    10 VGFUNCOB-NUM-PROPOSTA-SIVPF  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VGFUNCOB_NUM_PROPOSTA_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VGFUNCOB-DTH-INI-VIGENCIA  PIC X(10).*/
        public StringBasis VGFUNCOB_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGFUNCOB-NUM-CPF     PIC S9(14)V USAGE COMP-3.*/
        public DoubleBasis VGFUNCOB_NUM_CPF { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V"), 0);
        /*"    10 VGFUNCOB-COD-GARANTIA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGFUNCOB_COD_GARANTIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGFUNCOB-IMP-SEGURADA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGFUNCOB_IMP_SEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGFUNCOB-VLR-PREMIO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGFUNCOB_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGFUNCOB-VLR-TAXA-CALC-PRM  PIC S9(3)V9(7) USAGE COMP-3.*/
        public DoubleBasis VGFUNCOB_VLR_TAXA_CALC_PRM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(7)"), 7);
        /*"    10 VGFUNCOB-COD-USUARIO  PIC X(8).*/
        public StringBasis VGFUNCOB_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VGFUNCOB-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis VGFUNCOB_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}