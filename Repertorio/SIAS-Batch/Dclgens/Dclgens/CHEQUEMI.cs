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
    public class CHEQUEMI : VarBasis
    {
        /*"01  DCLCHEQUES-EMITIDOS.*/
        public CHEQUEMI_DCLCHEQUES_EMITIDOS DCLCHEQUES_EMITIDOS { get; set; } = new CHEQUEMI_DCLCHEQUES_EMITIDOS();

    }
}