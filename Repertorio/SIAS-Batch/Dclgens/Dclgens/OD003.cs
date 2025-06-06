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
    public class OD003 : VarBasis
    {
        /*"01  DCLOD-PESSOA-JURIDICA.*/
        public OD003_DCLOD_PESSOA_JURIDICA DCLOD_PESSOA_JURIDICA { get; set; } = new OD003_DCLOD_PESSOA_JURIDICA();

    }
}