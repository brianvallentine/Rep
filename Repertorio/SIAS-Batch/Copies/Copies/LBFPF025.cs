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
    public class LBFPF025 : VarBasis
    {
        /*"01  R8-PONTUACAO-SIDEM*/
        public LBFPF025_R8_PONTUACAO_SIDEM R8_PONTUACAO_SIDEM { get; set; } = new LBFPF025_R8_PONTUACAO_SIDEM();

    }
}