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
    public class COSSPREM : VarBasis
    {
        /*"01  DCLCOSSEGURO-PREMIOS.*/
        public COSSPREM_DCLCOSSEGURO_PREMIOS DCLCOSSEGURO_PREMIOS { get; set; } = new COSSPREM_DCLCOSSEGURO_PREMIOS();

    }
}