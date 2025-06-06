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
    public class FIPADOIM : VarBasis
    {
        /*"01  DCLFI-PAGA-DOCF-IMP.*/
        public FIPADOIM_DCLFI_PAGA_DOCF_IMP DCLFI_PAGA_DOCF_IMP { get; set; } = new FIPADOIM_DCLFI_PAGA_DOCF_IMP();

    }
}