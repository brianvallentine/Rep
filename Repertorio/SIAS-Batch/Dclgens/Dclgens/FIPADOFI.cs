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
    public class FIPADOFI : VarBasis
    {
        /*"01  DCLFI-PAGA-DOC-FISCAL.*/
        public FIPADOFI_DCLFI_PAGA_DOC_FISCAL DCLFI_PAGA_DOC_FISCAL { get; set; } = new FIPADOFI_DCLFI_PAGA_DOC_FISCAL();

    }
}