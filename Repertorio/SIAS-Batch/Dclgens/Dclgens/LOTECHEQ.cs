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
    public class LOTECHEQ : VarBasis
    {
        /*"01  DCLLOTE-CHEQUES.*/
        public LOTECHEQ_DCLLOTE_CHEQUES DCLLOTE_CHEQUES { get; set; } = new LOTECHEQ_DCLLOTE_CHEQUES();

    }
}