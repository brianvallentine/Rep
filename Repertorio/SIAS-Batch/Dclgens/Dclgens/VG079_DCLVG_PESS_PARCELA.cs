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
    public class VG079_DCLVG_PESS_PARCELA : VarBasis
    {
        /*"    10 VG079-NUM-OCORR-MOVTO  PIC S9(9) USAGE COMP.*/
        public IntBasis VG079_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG079-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VG079_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VG079-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis VG079_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG079-NUM-TITULO     PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VG079_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"*/
    }
}