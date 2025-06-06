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
    public class SIPADOFI : VarBasis
    {
        /*"01  DCLSI-PAGA-DOC-FISCAL.*/
        public SIPADOFI_DCLSI_PAGA_DOC_FISCAL DCLSI_PAGA_DOC_FISCAL { get; set; } = new SIPADOFI_DCLSI_PAGA_DOC_FISCAL();

    }
}