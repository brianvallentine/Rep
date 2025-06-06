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
    public class GE085 : VarBasis
    {
        /*"01  DCLGE-CLIENTE-EMPRESA.*/
        public GE085_DCLGE_CLIENTE_EMPRESA DCLGE_CLIENTE_EMPRESA { get; set; } = new GE085_DCLGE_CLIENTE_EMPRESA();

    }
}