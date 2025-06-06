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
    public class SI127 : VarBasis
    {
        /*"01  DCLSI-PARCELA-AVISO.*/
        public SI127_DCLSI_PARCELA_AVISO DCLSI_PARCELA_AVISO { get; set; } = new SI127_DCLSI_PARCELA_AVISO();

    }
}