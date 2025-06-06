using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBFCT018 : VarBasis
    {
        /*"01      REG-HEADER-PARAMETROS*/
        public LBFCT018_REG_HEADER_PARAMETROS REG_HEADER_PARAMETROS { get; set; } = new LBFCT018_REG_HEADER_PARAMETROS();

        public LBFCT018_REG_PARAMETROS REG_PARAMETROS { get; set; } = new LBFCT018_REG_PARAMETROS();

        public LBFCT018_REG_TRAILLER_PARAM REG_TRAILLER_PARAM { get; set; } = new LBFCT018_REG_TRAILLER_PARAM();

    }
}