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
    public class OD007 : VarBasis
    {
        /*"01  DCLOD-PESSOA-ENDERECO.*/
        public OD007_DCLOD_PESSOA_ENDERECO DCLOD_PESSOA_ENDERECO { get; set; } = new OD007_DCLOD_PESSOA_ENDERECO();

    }
}