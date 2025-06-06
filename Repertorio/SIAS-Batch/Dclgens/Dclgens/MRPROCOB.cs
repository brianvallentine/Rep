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
    public class MRPROCOB : VarBasis
    {
        /*"01  DCLMR-PRODUTO-COBER.*/
        public MRPROCOB_DCLMR_PRODUTO_COBER DCLMR_PRODUTO_COBER { get; set; } = new MRPROCOB_DCLMR_PRODUTO_COBER();

    }
}