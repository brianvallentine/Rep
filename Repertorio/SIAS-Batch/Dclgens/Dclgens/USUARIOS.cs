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
    public class USUARIOS : VarBasis
    {
        /*"01  DCLUSUARIOS.*/
        public USUARIOS_DCLUSUARIOS DCLUSUARIOS { get; set; } = new USUARIOS_DCLUSUARIOS();

    }
}