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
    public class VGHIRACO_DCLVG_HIST_RAMO_COB : VarBasis
    {
        /*"    10 VGHIRACO-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VGHIRACO_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VGHIRACO-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGHIRACO_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGHIRACO-NUM-RAMO    PIC S9(4) USAGE COMP.*/
        public IntBasis VGHIRACO_NUM_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGHIRACO-NUM-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGHIRACO_NUM_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGHIRACO-QTD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGHIRACO_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGHIRACO-VLR-IMP-SEGURADA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGHIRACO_VLR_IMP_SEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGHIRACO-VLR-CUSTO   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGHIRACO_VLR_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGHIRACO-VLR-PREMIO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGHIRACO_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}