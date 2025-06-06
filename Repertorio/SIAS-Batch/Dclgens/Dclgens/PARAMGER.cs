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
    public class PARAMGER : VarBasis
    {
        /*"01  DCLPARAMETROS-GERAIS.*/
        public PARAMGER_DCLPARAMETROS_GERAIS DCLPARAMETROS_GERAIS { get; set; } = new PARAMGER_DCLPARAMETROS_GERAIS();

    }
}