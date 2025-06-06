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
    public class PFACOPRO : VarBasis
    {
        /*"01  DCLPF-ACOMP-PROPOSTAS.*/
        public PFACOPRO_DCLPF_ACOMP_PROPOSTAS DCLPF_ACOMP_PROPOSTAS { get; set; } = new PFACOPRO_DCLPF_ACOMP_PROPOSTAS();

    }
}