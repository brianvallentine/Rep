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
    public class LBSI0005 : VarBasis
    {
        /*"*/
        public IntBasis WS_IND_TB { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01       TABELA-MENSAGENS*/
        public LBSI0005_TABELA_MENSAGENS TABELA_MENSAGENS { get; set; } = new LBSI0005_TABELA_MENSAGENS();

    }
}