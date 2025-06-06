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
    public class HISTOCHE : VarBasis
    {
        /*"01  DCLHISTORICO-CHEQUES.*/
        public HISTOCHE_DCLHISTORICO_CHEQUES DCLHISTORICO_CHEQUES { get; set; } = new HISTOCHE_DCLHISTORICO_CHEQUES();

    }
}