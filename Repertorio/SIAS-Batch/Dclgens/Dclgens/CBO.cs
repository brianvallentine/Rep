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
    public class CBO : VarBasis
    {
        /*"01  DCLCBO.*/
        public CBO_DCLCBO DCLCBO { get; set; } = new CBO_DCLCBO();

    }
}