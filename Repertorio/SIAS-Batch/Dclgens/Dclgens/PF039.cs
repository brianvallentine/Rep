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
    public class PF039 : VarBasis
    {
        /*"01  DCLPF-PAGADOR-SIVPF.*/
        public PF039_DCLPF_PAGADOR_SIVPF DCLPF_PAGADOR_SIVPF { get; set; } = new PF039_DCLPF_PAGADOR_SIVPF();

    }
}