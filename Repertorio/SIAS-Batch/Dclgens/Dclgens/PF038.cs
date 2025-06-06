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
    public class PF038 : VarBasis
    {
        /*"01  DCLPF-PGTO-SIVPF.*/
        public PF038_DCLPF_PGTO_SIVPF DCLPF_PGTO_SIVPF { get; set; } = new PF038_DCLPF_PGTO_SIVPF();

    }
}