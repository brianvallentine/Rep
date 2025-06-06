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
    public class LBGE8051_TB_COD_SIACC_150 : VarBasis
    {
        /*"      15   TB-COD-RET-150        PIC  X(002)*/
        public StringBasis TB_COD_RET_150 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"      15   TB-COD-RET-PADSIAS    PIC  X(002)*/
        public StringBasis TB_COD_RET_PADSIAS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"      15   TB-COD-RET-PAD240     PIC  X(002)*/
        public StringBasis TB_COD_RET_PAD240 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"      15   TB-NOME-RET-150       PIC  X(080)*/
        public StringBasis TB_NOME_RET_150 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
        /*"01 TABELA-COD-SIACC-240*/

        public LBGE8051_TB_COD_SIACC_150()
        {
            TB_COD_RET_150.ValueChanged += OnValueChanged;
            TB_COD_RET_PADSIAS.ValueChanged += OnValueChanged;
            TB_COD_RET_PAD240.ValueChanged += OnValueChanged;
            TB_NOME_RET_150.ValueChanged += OnValueChanged;
        }

    }
}