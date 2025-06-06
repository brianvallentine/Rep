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
    public class RELATORI : VarBasis
    {
        /*"01  DCLRELATORIOS.*/
        public RELATORI_DCLRELATORIOS DCLRELATORIOS { get; set; } = new RELATORI_DCLRELATORIOS();

    }
}