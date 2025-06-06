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
    public class RALCHEDO : VarBasis
    {
        /*"01  DCLRALACAO-CHEQ-DOCTO.*/
        public RALCHEDO_DCLRALACAO_CHEQ_DOCTO DCLRALACAO_CHEQ_DOCTO { get; set; } = new RALCHEDO_DCLRALACAO_CHEQ_DOCTO();

    }
}