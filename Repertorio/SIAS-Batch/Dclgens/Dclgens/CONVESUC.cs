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
    public class CONVESUC : VarBasis
    {
        /*"01  DCLCONVENIO-SUCOV.*/
        public CONVESUC_DCLCONVENIO_SUCOV DCLCONVENIO_SUCOV { get; set; } = new CONVESUC_DCLCONVENIO_SUCOV();

    }
}