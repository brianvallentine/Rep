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
    public class FIPADOLA : VarBasis
    {
        /*"01  DCLFI-PAGA-DOCF-LANC.*/
        public FIPADOLA_DCLFI_PAGA_DOCF_LANC DCLFI_PAGA_DOCF_LANC { get; set; } = new FIPADOLA_DCLFI_PAGA_DOCF_LANC();

    }
}