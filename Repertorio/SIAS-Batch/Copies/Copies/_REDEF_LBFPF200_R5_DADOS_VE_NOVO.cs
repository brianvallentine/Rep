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
    public class _REDEF_LBFPF200_R5_DADOS_VE_NOVO : VarBasis
    {
        /*"        10    R5-DADOS-NIVEL OCCURS 4 TIMES*/
        public ListBasis<LBFPF200_R5_DADOS_NIVEL> R5_DADOS_NIVEL { get; set; } = new ListBasis<LBFPF200_R5_DADOS_NIVEL>(4);

        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");

        public _REDEF_LBFPF200_R5_DADOS_VE_NOVO()
        {
            R5_DADOS_NIVEL.ValueChanged += OnValueChanged;
            FILLER_0.ValueChanged += OnValueChanged;
        }

    }
}