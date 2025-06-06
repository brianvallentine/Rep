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
    public class PARAMRAM_DCLPARAMETROS_RAMOS : VarBasis
    {
        /*"    10 PARAMRAM-RAMO-VGAPC  PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMRAM_RAMO_VGAPC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMRAM-RAMO-VG     PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMRAM_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMRAM-RAMO-AP     PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMRAM_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMRAM-RAMO-SAUDE  PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMRAM_RAMO_SAUDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMRAM-RAMO-SA-INDV  PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMRAM_RAMO_SA_INDV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMRAM-RAMO-EDUCACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMRAM_RAMO_EDUCACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMRAM-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PARAMRAM_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARAMRAM-NUM-RAMO-PRSTMISTA  PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMRAM_NUM_RAMO_PRSTMISTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}