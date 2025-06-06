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
    public class VG086_DCLVG_FAIXA_CAP_SEGUR : VarBasis
    {
        /*"    10 VG086-SEQ-FAIXA-CAP-SEGUR       PIC S9(4) USAGE COMP.*/
        public IntBasis VG086_SEQ_FAIXA_CAP_SEGUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG086-VLR-FAIXA-CS-INICIAL       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG086_VLR_FAIXA_CS_INICIAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 VG086-VLR-FAIXA-CS-FINAL       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG086_VLR_FAIXA_CS_FINAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 VG086-COD-USUARIO    PIC X(10).*/
        public StringBasis VG086_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG086-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG086_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}