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
    public class CBCONDEV : VarBasis
    {
        /*"01  DCLCB-CONTR-DEVPREMIO.*/
        public CBCONDEV_DCLCB_CONTR_DEVPREMIO DCLCB_CONTR_DEVPREMIO { get; set; } = new CBCONDEV_DCLCB_CONTR_DEVPREMIO();

    }
}