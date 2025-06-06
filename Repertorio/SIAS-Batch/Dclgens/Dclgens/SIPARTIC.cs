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
    public class SIPARTIC : VarBasis
    {
        /*"01  DCLSI-PARTICIPANTE.*/
        public SIPARTIC_DCLSI_PARTICIPANTE DCLSI_PARTICIPANTE { get; set; } = new SIPARTIC_DCLSI_PARTICIPANTE();

    }
}