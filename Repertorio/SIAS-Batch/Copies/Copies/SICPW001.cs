using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class SICPW001 : VarBasis
    {
        /*"01  SSICPW001.*/
        public SICPW001_SSICPW001 SSICPW001 { get; set; } = new SICPW001_SSICPW001();

    }
}