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
    public class VG078 : VarBasis
    {
        /*"01  DCLVG-ANDAMENTO-PROP.*/
        public VG078_DCLVG_ANDAMENTO_PROP DCLVG_ANDAMENTO_PROP { get; set; } = new VG078_DCLVG_ANDAMENTO_PROP();

    }
}