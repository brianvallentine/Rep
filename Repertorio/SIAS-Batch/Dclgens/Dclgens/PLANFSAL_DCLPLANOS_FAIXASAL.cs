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
    public class PLANFSAL_DCLPLANOS_FAIXASAL : VarBasis
    {
        /*"    10 PLANFSAL-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PLANFSAL_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PLANFSAL-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANFSAL_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANFSAL-COD-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis PLANFSAL_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANFSAL-FAIXA       PIC S9(4) USAGE COMP.*/
        public IntBasis PLANFSAL_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANFSAL-SALARIO-INICIAL  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANFSAL_SALARIO_INICIAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANFSAL-SALARIO-FINAL  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANFSAL_SALARIO_FINAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANFSAL-PRM-VG      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANFSAL_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANFSAL-PRM-AP      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANFSAL_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANFSAL-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PLANFSAL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}