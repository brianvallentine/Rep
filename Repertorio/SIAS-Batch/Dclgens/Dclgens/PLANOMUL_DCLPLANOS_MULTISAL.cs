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
    public class PLANOMUL_DCLPLANOS_MULTISAL : VarBasis
    {
        /*"    10 PLANOMUL-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PLANOMUL_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PLANOMUL-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOMUL_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOMUL-COD-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOMUL_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOMUL-QTD-SAL-MORNATU  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOMUL_QTD_SAL_MORNATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOMUL-QTD-SAL-MORACID  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOMUL_QTD_SAL_MORACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOMUL-QTD-SAL-INVPERM  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOMUL_QTD_SAL_INVPERM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOMUL-LIM-CAP-MORNATU  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOMUL_LIM_CAP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOMUL-LIM-CAP-MORACID  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOMUL_LIM_CAP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOMUL-LIM-CAP-INVAPER  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOMUL_LIM_CAP_INVAPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOMUL-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PLANOMUL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}