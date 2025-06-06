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
    public class LBLT2118_LT2118S_SAIDA_PARCELAN : VarBasis
    {
        /*"    10   LT2118S-PRM-TARIFARIO-N       PIC S9(010)V9999*/
        public DoubleBasis LT2118S_PRM_TARIFARIO_N { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9999"), 4);
        /*"    10   LT2118S-PRM-LIQUIDO-N         PIC S9(010)V9999*/
        public DoubleBasis LT2118S_PRM_LIQUIDO_N { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9999"), 4);
        /*"    10   LT2118S-ADICIONAL-FRACIO-N    PIC S9(010)V9999*/
        public DoubleBasis LT2118S_ADICIONAL_FRACIO_N { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9999"), 4);
        /*"    10   LT2118S-CUSTO-EMISSAO-N       PIC S9(010)V9999*/
        public DoubleBasis LT2118S_CUSTO_EMISSAO_N { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9999"), 4);
        /*"    10   LT2118S-VAL-IOCC-N            PIC S9(010)V9999*/
        public DoubleBasis LT2118S_VAL_IOCC_N { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9999"), 4);
        /*"    10   LT2118S-PRM-TOTAL-N           PIC S9(010)V9999*/
        public DoubleBasis LT2118S_PRM_TOTAL_N { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9999"), 4);
        /*"  05     LT2118S-SAIDA-ERRO*/
    }
}