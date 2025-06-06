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
    public class LBGE8051_TAB_COD_RETORNO_SIAS : VarBasis
    {
        /*"      15     TB-COD-RET-SIAS    PIC  9(002)*/
        public IntBasis TB_COD_RET_SIAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"      15     TB-NOME-RET-SIAS   PIC  X(035)*/
        public StringBasis TB_NOME_RET_SIAS { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");

        public LBGE8051_TAB_COD_RETORNO_SIAS()
        {
            TB_COD_RET_SIAS.ValueChanged += OnValueChanged;
            TB_NOME_RET_SIAS.ValueChanged += OnValueChanged;
        }

    }
}