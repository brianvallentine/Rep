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
    public class GE149 : VarBasis
    {
        /*"01  DCLGE-NOME-SOCIAL.*/
        public GE149_DCLGE_NOME_SOCIAL DCLGE_NOME_SOCIAL { get; set; } = new GE149_DCLGE_NOME_SOCIAL();

    }
}