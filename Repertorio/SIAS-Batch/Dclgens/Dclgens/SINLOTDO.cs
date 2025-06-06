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
    public class SINLOTDO : VarBasis
    {
        /*"01  DCLSINI-LOT-DOC01.*/
        public SINLOTDO_DCLSINI_LOT_DOC01 DCLSINI_LOT_DOC01 { get; set; } = new SINLOTDO_DCLSINI_LOT_DOC01();

    }
}