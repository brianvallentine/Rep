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
    public class PROPVA : VarBasis
    {
        /*"01  DCLPROPOSTAS-VA.*/
        public PROPVA_DCLPROPOSTAS_VA DCLPROPOSTAS_VA { get; set; } = new PROPVA_DCLPROPOSTAS_VA();

    }
}