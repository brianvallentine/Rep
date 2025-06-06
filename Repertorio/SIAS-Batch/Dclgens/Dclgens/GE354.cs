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
    public class GE354 : VarBasis
    {
        /*"01  DCLGE-EVENTO.*/
        public GE354_DCLGE_EVENTO DCLGE_EVENTO { get; set; } = new GE354_DCLGE_EVENTO();

    }
}