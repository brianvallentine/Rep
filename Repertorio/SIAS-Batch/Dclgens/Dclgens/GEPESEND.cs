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
    public class GEPESEND : VarBasis
    {
        /*"01  DCLGE-PESSOA-ENDERECO.*/
        public GEPESEND_DCLGE_PESSOA_ENDERECO DCLGE_PESSOA_ENDERECO { get; set; } = new GEPESEND_DCLGE_PESSOA_ENDERECO();

    }
}