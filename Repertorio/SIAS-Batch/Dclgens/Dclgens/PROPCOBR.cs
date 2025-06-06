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
    public class PROPCOBR : VarBasis
    {
        /*"01  DCLPROPOSTA-COBRANCA.*/
        public PROPCOBR_DCLPROPOSTA_COBRANCA DCLPROPOSTA_COBRANCA { get; set; } = new PROPCOBR_DCLPROPOSTA_COBRANCA();

    }
}