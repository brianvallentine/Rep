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
    public class CONFITCE : VarBasis
    {
        /*"01  DCLCONTROLE-FITAS-CEF.*/
        public CONFITCE_DCLCONTROLE_FITAS_CEF DCLCONTROLE_FITAS_CEF { get; set; } = new CONFITCE_DCLCONTROLE_FITAS_CEF();

    }
}