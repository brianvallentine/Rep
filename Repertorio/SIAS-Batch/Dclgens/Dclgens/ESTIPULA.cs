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
    public class ESTIPULA : VarBasis
    {
        /*"01  DCLESTIPULANTE.*/
        public ESTIPULA_DCLESTIPULANTE DCLESTIPULANTE { get; set; } = new ESTIPULA_DCLESTIPULANTE();

    }
}