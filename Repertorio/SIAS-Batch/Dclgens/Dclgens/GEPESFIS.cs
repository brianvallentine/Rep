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
    public class GEPESFIS : VarBasis
    {
        /*"01  DCLGE-PESSOA-FISICA.*/
        public GEPESFIS_DCLGE_PESSOA_FISICA DCLGE_PESSOA_FISICA { get; set; } = new GEPESFIS_DCLGE_PESSOA_FISICA();

    }
}