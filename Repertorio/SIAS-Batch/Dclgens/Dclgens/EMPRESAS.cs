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
    public class EMPRESAS : VarBasis
    {
        /*"01  DCLEMPRESAS.*/
        public EMPRESAS_DCLEMPRESAS DCLEMPRESAS { get; set; } = new EMPRESAS_DCLEMPRESAS();

    }
}