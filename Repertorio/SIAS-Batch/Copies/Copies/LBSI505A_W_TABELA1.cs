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
    public class LBSI505A_W_TABELA1 : VarBasis
    {
        /*"        05  W-TAB1-CONTRATO       PIC 9(12)*/
        public IntBasis W_TAB1_CONTRATO { get; set; } = new IntBasis(new PIC("9", "12", "9(12)"));
        /*"        05  W-TAB1-NUM-UNO        PIC 9(04)*/
        public IntBasis W_TAB1_NUM_UNO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  W-NUM-OCORR-TAB1    PIC 9(09) VALUE 695*/

        public LBSI505A_W_TABELA1()
        {
            W_TAB1_CONTRATO.ValueChanged += OnValueChanged;
            W_TAB1_NUM_UNO.ValueChanged += OnValueChanged;
        }

    }
}