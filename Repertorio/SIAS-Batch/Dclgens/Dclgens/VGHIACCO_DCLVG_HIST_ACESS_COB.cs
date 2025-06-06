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
    public class VGHIACCO_DCLVG_HIST_ACESS_COB : VarBasis
    {
        /*"    10 VGHIACCO-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VGHIACCO_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VGHIACCO-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGHIACCO_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGHIACCO-NUM-ACESSORIO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGHIACCO_NUM_ACESSORIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGHIACCO-QTD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGHIACCO_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGHIACCO-VLR-IMP-SEGURADA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGHIACCO_VLR_IMP_SEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGHIACCO-VLR-CUSTO   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGHIACCO_VLR_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGHIACCO-VLR-PREMIO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGHIACCO_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}