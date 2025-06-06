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
    public class PROPOCLA : VarBasis
    {
        /*"01  DCLPROPOSTA-CLAUSULAS.*/
        public PROPOCLA_DCLPROPOSTA_CLAUSULAS DCLPROPOSTA_CLAUSULAS { get; set; } = new PROPOCLA_DCLPROPOSTA_CLAUSULAS();

    }
}