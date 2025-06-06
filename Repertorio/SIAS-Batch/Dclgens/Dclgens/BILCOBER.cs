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
    public class BILCOBER : VarBasis
    {
        /*"01  DCLBILHETE-COBERTURA.*/
        public BILCOBER_DCLBILHETE_COBERTURA DCLBILHETE_COBERTURA { get; set; } = new BILCOBER_DCLBILHETE_COBERTURA();

    }
}