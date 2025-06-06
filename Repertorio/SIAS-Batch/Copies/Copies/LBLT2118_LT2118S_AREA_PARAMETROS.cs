using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBLT2118_LT2118S_AREA_PARAMETROS : VarBasis
    {
        /*"  05     LT2118S-ENTRADA*/
        public LBLT2118_LT2118S_ENTRADA LT2118S_ENTRADA { get; set; } = new LBLT2118_LT2118S_ENTRADA();

        public LBLT2118_LT2118S_SAIDA_PARCELA1 LT2118S_SAIDA_PARCELA1 { get; set; } = new LBLT2118_LT2118S_SAIDA_PARCELA1();

        public LBLT2118_LT2118S_SAIDA_PARCELAN LT2118S_SAIDA_PARCELAN { get; set; } = new LBLT2118_LT2118S_SAIDA_PARCELAN();

        public LBLT2118_LT2118S_SAIDA_ERRO LT2118S_SAIDA_ERRO { get; set; } = new LBLT2118_LT2118S_SAIDA_ERRO();

        public DoubleBasis LT2118S_PCT_DESC_FIDEL_INFO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT2118S-PCT-DESC-EXP-INFO     PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT2118S_PCT_DESC_EXP_INFO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"  05  LT2118S-DESC-FIDEL            PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT2118S_DESC_FIDEL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"  05  LT2118S-DESC-FIDEL-INFO       PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT2118S_DESC_FIDEL_INFO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"  05  LT2118S-DESC-EXP              PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT2118S_DESC_EXP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"  05  LT2118S-DESC-EXP-INFO         PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT2118S_DESC_EXP_INFO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"  05  LT2118S-DESC-AGRUP            PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT2118S_DESC_AGRUP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"  05  LT2118S-DESC-COFRE            PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT2118S_DESC_COFRE { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"  05  LT2118S-DESC-BLINDAGEM        PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT2118S_DESC_BLINDAGEM { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"  05  LT2118S-VL-DESCONTO-TOTAL     PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT2118S_VL_DESCONTO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"  05  LT2118S-PRM-LIQUIDO           PIC S9(010)V9999*/
        public DoubleBasis LT2118S_PRM_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9999"), 4);
    }
}