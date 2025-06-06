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
    public class RSGEWSTR : VarBasis
    {
        /*"01 LK-RSGEWSTR-FUNCAO                PIC  9(001)*/
        public IntBasis LK_RSGEWSTR_FUNCAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01 LK-RSGEWSTR-INP-STR*/
        public RSGEWSTR_LK_RSGEWSTR_INP_STR LK_RSGEWSTR_INP_STR { get; set; } = new RSGEWSTR_LK_RSGEWSTR_INP_STR();

        public RSGEWSTR_LK_RSGEWSTR_INP_NUM LK_RSGEWSTR_INP_NUM { get; set; } = new RSGEWSTR_LK_RSGEWSTR_INP_NUM();

        public IntBasis LK_RSGEWSTR_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-RSGEWSTR-OUT-STR*/
        public RSGEWSTR_LK_RSGEWSTR_OUT_STR LK_RSGEWSTR_OUT_STR { get; set; } = new RSGEWSTR_LK_RSGEWSTR_OUT_STR();

        public RSGEWSTR_LK_RSGEWSTR_OUT_NUM LK_RSGEWSTR_OUT_NUM { get; set; } = new RSGEWSTR_LK_RSGEWSTR_OUT_NUM();

    }
}