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
    public class SIANAROD : VarBasis
    {
        /*"01  DCLSI-ANALISTA-RODIZI.*/
        public SIANAROD_DCLSI_ANALISTA_RODIZI DCLSI_ANALISTA_RODIZI { get; set; } = new SIANAROD_DCLSI_ANALISTA_RODIZI();

    }
}