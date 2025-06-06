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
    public class AVISOSAL : VarBasis
    {
        /*"01  DCLAVISOS-SALDOS.*/
        public AVISOSAL_DCLAVISOS_SALDOS DCLAVISOS_SALDOS { get; set; } = new AVISOSAL_DCLAVISOS_SALDOS();

    }
}