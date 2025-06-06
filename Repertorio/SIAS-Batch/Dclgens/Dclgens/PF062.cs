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
    public class PF062 : VarBasis
    {
        /*"01  DCLPF-CBO.*/
        public PF062_DCLPF_CBO DCLPF_CBO { get; set; } = new PF062_DCLPF_CBO();

    }
}