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
    public class MRPROCOR : VarBasis
    {
        /*"01  DCLMR-PROPOSTA-COBER.*/
        public MRPROCOR_DCLMR_PROPOSTA_COBER DCLMR_PROPOSTA_COBER { get; set; } = new MRPROCOR_DCLMR_PROPOSTA_COBER();

    }
}