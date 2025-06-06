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
    public class GEPESSOA : VarBasis
    {
        /*"01  DCLGE-PESSOA.*/
        public GEPESSOA_DCLGE_PESSOA DCLGE_PESSOA { get; set; } = new GEPESSOA_DCLGE_PESSOA();

    }
}