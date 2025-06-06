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
    public class PLANOFAI_DCLPLANOS_FAIXAETA : VarBasis
    {
        /*"    10 PLANOFAI-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PLANOFAI_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PLANOFAI-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOFAI_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOFAI-COD-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOFAI_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOFAI-FAIXA       PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOFAI_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOFAI-IDADE-INICIAL  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOFAI_IDADE_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOFAI-IDADE-FINAL  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOFAI_IDADE_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOFAI-PRM-VG      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOFAI_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOFAI-PRM-AP      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOFAI_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOFAI-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PLANOFAI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PLANOFAI-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis PLANOFAI_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PLANOFAI-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis PLANOFAI_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}