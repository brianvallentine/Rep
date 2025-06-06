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
    public class OD004 : VarBasis
    {
        /*"01  DCLOD-PESSOA-TELEFONE.*/
        public OD004_DCLOD_PESSOA_TELEFONE DCLOD_PESSOA_TELEFONE { get; set; } = new OD004_DCLOD_PESSOA_TELEFONE();

    }
}