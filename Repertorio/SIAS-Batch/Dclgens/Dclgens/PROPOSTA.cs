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
    public class PROPOSTA : VarBasis
    {
        /*"01  DCLPROPOSTAS.*/
        public PROPOSTA_DCLPROPOSTAS DCLPROPOSTAS { get; set; } = new PROPOSTA_DCLPROPOSTAS();

    }
}