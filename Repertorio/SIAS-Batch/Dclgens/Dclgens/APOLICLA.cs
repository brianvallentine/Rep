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
    public class APOLICLA : VarBasis
    {
        /*"01  DCLAPOLICE-CLAUSULAS.*/
        public APOLICLA_DCLAPOLICE_CLAUSULAS DCLAPOLICE_CLAUSULAS { get; set; } = new APOLICLA_DCLAPOLICE_CLAUSULAS();

    }
}