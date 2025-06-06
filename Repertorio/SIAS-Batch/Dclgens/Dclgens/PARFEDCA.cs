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
    public class PARFEDCA : VarBasis
    {
        /*"01  DCLPARCEL-FED-CAP-VA.*/
        public PARFEDCA_DCLPARCEL_FED_CAP_VA DCLPARCEL_FED_CAP_VA { get; set; } = new PARFEDCA_DCLPARCEL_FED_CAP_VA();

    }
}