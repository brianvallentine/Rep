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
    public class AU077 : VarBasis
    {
        /*"01  DCLAU-PROD-COBERTURA.*/
        public AU077_DCLAU_PROD_COBERTURA DCLAU_PROD_COBERTURA { get; set; } = new AU077_DCLAU_PROD_COBERTURA();

    }
}