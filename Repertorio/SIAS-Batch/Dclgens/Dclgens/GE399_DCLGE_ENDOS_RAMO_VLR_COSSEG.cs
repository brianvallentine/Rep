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
    public class GE399_DCLGE_ENDOS_RAMO_VLR_COSSEG : VarBasis
    {
        /*"    10 GE399-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis GE399_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 GE399-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis GE399_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE399-COD-RAMO-COBER       PIC S9(4) USAGE COMP.*/
        public IntBasis GE399_COD_RAMO_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE399-COD-COSSEGURADORA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE399_COD_COSSEGURADORA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE399-VLR-IMPSEG-CED-VAR       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE399_VLR_IMPSEG_CED_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE399-PCT-PROP-RAMO-IS       PIC S9(4)V9(9) USAGE COMP-3.*/
        public DoubleBasis GE399_PCT_PROP_RAMO_IS { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(9)"), 9);
        /*"    10 GE399-PCT-PROP-TOTAL-IS       PIC S9(4)V9(9) USAGE COMP-3.*/
        public DoubleBasis GE399_PCT_PROP_TOTAL_IS { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(9)"), 9);
        /*"    10 GE399-VLR-PRMTAR-CED-VAR       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis GE399_VLR_PRMTAR_CED_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 GE399-PCT-PROP-RAMO-PR       PIC S9(4)V9(9) USAGE COMP-3.*/
        public DoubleBasis GE399_PCT_PROP_RAMO_PR { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(9)"), 9);
        /*"    10 GE399-PCT-PROP-TOTAL-PR       PIC S9(4)V9(9) USAGE COMP-3.*/
        public DoubleBasis GE399_PCT_PROP_TOTAL_PR { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(9)"), 9);
        /*"    10 GE399-VLR-COMCOS-RAMO       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis GE399_VLR_COMCOS_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 GE399-PCT-PROP-COM-RAMO       PIC S9(4)V9(9) USAGE COMP-3.*/
        public DoubleBasis GE399_PCT_PROP_COM_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(9)"), 9);
        /*"    10 GE399-PCT-PROP-COM-TOTAL       PIC S9(4)V9(9) USAGE COMP-3.*/
        public DoubleBasis GE399_PCT_PROP_COM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(9)"), 9);
        /*"    10 GE399-NOM-PROGRAMA   PIC X(8).*/
        public StringBasis GE399_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE399-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE399_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}