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
    public class ERPROPAZ : VarBasis
    {
        /*"01  DCLERROS-PROP-VIDAZUL.*/
        public ERPROPAZ_DCLERROS_PROP_VIDAZUL DCLERROS_PROP_VIDAZUL { get; set; } = new ERPROPAZ_DCLERROS_PROP_VIDAZUL();

    }
}