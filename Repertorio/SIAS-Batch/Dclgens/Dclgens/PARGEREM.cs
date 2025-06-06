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
    public class PARGEREM : VarBasis
    {
        /*"01  DCLPARM-GERAIS-EMPRES.*/
        public PARGEREM_DCLPARM_GERAIS_EMPRES DCLPARM_GERAIS_EMPRES { get; set; } = new PARGEREM_DCLPARM_GERAIS_EMPRES();

    }
}