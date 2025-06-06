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
    public class SIPROJUD : VarBasis
    {
        /*"01  DCLSI-PROCESSO-JURID.*/
        public SIPROJUD_DCLSI_PROCESSO_JURID DCLSI_PROCESSO_JURID { get; set; } = new SIPROJUD_DCLSI_PROCESSO_JURID();

    }
}