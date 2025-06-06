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
    public class CLIENTES : VarBasis
    {
        /*"01  DCLCLIENTES.*/
        public CLIENTES_DCLCLIENTES DCLCLIENTES { get; set; } = new CLIENTES_DCLCLIENTES();

    }
}