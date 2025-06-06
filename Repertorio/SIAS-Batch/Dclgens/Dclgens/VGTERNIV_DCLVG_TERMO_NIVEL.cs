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
    public class VGTERNIV_DCLVG_TERMO_NIVEL : VarBasis
    {
        /*"    10 VGTERNIV-NUM-PROPOSTA-SIVPF  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VGTERNIV_NUM_PROPOSTA_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VGTERNIV-DTH-INI-VIGENCIA  PIC X(10).*/
        public StringBasis VGTERNIV_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGTERNIV-NUM-NIVEL-CARGO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGTERNIV_NUM_NIVEL_CARGO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGTERNIV-DTH-FIM-VIGENCIA  PIC X(10).*/
        public StringBasis VGTERNIV_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGTERNIV-IMP-SEGURADA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGTERNIV_IMP_SEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGTERNIV-VLR-PRM-INDIVIDUAL  PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis VGTERNIV_VLR_PRM_INDIVIDUAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGTERNIV-COD-USUARIO  PIC X(8).*/
        public StringBasis VGTERNIV_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VGTERNIV-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis VGTERNIV_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VGTERNIV-QTD-VIDAS   PIC S9(4) USAGE COMP.*/
        public IntBasis VGTERNIV_QTD_VIDAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}