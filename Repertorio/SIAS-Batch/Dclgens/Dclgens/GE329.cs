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
    public class GE329 : VarBasis
    {
        /*"01  DCLGE-DNE-BAIRRO.*/
        public GE329_DCLGE_DNE_BAIRRO DCLGE_DNE_BAIRRO { get; set; } = new GE329_DCLGE_DNE_BAIRRO();

    }
}