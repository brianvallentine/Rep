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
    public class BILERROS : VarBasis
    {
        /*"01  DCLBILHETE-ERROS.*/
        public BILERROS_DCLBILHETE_ERROS DCLBILHETE_ERROS { get; set; } = new BILERROS_DCLBILHETE_ERROS();

    }
}