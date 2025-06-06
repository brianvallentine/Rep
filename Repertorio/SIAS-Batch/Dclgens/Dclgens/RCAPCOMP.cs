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
    public class RCAPCOMP : VarBasis
    {
        /*"01  DCLRCAP-COMPLEMENTAR.*/
        public RCAPCOMP_DCLRCAP_COMPLEMENTAR DCLRCAP_COMPLEMENTAR { get; set; } = new RCAPCOMP_DCLRCAP_COMPLEMENTAR();

    }
}