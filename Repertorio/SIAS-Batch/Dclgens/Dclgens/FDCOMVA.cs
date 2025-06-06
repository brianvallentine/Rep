using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class FDCOMVA : VarBasis
    {
        /*"01  DCLFUNDO-COMISSAO-VA.*/
        public FDCOMVA_DCLFUNDO_COMISSAO_VA DCLFUNDO_COMISSAO_VA { get; set; } = new FDCOMVA_DCLFUNDO_COMISSAO_VA();

    }
}