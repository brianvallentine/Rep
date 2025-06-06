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
    public class CB041_DCLCB_PESS_PARCELA : VarBasis
    {
        /*"    10 CB041-NUM-OCORR-MOVTO  PIC S9(9) USAGE COMP.*/
        public IntBasis CB041_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CB041-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CB041_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CB041-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis CB041_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CB041-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis CB041_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CB041-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis CB041_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}