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
    public class OD005 : VarBasis
    {
        /*"01  DCLOD-PESSOA-EMAIL.*/
        public OD005_DCLOD_PESSOA_EMAIL DCLOD_PESSOA_EMAIL { get; set; } = new OD005_DCLOD_PESSOA_EMAIL();

    }
}