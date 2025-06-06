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
    public class SEGURHIS : VarBasis
    {
        /*"01  DCLSEGURADOSVGAP-HIST.*/
        public SEGURHIS_DCLSEGURADOSVGAP_HIST DCLSEGURADOSVGAP_HIST { get; set; } = new SEGURHIS_DCLSEGURADOSVGAP_HIST();

    }
}