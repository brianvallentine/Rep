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
    public class AU071 : VarBasis
    {
        /*"01  DCLPARCELA-AUTO-COMPL.*/
        public AU071_DCLPARCELA_AUTO_COMPL DCLPARCELA_AUTO_COMPL { get; set; } = new AU071_DCLPARCELA_AUTO_COMPL();

    }
}