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
    public class PLANOAGE_DCLPLANO_AGENCIAMENTO : VarBasis
    {
        /*"    10 PLANOAGE-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PLANOAGE_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PLANOAGE-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOAGE_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOAGE-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOAGE_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOAGE-PCT-PAGA-PARCELA  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOAGE_PCT_PAGA_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PLANOAGE-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PLANOAGE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PLANOAGE-COD-AGENCIADOR  PIC S9(9) USAGE COMP.*/
        public IntBasis PLANOAGE_COD_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PLANOAGE-MATRIC-INDICADOR  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PLANOAGE_MATRIC_INDICADOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"*/
    }
}