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
    public class LBGE8051_TB_COD_SIACC_240 : VarBasis
    {
        /*"     15   TB-COD-RET-240        PIC  X(002)*/
        public StringBasis TB_COD_RET_240 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"     15   FILLER                PIC  X(001)*/
        public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     15   TB-NOME-RET-240       PIC  X(080)*/
        public StringBasis TB_NOME_RET_240 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
        /*"01 TABELA-COD-RETORNO-SIAS*/

        public LBGE8051_TB_COD_SIACC_240()
        {
            TB_COD_RET_240.ValueChanged += OnValueChanged;
            FILLER_191.ValueChanged += OnValueChanged;
            TB_NOME_RET_240.ValueChanged += OnValueChanged;
        }

    }
}