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
    public class PROPESTI : VarBasis
    {
        /*"01  DCLPROP-ESTIPULANTE.*/
        public PROPESTI_DCLPROP_ESTIPULANTE DCLPROP_ESTIPULANTE { get; set; } = new PROPESTI_DCLPROP_ESTIPULANTE();

    }
}