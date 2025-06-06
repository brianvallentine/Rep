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
    public class SI042 : VarBasis
    {
        /*"01  DCLSI-DETALHE-PROC-JURID.*/
        public SI042_DCLSI_DETALHE_PROC_JURID DCLSI_DETALHE_PROC_JURID { get; set; } = new SI042_DCLSI_DETALHE_PROC_JURID();

    }
}