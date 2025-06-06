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
    public class PROPOFID : VarBasis
    {
        /*"01  DCLPROPOSTA-FIDELIZ.*/
        public PROPOFID_DCLPROPOSTA_FIDELIZ DCLPROPOSTA_FIDELIZ { get; set; } = new PROPOFID_DCLPROPOSTA_FIDELIZ();

    }
}