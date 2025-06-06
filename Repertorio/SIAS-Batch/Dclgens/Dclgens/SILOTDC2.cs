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
    public class SILOTDC2 : VarBasis
    {
        /*"01  DCLSINI-LOT-DOC02.*/
        public SILOTDC2_DCLSINI_LOT_DOC02 DCLSINI_LOT_DOC02 { get; set; } = new SILOTDC2_DCLSINI_LOT_DOC02();

    }
}