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
    public class SIFASTIP : VarBasis
    {
        /*"01  DCLSI-FASE-TIPO.*/
        public SIFASTIP_DCLSI_FASE_TIPO DCLSI_FASE_TIPO { get; set; } = new SIFASTIP_DCLSI_FASE_TIPO();

    }
}