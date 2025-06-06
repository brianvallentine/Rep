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
    public class SINIPENH : VarBasis
    {
        /*"01  DCLSINI-PENHOR01.*/
        public SINIPENH_DCLSINI_PENHOR01 DCLSINI_PENHOR01 { get; set; } = new SINIPENH_DCLSINI_PENHOR01();

    }
}